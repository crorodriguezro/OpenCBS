UPDATE  [TechnicalParameters]
SET     [value] = 'v16.11.0.0'
WHERE   [name] = 'VERSION'
GO


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SavingsAc__excha__7BD380F3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [DF__SavingsAc__excha__7BD380F3]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SavingsAc__rule___7CC7A52C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [DF__SavingsAc__rule___7CC7A52C]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ManualAcc__excha__3E3DF86B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [DF__ManualAcc__excha__3E3DF86B]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__LoanAccou__excha__7802F00F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [DF__LoanAccou__excha__7802F00F]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__LoanAccou__rule___78F71448]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [DF__LoanAccou__rule___78F71448]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__LoanAccou__booki__69E7707F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [DF__LoanAccou__booki__69E7707F]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ChartOfAcc__type__63FBF762]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [DF__ChartOfAcc__type__63FBF762]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ChartOfAcco__lft__48867CB4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [DF__ChartOfAcco__lft__48867CB4]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ChartOfAcco__rgt__497AA0ED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [DF__ChartOfAcco__rgt__497AA0ED]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Accountin__delet__0E79DF0E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [DF__Accountin__delet__0E79DF0E]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Accountin__booki__475FB8B4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [DF__Accountin__booki__475FB8B4]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Accountin__order__7DBBC965]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [DF__Accountin__order__7DBBC965]
END
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Accountin__is_de__53F82F60]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AccountingClosure] DROP CONSTRAINT [DF__Accountin__is_de__53F82F60]
END
GO



IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LinkBranchesPaymentMethods_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkBranchesPaymentMethods]'))
ALTER TABLE [dbo].[LinkBranchesPaymentMethods] DROP CONSTRAINT [FK_LinkBranchesPaymentMethods_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanAccountingMovements]'))
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts]
GO
IF  
EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanAccountingMovements]'))
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ManualAccountingMovements]'))
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ManualAccountingMovements]'))
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[SavingsAccountingMovements]'))
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[SavingsAccountingMovements]'))
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[StandardBookings]'))
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StandardBookings]'))
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LinkBranchesPaymentMethods_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkBranchesPaymentMethods]'))
ALTER TABLE [dbo].[LinkBranchesPaymentMethods] DROP CONSTRAINT [FK_LinkBranchesPaymentMethods_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanAccountingMovements]'))
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanAccountingMovements]'))
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ManualAccountingMovements]'))
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ManualAccountingMovements]'))
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tellers_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tellers]'))
ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[SavingsAccountingMovements]'))
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[SavingsAccountingMovements]'))
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[StandardBookings]'))
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StandardBookings]'))
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ChartOfAccounts_AccountsCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[ChartOfAccounts]'))
ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [FK_ChartOfAccounts_AccountsCategory]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_EventAttributes]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventAttributes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_EventTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventTypes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts1]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_EventAttributes]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventAttributes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AccountingRules_EventTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountingRules]'))
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventTypes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_AccountingRules]') AND parent_object_id = OBJECT_ID(N'[dbo].[FundingLineAccountingRules]'))
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_FundingLine]') AND parent_object_id = OBJECT_ID(N'[dbo].[FundingLineAccountingRules]'))
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_FundingLine]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_AccountingRules]') AND parent_object_id = OBJECT_ID(N'[dbo].[FundingLineAccountingRules]'))
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_FundingLine]') AND parent_object_id = OBJECT_ID(N'[dbo].[FundingLineAccountingRules]'))
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_FundingLine]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_AccountingRules]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_AccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_DomainOfApplications]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_Packages]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_Packages]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_SavingProducts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_SavingProducts]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_AccountingRules]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_AccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_DomainOfApplications]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_Packages]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_Packages]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_SavingProducts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]'))
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_SavingProducts]
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountingClosure]') AND type in (N'U'))
DROP TABLE [dbo].[AccountingClosure]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContractAccountingRules]') AND type in (N'U'))
DROP TABLE [dbo].[ContractAccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SavingsAccountingMovements]') AND type in (N'U'))
DROP TABLE [dbo].[SavingsAccountingMovements]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ManualAccountingMovements]') AND type in (N'U'))
DROP TABLE [dbo].[ManualAccountingMovements]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoanAccountingMovements]') AND type in (N'U'))
DROP TABLE [dbo].[LoanAccountingMovements]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FiscalYear]') AND type in (N'U'))
DROP TABLE [dbo].[FiscalYear]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChartOfAccounts]') AND type in (N'U'))
DROP TABLE [dbo].[ChartOfAccounts]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountsCategory]') AND type in (N'U'))
DROP TABLE [dbo].[AccountsCategory]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountingRules]') AND type in (N'U'))
DROP TABLE [dbo].[AccountingRules]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FundingLineAccountingRules]') AND type in (N'U'))
DROP TABLE [dbo].[FundingLineAccountingRules]
GO
