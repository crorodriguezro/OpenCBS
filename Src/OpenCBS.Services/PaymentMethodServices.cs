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
using System.Data;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.Manager;
using OpenCBS.CoreDomain;

namespace OpenCBS.Services
{
    /// <summary>
    /// Service layer for Payment Methods
    /// </summary>
    public class PaymentMethodServices : Services
    {
        private PaymentMethodManager _paymentMethodManager;
        private readonly User _user = new User();

        public PaymentMethodServices(PaymentMethodManager paymentMethodManager)
        {
            _paymentMethodManager = paymentMethodManager;
        }

        public PaymentMethodServices(User user)
        {
            _user = user;
            _paymentMethodManager = new PaymentMethodManager(_user);
        }

        /// <summary>
        /// The method retrieves all payment methods from database
        /// </summary>
        /// <returns>List of PaymentMethod</returns>
        public List<PaymentMethod> GetAllPaymentMethods()
        {
            return _paymentMethodManager.SelectPaymentMethods();
        }

        public List<PaymentMethod> GetAllNonCashsPaymentMethods(IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;
            try
            {
                var result = _paymentMethodManager.GetAllNonCashsPaymentMethods(tx);

                if (transaction == null)
                    tx.Commit();

                return result;
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public List<PaymentMethod> GetAllPaymentMethodsForClosure()
        {
            return _paymentMethodManager.SelectPaymentMethodsForClosure();
        }

        public List<PaymentMethod> GetAllPaymentMethodsOfBranch(int branchId)
        {
            return _paymentMethodManager.SelectPaymentMethodOfBranch(branchId);
        }

        /// <summary>
        /// The method retrieves payment method by id
        /// </summary>
        /// <param name="paymentMethodId">Id of a payment method</param>
        /// <returns>Returns an instant of the PaymentMethod</returns>
        public PaymentMethod GetPaymentMethodById(int paymentMethodId)
        {
            return _paymentMethodManager.SelectPaymentMethodById(paymentMethodId);
        }

        public PaymentMethod GetPaymentMethodByName(string paymentMethodName)
        {
            return _paymentMethodManager.SelectPaymentMethodByName(paymentMethodName);
        }

        public void AddPaymentMethodToBranch(PaymentMethod paymentMethod)
        {
            _paymentMethodManager.AddPaymentMethodToBranch(paymentMethod);
        }

        public void Delete(PaymentMethod paymentMethod)
        {
            _paymentMethodManager.DeletePaymentMethodFromBranch(paymentMethod);
        }

        public void UpdatePaymentMethodFromBranch(PaymentMethod paymentMethod)
        {
            _paymentMethodManager.UpdatePaymentMethodFromBranch(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;
            try
            {
                _paymentMethodManager.Update(paymentMethod, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }

        public void Save(PaymentMethod paymentMethod, IDbTransaction transaction = null)
        {
            // ReSharper disable once ConvertConditionalTernaryToNullCoalescing
            var tx = transaction == null
                     ? CoreDomain.DatabaseConnection.GetConnection().BeginTransaction()
                     : transaction;
            try
            {
                _paymentMethodManager.Save(paymentMethod, tx);

                if (transaction == null)
                    tx.Commit();
            }
            catch (Exception error)
            {
                if (transaction == null)
                    tx.Rollback();

                throw new Exception(error.Message);
            }
        }
    }
}