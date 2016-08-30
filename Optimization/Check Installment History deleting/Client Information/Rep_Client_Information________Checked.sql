declare @query nvarchar(MAX)=

N'declare @roles nvarchar(MAX)=N''SUPER,CASHI,LOF,VISIT,ADMIN''
declare @from datetime=''2016-06-29 00:00:00''
declare @disbursed_in int=0
declare @display_in int=1
declare @branch_id int=0
declare @user_id int=1

DECLARE @advanced_fields_person TABLE
(
	id INT IDENTITY(1,1) NOT NULL
	, field_id int	
)
INSERT INTO @advanced_fields_person SELECT id FROM customfields where owner = ''Person'' and [type] != ''Boolean''

DECLARE @custom1_person int = (select field_id FROM @advanced_fields_person WHERE id = 1)
DECLARE @custom2_person int = (select field_id FROM @advanced_fields_person WHERE id = 2)
DECLARE @custom3_person int = (select field_id FROM @advanced_fields_person WHERE id = 3)
DECLARE @custom4_person int = (select field_id FROM @advanced_fields_person WHERE id = 4)
DECLARE @custom5_person int = (select field_id FROM @advanced_fields_person WHERE id = 5)
DECLARE @custom6_person int = (select field_id FROM @advanced_fields_person WHERE id = 6)
DECLARE @custom7_person int = (select field_id FROM @advanced_fields_person WHERE id = 7)
DECLARE @custom8_person int = (select field_id FROM @advanced_fields_person WHERE id = 8)
DECLARE @custom9_person int = (select field_id FROM @advanced_fields_person WHERE id = 9)
DECLARE @custom10_person int = (select field_id FROM @advanced_fields_person WHERE id = 10)

DECLARE @advanced_fields_corporate TABLE
(
	id INT IDENTITY(1,1) NOT NULL
	, field_id int	
)
INSERT INTO @advanced_fields_corporate SELECT id FROM customfields where owner = ''Corporate'' and [type] != ''Boolean''

DECLARE @custom1_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 1)
DECLARE @custom2_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 2)
DECLARE @custom3_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 3)
DECLARE @custom4_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 4)
DECLARE @custom5_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 5)
DECLARE @custom6_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 6)
DECLARE @custom7_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 7)
DECLARE @custom8_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 8)
DECLARE @custom9_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 9)
DECLARE @custom10_corporate int = (select field_id FROM @advanced_fields_corporate WHERE id = 10)
	
DECLARE @advanced_fields_village TABLE
(
	id INT IDENTITY(1,1) NOT NULL
	, field_id int	
)
INSERT INTO @advanced_fields_village SELECT id FROM customfields where owner = ''NonSolidarityGroup'' and [type] != ''Boolean''

DECLARE @custom1_village int = (select field_id FROM @advanced_fields_village WHERE id = 1)
DECLARE @custom2_village int = (select field_id FROM @advanced_fields_village WHERE id = 2)
DECLARE @custom3_village int = (select field_id FROM @advanced_fields_village WHERE id = 3)
DECLARE @custom4_village int = (select field_id FROM @advanced_fields_village WHERE id = 4)
DECLARE @custom5_village int = (select field_id FROM @advanced_fields_village WHERE id = 5)
DECLARE @custom6_village int = (select field_id FROM @advanced_fields_village WHERE id = 6)
DECLARE @custom7_village int = (select field_id FROM @advanced_fields_village WHERE id = 7)
DECLARE @custom8_village int = (select field_id FROM @advanced_fields_village WHERE id = 8)
DECLARE @custom9_village int = (select field_id FROM @advanced_fields_village WHERE id = 9)
DECLARE @custom10_village int = (select field_id FROM @advanced_fields_village WHERE id = 10)

DECLARE @advanced_fields_group TABLE
(
	id INT IDENTITY(1,1) NOT NULL
	, field_id int	
)
INSERT INTO @advanced_fields_group SELECT id FROM customfields where owner = ''SolidarityGroup'' and [type] != ''Boolean''

DECLARE @custom1_group int = (select field_id FROM @advanced_fields_group WHERE id = 1)
DECLARE @custom2_group int = (select field_id FROM @advanced_fields_group WHERE id = 2)
DECLARE @custom3_group int = (select field_id FROM @advanced_fields_group WHERE id = 3)
DECLARE @custom4_group int = (select field_id FROM @advanced_fields_group WHERE id = 4)
DECLARE @custom5_group int = (select field_id FROM @advanced_fields_group WHERE id = 5)
DECLARE @custom6_group int = (select field_id FROM @advanced_fields_group WHERE id = 6)
DECLARE @custom7_group int = (select field_id FROM @advanced_fields_group WHERE id = 7)
DECLARE @custom8_group int = (select field_id FROM @advanced_fields_group WHERE id = 8)
DECLARE @custom9_group int = (select field_id FROM @advanced_fields_group WHERE id = 9)
DECLARE @custom10_group int = (select field_id FROM @advanced_fields_group WHERE id = 10)
	
DECLARE @active_loans TABLE
(
    id INT NOT NULL
    , late_days INT NOT NULL
    , olb MONEY
    , amount MONEY
)
INSERT INTO @active_loans
SELECT id, late_days, olb, amount
FROM dbo.ActiveLoans(@from, @branch_id)
    
SELECT DISTINCT  
	Tr.id 
, COALESCE(Corporates.Name, Gr.name, ISNULL(Pers.first_name, ''''))  AS [client_first_name]
,ISNULL(Pers.last_name, '''') AS [client_last_name]
, Tr.client_type_code AS [type]
, Dis.name AS [district]
, ISNULL(Tr.personal_phone, ''-'') AS [pers_phone]
, ISNULL(Tr.secondary_personal_phone, ''-'') AS [s_pers_phone]
, COALESCE(EcAc.name, CorporateActivities.name, ''-'') AS [activity]
, ISNULL(Pers.sex, ''-'') AS sex, Cont.contract_code AS [contract_code]
, Cont.start_date
, Cont.close_date 
, CAST(al.amount * dbo.GetXR(Pack.currency_id, @display_in, @from) AS MONEY) AS [loan_amount]
, CAST(al.olb * dbo.GetXR(Pack.currency_id, @display_in, @from) AS MONEY) AS [olb]
, Tr.loan_cycle
, Us.first_name + SPACE(1) + Us.last_name AS [loan_admin]
, Pack.name AS [product_name], Pack.code AS [product_code]
, ISNULL(LiGrCr.guarantor, ''-'') AS [guarantor]
, ISNULL(CAST(LiGrCr.guarantee_amount * dbo.GetXR(Pack.currency_id, @display_in, @from) AS MONEY), ''-'') AS [g_amount]
, ISNULL(LiClCr.name, ''-'') AS [collateral]
, ISNULL(CAST(LiClCr.collateral_amount * dbo.GetXR(Pack.currency_id, @display_in, @from) AS MONEY), ''-'') AS [c_amount]
, Cr.grace_period
, Cr.nb_of_installment AS [maturity]
, Cr.interest_rate
, al.late_days
, COALESCE(nsg.name, LoShAm.group_name, ''-'') AS [group_name]
, ISNULL(CAST(LoShAm.loan_share * dbo.GetXR(Pack.currency_id, @display_in, @from) AS MONEY), ''-'') AS [loan_share]
, Br.code AS branch_name
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom1_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom1_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom1_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom1_group), ''-'') 
end AS custom#1
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom2_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom2_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom2_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom2_group), ''-'') 
end AS custom#2
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom3_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom3_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom3_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom3_group), ''-'') 
end AS custom#3
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom4_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom4_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom4_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom4_group), ''-'') 
end AS custom#4
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom5_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom5_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom5_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom5_group), ''-'') 
end AS custom#5
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom6_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom6_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom6_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom6_group), ''-'') 
end AS custom#6
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom7_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom7_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom7_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom7_group), ''-'') 
end AS custom#7
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom8_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom8_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom8_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom8_group), ''-'') 
end AS custom#8
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom9_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom9_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom9_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom9_group), ''-'') 
end AS custom#9
, case 
	when Tr.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom10_person), ''-'') 
	when Tr.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom10_corporate), ''-'') 
	when Tr.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom10_village), ''-'') 
	when Tr.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tr.id, @custom10_group), ''-'') 
end AS custom#10
FROM @active_loans AS al
INNER JOIN dbo.Contracts AS Cont ON Cont.id = al.id
INNER JOIN dbo.Credit AS Cr ON Cr.id = Cont.id
INNER JOIN dbo.Packages AS Pack ON Cr.package_id = Pack.id
INNER JOIN dbo.Users AS Us ON Us.id = Cr.loanofficer_id
LEFT JOIN dbo.Projects AS Pr ON Cont.project_id = Pr.id
LEFT JOIN dbo.Tiers AS Tr ON Tr.id = Pr.tiers_id
LEFT JOIN dbo.Branches Br ON Br.id = Tr.branch_id
LEFT JOIN dbo.Districts AS Dis ON Dis.id = Tr.district_id
LEFT JOIN dbo.Groups AS Gr ON Gr.id = Tr.id
LEFT JOIN dbo.Persons AS Pers ON Pers.id = Tr.id
LEFT JOIN dbo.EconomicActivities AS EcAc ON EcAc.id = Pers.activity_id
LEFT JOIN 
(
	SELECT DISTINCT LiGrCr.contract_id
	, Pr.first_name + SPACE(1) + Pr.last_name AS [guarantor]
	, LiGrCr.guarantee_amount
	FROM LinkGuarantorCredit AS LiGrCr
	INNER JOIN Tiers AS Tr ON Tr.id = LiGrCr.tiers_id
	INNER JOIN Persons AS Pr ON Pr.id = Tr.id
) AS LiGrCr ON LiGrCr.contract_id = Cont.id
LEFT JOIN
(
	SELECT 
	CASE WHEN ISNUMERIC(CollateralPropertyValues.value) = 1 
			THEN CONVERT(MONEY, CollateralPropertyValues.value) 
			ELSE 0 
	END AS collateral_amount
	, CollateralsLinkContracts.contract_id AS [contract_id]
	, CollateralProducts.name AS [name]
	FROM dbo.CollateralsLinkContracts 
	INNER JOIN dbo.CollateralPropertyValues ON CollateralsLinkContracts.id = CollateralPropertyValues.contract_collateral_id
	INNER JOIN dbo.CollateralProperties ON CollateralProperties.id = CollateralPropertyValues.property_id
	INNER JOIN dbo.CollateralProducts ON CollateralProperties.product_id = CollateralProducts.id
	WHERE CollateralProperties.name = ''Amount'' AND CollateralProperties.[type_id] = 1
) AS LiClCr ON LiClCr.contract_id = Cont.id	
LEFT JOIN
(
	SELECT LoShAm.contract_id, LoShAm.person_id, Gr.name AS [group_name], LoShAm.amount AS [loan_share]
	FROM LoanShareAmounts AS LoShAm
	LEFT JOIN Groups AS Gr ON Gr.id = LoShAm.group_id
) AS LoShAm ON LoShAm.person_id = Pers.id
LEFT JOIN Corporates ON Tr.id = Corporates.id
LEFT JOIN dbo.EconomicActivities AS CorporateActivities ON CorporateActivities.id = Corporates.activity_id
LEFT JOIN dbo.Villages nsg ON Cont.nsg_id = nsg.id
WHERE (Pack.currency_id = @disbursed_in OR 0 = @disbursed_in) AND (Tr.branch_id = @branch_id OR @branch_id = 0)
ORDER BY type DESC, district, client_first_name,client_last_name'



declare  @table1 table
(
    id int,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    type nvarchar(MAX),
    district nvarchar(MAX),
    pers_phone nvarchar(MAX),
    s_pers_phone nvarchar(MAX),
    activity nvarchar(MAX),
    sex nvarchar(MAX),
    contract_code nvarchar(MAX),
    start_date datetime,
    close_date datetime,
    loan_amount decimal(18,2),
    olb decimal(18,2),
    loan_cycle int,
    loan_admin nvarchar(MAX),
    product_name nvarchar(MAX),
    product_code nvarchar(MAX),
    guarantor nvarchar(MAX),
    g_amount decimal(18,2),
    collateral nvarchar(MAX),
    c_amount decimal(18,2),
    grace_period int,
    maturity int,
    interest_rate decimal(18,2),
    late_days int,
    group_name nvarchar(MAX),
    loan_share decimal(18,2),
    branch_name nvarchar(MAX),
    custom#1 nvarchar(MAX),
    custom#2 nvarchar(MAX),
    custom#3 nvarchar(MAX),
    custom#4 nvarchar(MAX),
    custom#5 nvarchar(MAX),
    custom#6 nvarchar(MAX),
    custom#7 nvarchar(MAX),
    custom#8 nvarchar(MAX),
    custom#9 nvarchar(MAX),
    custom#10 nvarchar(MAX)
)

declare  @table2 table
(
    id int,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    type nvarchar(MAX),
    district nvarchar(MAX),
    pers_phone nvarchar(MAX),
    s_pers_phone nvarchar(MAX),
    activity nvarchar(MAX),
    sex nvarchar(MAX),
    contract_code nvarchar(MAX),
    start_date datetime,
    close_date datetime,
    loan_amount decimal(18,2),
    olb decimal(18,2),
    loan_cycle int,
    loan_admin nvarchar(MAX),
    product_name nvarchar(MAX),
    product_code nvarchar(MAX),
    guarantor nvarchar(MAX),
    g_amount decimal(18,2),
    collateral nvarchar(MAX),
    c_amount decimal(18,2),
    grace_period int,
    maturity int,
    interest_rate decimal(18,2),
    late_days int,
    group_name nvarchar(MAX),
    loan_share decimal(18,2),
    branch_name nvarchar(MAX),
    custom#1 nvarchar(MAX),
    custom#2 nvarchar(MAX),
    custom#3 nvarchar(MAX),
    custom#4 nvarchar(MAX),
    custom#5 nvarchar(MAX),
    custom#6 nvarchar(MAX),
    custom#7 nvarchar(MAX),
    custom#8 nvarchar(MAX),
    custom#9 nvarchar(MAX),
    custom#10 nvarchar(MAX)
)


use DATABASE_NAME_Source

insert into @table1( id , client_first_name , client_last_name , type , district , pers_phone ,
                    s_pers_phone , activity , sex , contract_code , start_date , close_date ,
                    loan_amount , olb , loan_cycle , loan_admin ,
                    product_name , product_code , guarantor , g_amount , collateral ,
                    c_amount , grace_period , maturity , 
                    interest_rate , late_days , group_name ,
                    loan_share , branch_name , custom#1 ,
                    custom#2 , custom#3 , custom#4 , custom#5 , custom#6 , 
                    custom#7 , custom#8 , custom#9 , custom#10 
                    )
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2( id , client_first_name , client_last_name , type , district , pers_phone ,
                    s_pers_phone , activity , sex , contract_code , start_date , close_date ,
                    loan_amount , olb , loan_cycle , loan_admin ,
                    product_name , product_code , guarantor , g_amount , collateral ,
                    c_amount , grace_period , maturity , 
                    interest_rate , late_days , group_name ,
                    loan_share , branch_name , custom#1 ,
                    custom#2 , custom#3 , custom#4 , custom#5 , custom#6 , 
                    custom#7 , custom#8 , custom#9 , custom#10 
                    )
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on   t1.id                   =t2.id               
                                and t1.client_first_name=t2.client_first_name
                                and t1.client_last_name =t2.client_last_name 
                                and t1.type             =t2.type             
                                and t1.district         =t2.district         
                                and t1.pers_phone       =t2.pers_phone       
                                and t1.s_pers_phone     =t2.s_pers_phone     
                                and t1.activity         =t2.activity         
                                and t1.sex              =t2.sex              
                                and t1.contract_code    =t2.contract_code    
                                and t1.start_date       =t2.start_date       
                                and t1.close_date       =t2.close_date       
                                and t1.loan_amount      =t2.loan_amount      
                                and t1.olb              =t2.olb              
                                and t1.loan_cycle       =t2.loan_cycle       
                                and t1.loan_admin       =t2.loan_admin       
                                and t1.product_name     =t2.product_name     
                                and t1.product_code     =t2.product_code     
                                and t1.guarantor        =t2.guarantor        
                                and t1.g_amount         =t2.g_amount         
                                and t1.collateral       =t2.collateral       
                                and t1.c_amount         =t2.c_amount         
                                and t1.grace_period     =t2.grace_period     
                                and t1.maturity         =t2.maturity         
                                and t1.interest_rate    =t2.interest_rate    
                                and t1.late_days        =t2.late_days        
                                and t1.group_name       =t2.group_name       
                                and t1.loan_share       =t2.loan_share       
                                and t1.branch_name      =t2.branch_name      
                                and t1.custom#1         =t2.custom#1         
                                and t1.custom#2         =t2.custom#2         
                                and t1.custom#3         =t2.custom#3         
                                and t1.custom#4         =t2.custom#4         
                                and t1.custom#5         =t2.custom#5         
                                and t1.custom#6         =t2.custom#6         
                                and t1.custom#7         =t2.custom#7         
                                and t1.custom#8         =t2.custom#8         
                                and t1.custom#9         =t2.custom#9         
                                and t1.custom#10        =t2.custom#10        
where t1.id is null or t2.id is null