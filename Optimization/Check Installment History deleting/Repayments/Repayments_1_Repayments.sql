
		SELECT Reps.event_date AS [date]
			, Cont.contract_code 
			,COALESCE(Gr.name, Corp.name, ISNULL(Pers.first_name, '')) AS [client_first_name]
            ,ISNULL(Pers.last_name, '') AS [client_last_name]
            , Us.first_name + SPACE(1) + Us.last_name AS [loan_officer_name]
			, Pack.name AS [loan_product_name]
			, Dts.name AS [district_name]
			, Br.code AS branch_name
			, Reps.commissions AS [early_fee]
			, Reps.penalties AS [late_fee]
			, Reps.principal
			, Reps.interest
			, (Reps.principal + Reps.interest + Reps.commissions + Reps.penalties) AS [total]
			--, Reps.written_off
		FROM dbo.Repayments_MC(@from, @to, @disbursed_in, @display_in, @user_id, @subordinate_id, @branch_id) AS Reps
		LEFT JOIN dbo.ContractEvents AS ConEv ON ConEv.id = Reps.event_id
		LEFT JOIN dbo.Credit AS Cr ON Cr.id = Reps.contract_id
		LEFT JOIN dbo.Contracts AS Cont ON Reps.contract_id = Cont.id
		LEFT JOIN dbo.Projects AS Pr ON Cont.project_id = Pr.id
		LEFT JOIN dbo.Groups AS Gr ON Gr.id = Pr.tiers_id
		LEFT JOIN dbo.Persons AS Pers ON Pers.id = Pr.tiers_id
		LEFT JOIN dbo.Corporates AS Corp ON Corp.id = Pr.tiers_id
		LEFT JOIN dbo.Tiers AS Trs ON Pr.tiers_id = Trs.id
		LEFT JOIN dbo.Branches Br ON Br.id = Trs.branch_id
		LEFT JOIN dbo.Districts AS Dts ON Dts.id = Trs.district_id
		LEFT JOIN dbo.Users AS Us ON Cr.loanofficer_id = Us.id
		LEFT JOIN dbo.Packages AS Pack ON Cr.package_id = Pack.id
		Where reps.written_off = 0
		ORDER BY Reps.event_date  
	