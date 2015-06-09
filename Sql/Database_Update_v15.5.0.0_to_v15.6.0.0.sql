if object_id('FK_Persons_Banks') is not null
alter table dbo.Persons drop constraint FK_Persons_Banks
GO

if object_id('FK_Persons_Banks1') is not null
alter table dbo.Persons drop constraint FK_Persons_Banks1
GO

if object_id('DF_Credit_handicapped') is not null
alter table dbo.Persons drop constraint DF_Credit_handicapped
GO

if object_id('DF_Persons_povertylevel_childreneducation') is not null
alter table dbo.Persons drop constraint DF_Persons_povertylevel_childreneducation
GO

if object_id('DF_Persons_povertylevel_socialparticipation') is not null
alter table dbo.Persons drop constraint DF_Persons_povertylevel_socialparticipation
GO

if object_id('DF_Persons_povertylevel_healthsituation') is not null
alter table dbo.Persons drop constraint DF_Persons_povertylevel_healthsituation
GO

if object_id('DF_Persons_povertylevel_economiceducation') is not null
alter table dbo.Persons drop constraint DF_Persons_povertylevel_economiceducation
GO

ALTER TABLE Persons DROP COLUMN 
  household_head
, nb_of_dependents
, nb_of_children
, children_basic_education
, livestock_number
, livestock_type
, landplot_size
, home_size
, home_time_living_in
, capital_other_equipments
, experience
, nb_of_people
, monthly_income
, monthly_expenditure
, comments
, study_level
, SS
, CAF
, housing_situation
, bank_situation
, handicapped
, professional_experience
, first_contact
, family_situation
, mother_name
, povertylevel_childreneducation
, povertylevel_socialparticipation
, povertylevel_healthsituation
, unemployment_months
, personalBank_id
, businessBank_id
, professional_situation
, povertylevel_economiceducation
, first_appointment
GO

delete from 
	dbo.GeneralParameters
where 
	[key] = 'ACCOUNTING_EXPORT_MODE'
	or [key] = 'ACCUMULATED_PENALTY'
	or [key] = 'BRANCH_ADDRESS'
	or [key] = 'BRANCH_CODE'
	or [key] = 'BRANCH_NAME'
	or [key] = 'CONSOLIDATION_MODE'
	or [key] = 'PENDING_REPAYMENT_MODE'
	or [key] = 'REPAYMENT_COMMENT_MANDATORY'
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.6.0.0'
WHERE   [name] = 'VERSION'
GO
