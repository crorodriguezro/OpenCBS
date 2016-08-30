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
DECLARE @custom10_group int = (select field_id FROM @advanced_fields_group WHERE id = 10);
	
with temp as

(
	select
		p.id,
		isnull(v.name, '''') village_name
	from
		dbo.Persons p
	left join
		dbo.VillagesPersons vp on vp.person_id = p.id
	left join
		dbo.Villages v on v.id = vp.village_id 
),
people_with_village_bank_names as
(
	select 
		a.id,
		village_name =
			stuff((
				select 
					'', '' + village_name
				from 
					temp b
				where
					b.id = a.id
				for xml path('''')
			), 1, 1, '''')
	from 
		temp a
	group by
		a.id
)

select distinct
	pvb.id,
	p.first_name,
	p.last_name,
	Tiers.client_type_code AS type,
	Districts.name as district_name,
	Tiers.personal_phone as first_personal_phone,
	[Tiers].[secondary_personal_phone] AS sec_pers_phone,
	 EA.name as activity,
    p.sex as sex,
	pvb.village_name,
	[Branches].[code] AS branch_name
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom1_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom1_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom1_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom1_group), ''-'') 
	end AS custom#1
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom2_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom2_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom2_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom2_group), ''-'') 
	end AS custom#2
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom3_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom3_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom3_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom3_group), ''-'') 
	end AS custom#3
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom4_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom4_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom4_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom4_group), ''-'') 
	end AS custom#4
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom5_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom5_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom5_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom5_group), ''-'') 
	end AS custom#5
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom6_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom6_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom6_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom6_group), ''-'') 
	end AS custom#6
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom7_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom7_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom7_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom7_group), ''-'') 
	end AS custom#7
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom8_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom8_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom8_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom8_group), ''-'') 
	end AS custom#8
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom9_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom9_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom9_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom9_group), ''-'') 
	end AS custom#9
	, case 
		when Tiers.client_type_code = ''I'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom10_person), ''-'') 
		when Tiers.client_type_code = ''C'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom10_corporate), ''-'') 
		when Tiers.client_type_code = ''V'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom10_village), ''-'') 
		when Tiers.client_type_code = ''G'' then ISNULL(dbo.GetAdvancedFieldValue(Tiers.id, @custom10_group), ''-'') 
	end AS custom#10
from
	people_with_village_bank_names pvb
    left join
	dbo.Persons p on p.id = pvb.id
	left join
	[dbo].[Tiers] ON p.id = [Tiers].[id] 
	LEFT JOIN
	[dbo].[Districts] ON [Districts].[id] = [Tiers].[district_id] LEFT JOIN
	[dbo].[Branches] ON [Branches].[id] = [Tiers].[branch_id] LEFT JOIN
	EconomicActivities EA ON [EA].[id] = p.[activity_id] LEFT JOIN
	[dbo].[VillagesPersons] VP ON p.id = VP.person_id left JOIN
	 [dbo].[PersonGroupBelonging] PGB ON p.[id] = PGB.person_id LEFT JOIN
    [dbo].[Groups] ON [Groups].[id] = PGB.group_id LEFT JOIN
    [dbo].[Villages] ON [Villages].[id] = VP.[village_id]  inner join
	(
        SELECT [Persons].[id]
        FROM [dbo].[Persons] 
            EXCEPT --(Кроме результатов 2-го запроса)
        SELECT [ActiveClients].[id] 
        FROM ActiveClients(@from,@branch_id)
    ) Temp ON [Temp].[id] = p.id
	 where Tiers.id = @branch_id OR @branch_id = 0
	ORDER BY p.last_name'



    

declare  @table1 table
(
    id int,
    first_name nvarchar(MAX),
    last_name nvarchar(MAX),
    type nvarchar(MAX),
    district_name nvarchar(MAX),
    first_personal_phone nvarchar(MAX),
    sec_pers_phone nvarchar(MAX),
    activity nvarchar(MAX),
    sex nvarchar(MAX),
    village_name nvarchar(MAX),
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
    first_name nvarchar(MAX),
    last_name nvarchar(MAX),
    type nvarchar(MAX),
    district_name nvarchar(MAX),
    first_personal_phone nvarchar(MAX),
    sec_pers_phone nvarchar(MAX),
    activity nvarchar(MAX),
    sex nvarchar(MAX),
    village_name nvarchar(MAX),
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

insert into @table1( id , first_name , last_name , type , district_name , first_personal_phone ,
                    sec_pers_phone , activity , sex ,village_name, branch_name , custom#1 ,
                    custom#2 , custom#3 , custom#4 , custom#5 , custom#6 , 
                    custom#7 , custom#8 , custom#9 , custom#10 
                    )
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2( id , first_name , last_name , type , district_name , first_personal_phone ,
                    sec_pers_phone , activity , sex ,village_name, branch_name , custom#1 ,
                    custom#2 , custom#3 , custom#4 , custom#5 , custom#6 , 
                    custom#7 , custom#8 , custom#9 , custom#10 
                    )
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on   t1.id                       =t2.id               
                                and t1.first_name           =t2.first_name
                                and t1.last_name            =t2.last_name 
                                and t1.type                 =t2.type             
                                and t1.district_name        =t2.district_name         
                                and t1.first_personal_phone =t2.first_personal_phone       
                                and t1.sec_pers_phone       =t2.sec_pers_phone     
                                and t1.activity             =t2.activity         
                                and t1.sex                  =t2.sex   
                                and t1.village_name         =t2.village_name       
                                and t1.branch_name          =t2.branch_name      
                                and t1.custom#1             =t2.custom#1         
                                and t1.custom#2             =t2.custom#2         
                                and t1.custom#3             =t2.custom#3         
                                and t1.custom#4             =t2.custom#4         
                                and t1.custom#5             =t2.custom#5         
                                and t1.custom#6             =t2.custom#6         
                                and t1.custom#7             =t2.custom#7         
                                and t1.custom#8             =t2.custom#8         
                                and t1.custom#9             =t2.custom#9         
                                and t1.custom#10            =t2.custom#10        
where t1.id is null or t2.id is null

