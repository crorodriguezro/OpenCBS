using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.CoreDomain;
using OpenCBS.Manager;

namespace OpenCBS.Services
{
    public class EntryFeeServices : MarshalByRefObject
    {
        private readonly EntryFeeManager _entryFeeManager;
        
        public EntryFeeServices(User user)
        {
            _entryFeeManager = new EntryFeeManager(user);
        }

        public List<EntryFee> GetAllEntryFee(IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;

            try
            {
                var result = _entryFeeManager.GetAllEntryFee(tx);
                return result;
            }
            catch (Exception error)
            {
                throw new Exception("Can't get all entry fee: " + error.Message);
            }
            finally
            {
                if (transaction == null)
                    tx.Rollback();
            }
        }
    }
}