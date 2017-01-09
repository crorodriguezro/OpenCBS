using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Accounting.Repository;

namespace OpenCBS.ArchitectureV2.Accounting.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public void SaveAccount(Account entity)
        {
            _accountRepository.Save(entity);
        }

        public void SaveAccount(Account entity, SqlTransaction transaction)
        {
            _accountRepository.Save(entity, transaction);
        }

        public void UpdateAccount(Account entity, SqlTransaction transaction)
        {
            _accountRepository.Update(entity, transaction);
        }

        public void DeleteAccount(Account entity)
        {
            _accountRepository.Delete(entity);
        }

        public IEnumerable<Account> SelectAccounts()
        {
            return _accountRepository.SelectAllAccounts();
        }

        public void AddAccountsForLoan(string portfolioAccount, string interestAccount, string transitAccount,
                                       int loanId,
                                       SqlTransaction transaction)
        {
            _accountRepository.AddAccountsForLoan(portfolioAccount, interestAccount, transitAccount, loanId, transaction);
        }

        public void DeleteAccounts(int loanId, SqlTransaction transaction)
        {
            _accountRepository.DeleteAccounts(loanId, transaction);
        }

        public void DeleteAccount(string accountNumber, SqlTransaction transaction)
        {
            _accountRepository.DeleteAccount(accountNumber, transaction);
        }

        public void CreateSavingForLaon(int loanId, string code, int userId, DateTime creationDate,
                                SqlTransaction transaction)
        {
            _accountRepository.CreateSavingForLaon(loanId, code, userId, creationDate, transaction);
        }
    }
}
