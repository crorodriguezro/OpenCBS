using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Service
{
    public interface IAccountService
    {
        void SaveAccount(Account entity);
        void SaveAccount(Account entity, SqlTransaction transaction);
        void UpdateAccount(Account entity, SqlTransaction transaction);
        void DeleteAccount(Account entity);
        IEnumerable<Account> SelectAccounts();
        void AddAccountsForLoan(string portfolioAccount, string interestAccount, string transitAccount, int loanId,
                                SqlTransaction transaction);
        void DeleteAccounts(int loanId, SqlTransaction transaction);
        void CreateSavingForLaon(int loanId, string code, int userId, DateTime creationDate, SqlTransaction transaction);
    }
}
