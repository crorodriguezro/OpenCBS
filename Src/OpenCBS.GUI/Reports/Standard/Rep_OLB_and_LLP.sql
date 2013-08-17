CREATE PROCEDURE dbo.Rep_OLB_and_LLP 
	@date DATETIME
	, @disbursed_in INT
	, @display_in INT
	, @user_id INT
	, @subordinate_id nvarchar(max)
    , @branch_id INT
AS BEGIN
	DECLARE @conso_mode BIT
	SELECT @conso_mode = CAST(value AS BIT)
	FROM dbo.GeneralParameters
	WHERE [key] = 'CONSOLIDATION_MODE'

	IF 0 = @conso_mode
	BEGIN
		DECLARE @users TABLE
		(
			id INT NOT NULL
		)
		INSERT INTO @users
		SELECT @user_id
		INSERT INTO @users
		SELECT subordinate_id
		FROM dbo.UsersSubordinates
		WHERE user_id = @user_id

		DECLARE @active_loans TABLE (
			id INT NOT NULL
			, olb MONEY NOT NULL
			, interest MONEY NOT NULL
			, late_days INT NOT NULL
			, rescheduled BIT NOT NULL
		)

		DECLARE @re_llp_rate FLOAT
		SELECT @re_llp_rate = provisioning_value
		FROM dbo.ProvisioningRules
		WHERE number_of_days_min = -1 AND number_of_days_max = -1

		INSERT INTO @active_loans
		SELECT id, olb, interest, late_days, CASE WHEN re.contract_id IS NULL THEN 0 ELSE 1 END
		FROM dbo.ActiveLoans_MC(@date, @disbursed_in, @display_in, @branch_id) al
		LEFT JOIN (
			SELECT contract_id
			FROM dbo.ContractEvents
			WHERE event_type = 'ROLE' AND event_date <= @date AND is_deleted = 0
			GROUP BY contract_id
		) re ON re.contract_id = al.id

        DECLARE @installments TABLE
        (
            contract_id INT NOT NULL
            , last_expected_date DATETIME NOT NULL
        )
        INSERT INTO @installments
        SELECT contract_id, MAX(expected_date)
        FROM dbo.InstallmentSnapshot(@date)
        GROUP BY contract_id

		SELECT c.contract_code
		, al.olb
		, al.interest
		, al.late_days
		, cl.name client_name
		, u.first_name + ' ' + u.last_name loan_officer_name
		, b.code AS branch_name
		, pack.name product_name
		, d.name district_name
		, cur.name currency_name
		, c.start_date
                , i.last_expected_date close_date
		, pr.number_of_days_min range_from
		, pr.number_of_days_max range_to
		, CASE
			WHEN 1 = al.rescheduled AND pr.provisioning_value < @re_llp_rate THEN @re_llp_rate * 100
			ELSE pr.provisioning_value * 100
		END llp_rate
		, CASE
			WHEN 1 = al.rescheduled AND pr.provisioning_value < @re_llp_rate THEN CAST(ROUND(al.olb * @re_llp_rate, 0) AS MONEY)
			ELSE CAST(ROUND(al.olb * pr.provisioning_value, 0) AS MONEY)
		END llp
		, CASE WHEN 1 = al.rescheduled THEN 'Rescheduled loans' ELSE '' END rescheduled
		FROM @active_loans al
		INNER JOIN dbo.Contracts c ON c.id = al.id
		INNER JOIN dbo.Projects j ON j.id = c.project_id
		INNER JOIN dbo.Credit cr ON cr.id = c.id
		INNER JOIN dbo.Packages pack ON pack.id = cr.package_id
		INNER JOIN dbo.Tiers t ON t.id = j.tiers_id
		LEFT JOIN dbo.Branches b ON b.id = t.branch_id
		INNER JOIN dbo.Districts d ON d.id = t.district_id
		INNER JOIN dbo.Clients cl ON cl.id = t.id
		INNER JOIN dbo.Users u ON u.id = cr.loanofficer_id
		INNER JOIN dbo.Currencies cur ON cur.id = pack.currency_id
		--INNER JOIN dbo.ProvisioningRules pr ON al.late_days BETWEEN pr.number_of_days_min AND pr.number_of_days_max
		INNER JOIN (
			SELECT number_of_days_min, number_of_days_max, provisioning_value
			FROM dbo.ProvisioningRules
			GROUP BY number_of_days_min, number_of_days_max, provisioning_value
		           ) pr ON al.late_days BETWEEN pr.number_of_days_min AND pr.number_of_days_max
            INNER JOIN @installments i ON i.contract_id = c.id
		-- WHERE 
		 --cr.loanofficer_id IN (SELECT * FROM dbo.IntListToTable(@subordinate_id) where number=0)
		 WHERE (cr.loanofficer_id IN (SELECT * FROM dbo.IntListToTable(@subordinate_id) where number!=0) OR cr.loanofficer_id IN (SELECT id FROM @users))
		ORDER BY al.rescheduled, al.late_days, cur.name
	END
	ELSE
	BEGIN
		DECLARE @pivot INT
		SELECT @pivot = id
		FROM dbo.Currencies
		WHERE is_pivot = 1

		DECLARE @xr FLOAT
		SELECT @xr = dbo.GetXR(@pivot, @display_in, @date)
		SET @xr = ISNULL(@xr, 1)

		SELECT t.contract_code
		, t.olb * @xr olb
		, t.interest * @xr interest
		, t.late_days
		, t.client_name, t.loan_officer_name, t.branch_name, t.product_name, t.district_name
		, t.start_date, t.close_date, t.range_from, t.range_to
		, t.llp_rate
		, t.llp * @xr llp
		, CASE WHEN 0 = t.rescheduled THEN '' ELSE 'Rescheduled loans' END rescheduled
		FROM dbo.Rep_OLB_and_LLP_Data t
		LEFT JOIN
		(
			SELECT branch_name
			, ROW_NUMBER() OVER (ORDER BY branch_name) branch_id
			FROM dbo.Rep_OLB_and_LLP_Data
			GROUP BY branch_name
		) b ON b.branch_name = t.branch_name
		WHERE t.load_date = @date
		AND (0 = @branch_id OR b.branch_id = @branch_id)
		ORDER BY t.rescheduled, t.late_days, t.branch_name
	END
END
