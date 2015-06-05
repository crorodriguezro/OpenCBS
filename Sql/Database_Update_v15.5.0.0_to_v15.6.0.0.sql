UPDATE  [TechnicalParameters]
SET     [value] = 'v15.6.0.0'
WHERE   [name] = 'VERSION'
GO

ALTER TABLE [dbo].[Persons] DROP CONSTRAINT 
 [FK_Persons_Banks]
,[FK_Persons_Banks1]
,[DF_Credit_handicapped]
,[DF_Persons_povertylevel_childreneducation]
,[DF_Persons_povertylevel_socialparticipation]
,[DF_Persons_povertylevel_healthsituation]
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
GO