// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System.Collections.Generic;
using OpenCBS.CoreDomain;
using System.Data.SqlClient;
using System.Linq;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.Manager.Accounting;

namespace OpenCBS.Manager
{
    public class PaymentMethodManager : Manager
    {
        private static List<PaymentMethod> _cacheWithBranch;
        private static List<PaymentMethod> _cacheWithoutBranch;
        private readonly BranchManager _branchManager;

        public PaymentMethodManager(User user) : base(user)
        {
            _branchManager = new BranchManager(user);
            InitCache();
        }

        public PaymentMethodManager(string testDb) : base(testDb)
        {
            _branchManager = new BranchManager(testDb);
            InitCache();
        }

        public PaymentMethodManager(string testDb, User user) : base(testDb)
        {
            InitCache();
        }

        private void InitCache()
        {
            if (_cacheWithBranch == null)
                _cacheWithBranch = GetPaymentMethodOfBranch();
            if (_cacheWithoutBranch == null)
                _cacheWithoutBranch = GetPaymentMethodsWithoutBranch();
        }

        public List<PaymentMethod> SelectPaymentMethods()
        {
            return _cacheWithoutBranch;
        }

        public void RefreshCache()
        {
            _cacheWithBranch = GetPaymentMethodOfBranch();
            _cacheWithoutBranch = GetPaymentMethodsWithoutBranch();
        }
        public List<PaymentMethod> GetPaymentMethodsWithoutBranch()
        {
            string q = @"SELECT pm.[id]
                                  ,[name]
                                  ,[description]
                                  ,[pending]
                            FROM [PaymentMethods] pm
                            ORDER BY pm.[id]";

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            using (OpenCbsReader r = c.ExecuteReader())
            {
                if (r != null && !r.Empty)
                    while (r.Read())
                    {
                        PaymentMethod paymentMethod = new PaymentMethod
                        {
                            Id = r.GetInt("id"),
                            Name = r.GetString("name"),
                            Description = r.GetString("description"),
                            IsPending = r.GetBool("pending"),
                        };
                        paymentMethods.Add(paymentMethod);
                    }
            }
            return paymentMethods;
        }

        public List<PaymentMethod> SelectPaymentMethodsForClosure()
        {
            return _cacheWithBranch;
        }

        public List<PaymentMethod> GetPaymentMethodOfBranch()
        {
            string q = @"SELECT [lbpm].[payment_method_id], 
                                [lbpm].[id], 
                                [pm].[name], 
                                [pm].[description], 
                                [pm].[pending], 
                                [lbpm].[branch_id], 
                                [lbpm].[date]
                         FROM PaymentMethods pm
                         INNER JOIN LinkBranchesPaymentMethods lbpm ON lbpm.payment_method_id = pm.id
                         WHERE [lbpm].[deleted] = 0";

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                //c.AddParam("@id", branchId);
                using (OpenCbsReader r = c.ExecuteReader())
                {
                    if (r.Empty) return paymentMethods;
                    while (r.Read())
                    {
                        PaymentMethod paymentMethod = new PaymentMethod
                        {
                            Id = r.GetInt("payment_method_id"),
                            Name = r.GetString("name"),
                            Description = r.GetString("description"),
                            IsPending = r.GetBool("pending"),
                            LinkId = r.GetInt("id"),
                            Branch = _branchManager.Select(r.GetInt("branch_id")),
                            Date = r.GetDateTime("date"),
                        };
                        paymentMethods.Add(paymentMethod);
                    }
                }
            }
            return paymentMethods;
        }

        public List<PaymentMethod> SelectPaymentMethodOfBranch(int branchId)
        {
            return _cacheWithBranch.Where(val => val.Branch.Id == branchId).ToList();
        }

        public PaymentMethod SelectPaymentMethodById(int paymentMethodId)
        {
            return _cacheWithoutBranch.Find(pm2 => pm2.Id == paymentMethodId);
        }

        public PaymentMethod SelectPaymentMethodByName(string name)
        {
            return _cacheWithoutBranch.FirstOrDefault(val => val.Name == name);
        }

        public void AddPaymentMethodToBranch(PaymentMethod paymentMethod)
        {
            const string q =
                @"INSERT INTO LinkBranchesPaymentMethods (branch_id, payment_method_id)
                                            VALUES (@branch_id, @payment_method_id)";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@branch_id", paymentMethod.Branch.Id);
                c.AddParam("@payment_method_id", paymentMethod.Id);
                c.ExecuteNonQuery();
                RefreshCache();
            }
        }

        public void DeletePaymentMethodFromBranch(PaymentMethod paymentMethod)
        {
            const string q =
                @"UPDATE LinkBranchesPaymentMethods SET deleted = 1
                                     WHERE id = @link_id";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@link_id", paymentMethod.LinkId);
                c.ExecuteNonQuery();
                RefreshCache();
            }
        }

        public void UpdatePaymentMethodFromBranch(PaymentMethod paymentMethod)
        {
            const string q =
                @"UPDATE LinkBranchesPaymentMethods SET payment_method_id = @payment_method_id
                                    WHERE id = @id";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@payment_method_id", paymentMethod.Id);
                c.AddParam("@id", paymentMethod.LinkId);
                c.ExecuteNonQuery();
                RefreshCache();
            }
        }
    }
}
