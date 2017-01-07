using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.Repository
{
    public interface IAccountRepository
    {
        List<Account> SelectAllAccounts();
        List<Balance> GetBalances(DateTime from, DateTime to, int branchId);
        Balance GetBalance(DateTime date, string accountNumber);
        List<Balance> GetAnalyticBalances(string parentCode, DateTime from, DateTime to, int branchId);
        void Save(Account entity, IDbTransaction tx = null);
        void Update(Account entity, IDbTransaction tx = null);
        void Delete(Account entity, IDbTransaction tx = null);

        void AddAccountsForLoan(
            string portfolioAccount, 
            string interestAccount, 
            string transitAccount, 
            int loanId,
            IDbTransaction tx);

        void DeleteAccounts(int loanId, IDbTransaction tx);
        void DeleteAccount(string accountNumber, IDbTransaction tx);
        void CreateSavingForLaon(int loanId, string code, int userId, DateTime creationDate, IDbTransaction tx);
        bool Exists(Account entity, IDbTransaction tx = null);
    }
}
