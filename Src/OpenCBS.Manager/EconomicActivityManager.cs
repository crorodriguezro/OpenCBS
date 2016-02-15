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
using OpenCBS.CoreDomain.EconomicActivities;

namespace OpenCBS.Manager
{
    /// <summary>
    /// Summary description for EconomicActivityManager.
    /// </summary>
    public class EconomicActivityManager : Manager
    {
        private static List<EconomicActivity> _cacheEconomicActivities;
        private static List<EconomicActivity> _cacheLoanPurposes;

        public EconomicActivityManager(string testDB) : base(testDB)
        {
            InitCache();
        }

        public EconomicActivityManager(User pUser) : base(pUser)
        {
            InitCache();
        }

        private void InitCache()
        {
            if (_cacheEconomicActivities == null) _cacheEconomicActivities = GetCasheEconomicActivities();
            if (_cacheLoanPurposes == null) _cacheLoanPurposes = GetCacheLoanPurposes();
        }

        private List<EconomicActivity> GetCasheEconomicActivities()
        {
            List<EconomicActivity> doaList = new List<EconomicActivity>();

            const string sqlText =
                "SELECT id,name,deleted,parent_id FROM EconomicActivities WHERE deleted = 0";

            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand selectAll = new OpenCbsCommand(sqlText, connection))
            {
                using (OpenCbsReader reader = selectAll.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EconomicActivity domain = new EconomicActivity
                        {
                            Id = reader.GetInt("id"),
                            Name = reader.GetString("name"),
                            ParentId = reader.GetNullInt("parent_id")
                        };
                        doaList.Add(domain);
                    }
                }
            }

            foreach (var economicActivity in doaList)
            {
                economicActivity.Parent = doaList.FirstOrDefault(val => val.Id == economicActivity.ParentId);
                economicActivity.Childrens = doaList.Where(val => economicActivity.Id == val.ParentId).ToList();
            }

            return doaList.ToList();
        }

        public List<EconomicActivity> GetCacheLoanPurposes()
        {
            List<EconomicActivity> list = new List<EconomicActivity>();

            const string sql = @"
                select 
                    id,
					name,
					deleted
                from
                    dbo.LoanPurpose
                where
                    parent_id is null
                    and deleted = 0
            ";

            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand selectAll = new OpenCbsCommand(sql, connection))
            {
                using (OpenCbsReader reader = selectAll.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EconomicActivity domain = new EconomicActivity
                        {
                            Id = reader.GetInt("id"),
                            Name = reader.GetString("name"),
                            Deleted = reader.GetBool("deleted")
                        };
                        list.Add(domain);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Add an economic activity in database
        /// </summary>
        /// <param name="pEconomicActivity">the economic activity object to add</param>
        /// <returns>the id of the economic activity added</returns>
        public int AddEconomicActivity(EconomicActivity pEconomicActivity)
        {
            const string sqlText = @"INSERT INTO EconomicActivities ([name] , [parent_id] , [deleted]) 
                        VALUES (@name,@parentId,@deleted) SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand insert = new OpenCbsCommand(sqlText, connection))
            {
                insert.AddParam("@name", pEconomicActivity.Name);
                insert.AddParam("@deleted", pEconomicActivity.Deleted);
                if (pEconomicActivity.Parent != null)
                    insert.AddParam("@parentId", pEconomicActivity.Parent.Id);
                else
                    insert.AddParam("@parentId", null);
                return int.Parse(insert.ExecuteScalar().ToString());
            }
        }

        public int AddEconomicActivity(EconomicActivity loanPurpose, bool isLoanPurpose)
        {
            string sqlText = "";

            if (isLoanPurpose)
            {
                sqlText = @"INSERT INTO LoanPurpose ([name] , [parent_id] , [deleted]) 
                        VALUES (@name,@parentId,@deleted) SELECT SCOPE_IDENTITY()";
            }
            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand insert = new OpenCbsCommand(sqlText, connection))
            {
                insert.AddParam("@name", loanPurpose.Name);
                insert.AddParam("@deleted", loanPurpose.Deleted);
                if (loanPurpose.Parent != null)
                    insert.AddParam("@parentId", loanPurpose.Parent.Id);
                else
                    insert.AddParam("@parentId", null);
                return int.Parse(insert.ExecuteScalar().ToString());
            }

        }

        /// <summary>
        /// This methods allows us to find all domains of application
        /// </summary>
        /// <returns>hierarchic collection of DomainOfApplication
        /// </returns>
        public List<EconomicActivity> SelectAllEconomicActivities()
        {
            return _cacheEconomicActivities;
        }

        public List<EconomicActivity> SelectAllLoanPurposes()
        {
            return _cacheLoanPurposes;
        }

        /// <summary>
        /// Update economic activity name and delete
        /// </summary>
        /// <param name="pEconomicActivity">EconomicActivity object</param>
        public void UpdateEconomicActivity(EconomicActivity pEconomicActivity)
        {
            const string sqlText = "UPDATE EconomicActivities SET name = @name,deleted = @wasDeleted WHERE id = @id";

            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand update = new OpenCbsCommand(sqlText, connection))
            {
                update.AddParam("@id", pEconomicActivity.Id);
                update.AddParam("@name", pEconomicActivity.Name);
                update.AddParam("@wasDeleted", pEconomicActivity.Deleted);
                update.ExecuteNonQuery();
            }
        }

        public void UpdateEconomicActivity(EconomicActivity pEconomicActivity, bool isLoanPurpose)
        {
            const string sqlText = "UPDATE LoanPurpose SET name = @name,deleted = @wasDeleted WHERE id = @id";

            using (SqlConnection connection = GetConnection())
            using (OpenCbsCommand update = new OpenCbsCommand(sqlText, connection))
            {
                update.AddParam("@id", pEconomicActivity.Id);
                update.AddParam("@name", pEconomicActivity.Name);
                update.AddParam("@wasDeleted", pEconomicActivity.Deleted);
                update.ExecuteNonQuery();
            }
        }

        private List<EconomicActivity> SelectChildren(int pParentId)
        {
            return _cacheEconomicActivities.Where(val => val.Parent.Id == pParentId).ToList();
        }

        private List<EconomicActivity> SelectLPChildren(int pParentId)
        {
            return _cacheLoanPurposes.Where(val => val.Parent.Id == pParentId).ToList();
        }

        public bool ThisActivityAlreadyExist(string pName, int pParentId)
        {
            return _cacheEconomicActivities.Any(val => val.Parent.Id == pParentId && val.Name == pName);
        }

        public bool ThisActivityAlreadyExist(string pName, int pParentId, bool isLoanPurpose)
        {
            return isLoanPurpose
                ? _cacheLoanPurposes.Any(val => val.Parent.Id == pParentId && val.Name == pName)
                : ThisActivityAlreadyExist(pName, pParentId);
        }

        /// <summary>
        /// This methods allows us to find a economic activity.
        /// We use recursive method to find parent
        /// </summary>
        /// <param name="id">the id searched</param>
        /// <returns>DomainOfApplication object</returns>
        public EconomicActivity SelectEconomicActivity(int pId)
        {
            return _cacheEconomicActivities.FirstOrDefault(val => val.Id == pId);
        }

        public EconomicActivity SelectLoanPurpose(int pId)
        {
            return _cacheLoanPurposes.FirstOrDefault(val => val.Id == pId);
        }

        private static EconomicActivity GetEconomicActivity(OpenCbsReader pReader)
        {
            EconomicActivity doa = new EconomicActivity();
            if (pReader != null)
            {
                if (!pReader.Empty)
                {
                    pReader.Read();
                    doa.Id = pReader.GetInt("id");
                    doa.Name = pReader.GetString("name");
                    doa.Deleted = pReader.GetBool("deleted");
                }
            }
            return doa;
        }

        public EconomicActivity SelectEconomicActivity(string pName)
        {
            return _cacheEconomicActivities.FirstOrDefault(val => val.Name == pName);
        }

        public void AddEconomicActivityLoanHistory(EconomicActivityLoanHistory activityLoanHistory,
            SqlTransaction sqlTransaction)
        {
            const string sqlText = @"INSERT INTO EconomicActivityLoanHistory 
                                    ([contract_id],[person_id],[group_id],[economic_activity_id],[deleted]) 
                                    VALUES (@contract_id, @person_id, @group_id, @economic_activity_id, @deleted)";

            using (OpenCbsCommand insert = new OpenCbsCommand(sqlText, sqlTransaction.Connection, sqlTransaction))
            {
                insert.AddParam("@contract_id", activityLoanHistory.Contract.Id);
                insert.AddParam("@person_id", activityLoanHistory.Person.Id);
                if (activityLoanHistory.Group != null)
                    insert.AddParam("@group_id", activityLoanHistory.Group.Id);
                else
                    insert.AddParam("@group_id", null);
                insert.AddParam("@economic_activity_id", activityLoanHistory.EconomicActivity.Id);
                insert.AddParam("@deleted", activityLoanHistory.Deleted);

                insert.ExecuteNonQuery();
            }
        }

        public void UpdateDeletedEconomicActivityLoanHistory(int contractId, int personId, int economicActivityId,
            SqlTransaction sqlTransaction, bool deleted)
        {
            const string sqlText = @"UPDATE EconomicActivityLoanHistory 
                                    SET deleted = @deleted, economic_activity_id = @economic_activity_id 
                                    WHERE contract_id = @contract_id AND person_id = @person_id";

            using (OpenCbsCommand update = new OpenCbsCommand(sqlText, sqlTransaction.Connection, sqlTransaction))
            {
                update.AddParam("@contract_id", contractId);
                update.AddParam("@person_id", personId);
                update.AddParam("@economic_activity_id", economicActivityId);
                update.AddParam("@deleted", deleted);
                update.ExecuteNonQuery();
            }
        }

        public bool EconomicActivityLoanHistoryExists(int contractId, int personId, SqlTransaction sqlTransaction)
        {

            int id = 0;
            const string sqlText = @"SELECT contract_id, person_id, group_id, economic_activity_id, deleted 
                                     FROM EconomicActivityLoanHistory 
                                     WHERE contract_id = @contract_id AND person_id = @person_id ";

            using (OpenCbsCommand sqlCommand = new OpenCbsCommand(sqlText, sqlTransaction.Connection, sqlTransaction))
            {
                sqlCommand.AddParam("@contract_id", contractId);
                sqlCommand.AddParam("@person_id", personId);

                using (OpenCbsReader reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Empty)
                    {
                        reader.Read();
                        id = reader.GetInt("contract_id");
                    }
                }
            }
            return id != 0;
        }

        public bool EconomicActivityLoanHistoryDeleted(int contractId, int personId, SqlTransaction sqlTransaction)
        {
            int id = 0;
            const string sqlText = @"SELECT contract_id, person_id, group_id, economic_activity_id, deleted 
                                     FROM EconomicActivityLoanHistory 
                                     WHERE contract_id = @contract_id AND person_id = @person_id AND deleted = 1";

            using (OpenCbsCommand sqlCommand = new OpenCbsCommand(sqlText, sqlTransaction.Connection, sqlTransaction))
            {
                sqlCommand.AddParam("@contract_id", contractId);
                sqlCommand.AddParam("@person_id", personId);

                using (OpenCbsReader reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Empty)
                    {
                        reader.Read();
                        id = reader.GetInt("contract_id");
                    }
                }
            }
            return id != 0;
        }
    }
}
