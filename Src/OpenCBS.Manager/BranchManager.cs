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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using OpenCBS.CoreDomain;

namespace OpenCBS.Manager
{
    public class BranchManager : Manager
    {
        private static List<Branch> _cache;

        public BranchManager(User user)
            : base(user)
        {
            InitCache();
        }

        public BranchManager(string pTestDb)
            : base(pTestDb)
        {
            InitCache();
        }


        private void InitCache()
        {
            if (_cache == null) _cache = GetCache();
        }

        public void RefreshCache()
        {
            _cache = GetCache();
        }
        private List<Branch> GetCache()
        {
            List<Branch> branches = new List<Branch>();
            const string q =
                @"SELECT 
                    id, 
                    name, 
                    deleted
                    , code, address, description
            FROM dbo.Branches";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            using (OpenCbsReader r = c.ExecuteReader())
            {
                if (r.Empty) return branches;

                while (r.Read())
                {
                    var b = new Branch
                    {
                        Id = r.GetInt("id"),
                        Name = r.GetString("name"),
                        Deleted = r.GetBool("deleted"),
                        Code = r.GetString("code"),
                        Address = r.GetString("address"),
                        Description = r.GetString("description")
                    };
                    branches.Add(b);
                }
            }
            return branches;
        }

        public List<Branch> SelectAll()
        {
            return _cache;
        }

        public List<Branch> SelectAllWithVault()
        {
            List<Branch> branches = new List<Branch>();
            const string q =
                @"SELECT 
                    id, 
                    name, 
                    deleted, 
                    code,
                    address,
                    description
                    FROM dbo.Branches
                    WHERE id IN (SELECT branch_id FROM Tellers WHERE user_id = 0 AND deleted = 0)";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            using (OpenCbsReader r = c.ExecuteReader())
            {
                if (r.Empty) return branches;

                while (r.Read())
                {
                    Branch b = new Branch
                    {
                        Id = r.GetInt("id"),
                        Name = r.GetString("name"),
                        Deleted = r.GetBool("deleted"),
                        Code = r.GetString("code"),
                        Address = r.GetString("address"),
                        Description = r.GetString("description")
                    };
                    branches.Add(b);
                }
            }
            return branches;
        }

        public Branch Add(Branch branch, SqlTransaction t)
        {
            const string q = @"INSERT INTO dbo.Branches
                              (name, code, address, description)
                              VALUES (@name, @code, @address, @description)
                              SELECT SCOPE_IDENTITY()";
            using (OpenCbsCommand c = new OpenCbsCommand(q, t.Connection, t))
            {
                c.AddParam("@name", branch.Name);
                c.AddParam("@code", branch.Code);
                c.AddParam("@address", branch.Address);
                c.AddParam("@description", branch.Description);
                branch.Id = Convert.ToInt32(c.ExecuteScalar());
                //RefreshCache();
                return branch;
            }



        }

        public void Update(Branch branch, SqlTransaction t)
        {
            const string q = @"UPDATE dbo.Branches
                                SET name = @name
                                , code = @code
                                , description = @description
                                , address = @address
                                WHERE id = @id";
            using (OpenCbsCommand c = new OpenCbsCommand(q, t.Connection, t))
            {
                c.AddParam("@id", branch.Id);
                c.AddParam("@name", branch.Name);
                c.AddParam("@code", branch.Code);
                c.AddParam("@description", branch.Description);
                c.AddParam("@address", branch.Address);
                c.ExecuteNonQuery();

                //RefreshCache();
            }
        }

        public void Delete(int id)
        {
            const string q = @"UPDATE dbo.Branches
            SET deleted = 1 WHERE id = @id";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@id", id);
                c.ExecuteNonQuery();

                RefreshCache();
            }
        }

        public bool NameExists(int id, string name)
        {
            return _cache.Any(val => val.Name == name && val.Id != id);
        }

        public bool CodeExists(int id, string code)
        {
            return _cache.Any(val => val.Id != id && val.Code == code);
        }

        public string GetBranchCodeByClientId(int clientId)
        {
            const string q = @"SELECT Branches.code FROM Tiers
                         INNER JOIN Branches ON Branches.id = Tiers.branch_id
                         WHERE Tiers.id = @id";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@id", clientId);
                string code = string.Empty;
                using (OpenCbsReader r = c.ExecuteReader())
                {
                    if (r.Empty) return null;
                    if (r.Read())
                        code = r.GetString("code");
                }
                return code;
            }
        }

        public string GetBranchCodeByClientId(int clientId, SqlTransaction sqlTransaction)
        {
            const string sqlText = @"SELECT Branches.code   
                                    FROM Tiers
                                    INNER JOIN Branches ON Branches.id = Tiers.branch_id
                                    WHERE Tiers.id = @id";
            OpenCbsCommand c = new OpenCbsCommand(sqlText, sqlTransaction.Connection, sqlTransaction);
            {
                c.AddParam("@id", clientId);
                string code = string.Empty;
                using (OpenCbsReader r = c.ExecuteReader())
                {
                    if (r.Empty) return null;
                    if (r.Read())
                        code = r.GetString("code");
                }
                return code;
            }
        }

        public Branch Select(int branchId)
        {
            return _cache.FirstOrDefault(val => val.Id == branchId);
        }

        public Branch SelectBranchByName(string name)
        {
            return _cache.FirstOrDefault(val => val.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
