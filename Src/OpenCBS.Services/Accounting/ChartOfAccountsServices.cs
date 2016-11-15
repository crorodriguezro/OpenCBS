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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OpenCBS.DatabaseConnection;
using OpenCBS.ExceptionsHandler.Exceptions.AccountExceptions;
using OpenCBS.Manager;
using OpenCBS.Manager.Accounting;
using OpenCBS.CoreDomain;
using OpenCBS.ExceptionsHandler;
using OpenCBS.Shared;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.Manager.Currencies;
using System.Linq;

namespace OpenCBS.Services.Accounting
{
	/// <summary>
	/// Summary description for ChartOfAccountsServices.
	/// </summary>
    public class ChartOfAccountsServices : BaseServices
	{
        private User _user = new User();
	    private readonly TellerManager _tellerManager;
        private readonly ProvisioningRuleManager _provisionningRuleManager;
        private readonly LoanScaleManager _loanScaleManager;
        private readonly CurrencyManager _currencyManager;

	    public ChartOfAccountsServices(User pUser)
        {
            _user = pUser;
            _tellerManager = new TellerManager(pUser);
            _provisionningRuleManager = new ProvisioningRuleManager(pUser);
            _loanScaleManager = new LoanScaleManager(pUser);
            _currencyManager = new CurrencyManager(pUser);
        }

		public void AddProvisioningRate(ProvisioningRate pR)
		{
            ProvisionTable pT = ProvisionTable.GetInstance(_user);
		
            pR.Number = pT.ProvisioningRates.Count + 1;
			pT.Add(pR);
            using (SqlConnection conn = _provisionningRuleManager.GetConnection())
            using (SqlTransaction sqlTransac = conn.BeginTransaction())
            {
                try
                {
                    _provisionningRuleManager.AddProvisioningRate(pR, sqlTransac);
                    sqlTransac.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransac.Rollback();
                    throw ex;
                }
            }
		}
        public void AddLoanScale(LoanScaleRate lR)
        {
            LoanScaleTable lT = LoanScaleTable.GetInstance(_user);
            if (lR.ScaleMin == 0)
                throw new OpenCbsAccountException(OpenCbsAccountExceptionsEnum.LoanScaleTableMin);
            if (lR.ScaleMax == 0)
                throw new OpenCbsAccountException(OpenCbsAccountExceptionsEnum.LoanScaleTableMax);

            lR.Number = lT.LoanScaleRates.Count + 1;
        
            lT.AddLoanScaleRate(lR);
             using (SqlConnection conn = _loanScaleManager.GetConnection())
             using (SqlTransaction sqlTransac = conn.BeginTransaction())
             {
                 try
                 {
                     _loanScaleManager.InsertLoanScale(lR, sqlTransac);
                     sqlTransac.Commit();
                 }
                 catch (Exception ex)
                 {
                     sqlTransac.Rollback();
                     throw ex;
                 }
             }
        }

        public void DeleteLoanScale(LoanScaleRate ls)
        {
            LoanScaleTable lt = LoanScaleTable.GetInstance(_user);
            lt.DeleteLoanScaleRate(ls);
        }

        public void UpdateLoanScaleTableInstance()
        {
            using (SqlConnection conn = _loanScaleManager.GetConnection())
            using (SqlTransaction sqlTransac = conn.BeginTransaction())
            {
                LoanScaleTable lT = LoanScaleTable.GetInstance(_user);
                try
                {
                    _loanScaleManager.Delete(sqlTransac);
                    int i = 1;
                    foreach (LoanScaleRate lR in lT.LoanScaleRates)
                    {
                        lR.Number = i;
                        _loanScaleManager.InsertLoanScale(lR, sqlTransac);
                        i++;
                    }
                    sqlTransac.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransac.Rollback();
                    throw ex;
                }
            }
        }
       

		public void UpdateProvisioningTableInstance()
		{
		    using (SqlConnection conn  =  _provisionningRuleManager.GetConnection())
            using (SqlTransaction sqlTransac = conn.BeginTransaction())
            {
                ProvisionTable pT = ProvisionTable.GetInstance(_user);
                try
                {
                    _provisionningRuleManager.DeleteAllProvisioningRules(sqlTransac);
                    int i = 1;
                    foreach (ProvisioningRate pR in pT.ProvisioningRates)
                    {
                        pR.Number = i;
                        _provisionningRuleManager.AddProvisioningRate(pR, sqlTransac);
                        i++;
                    }
                    sqlTransac.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransac.Rollback();
                    throw ex;
                }
            }
		}
	}
}
