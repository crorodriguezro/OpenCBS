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
using OpenCBS.CoreDomain;
using NUnit.Framework;
using OpenCBS.CoreDomain.Accounting;

namespace OpenCBS.Test.CoreDomain.Accounting
{
	[TestFixture]
	public class TestProvisioningTable
	{
		private ProvisionTable provisionTable;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
            provisionTable = ProvisionTable.GetInstance(new User());
            provisionTable.ProvisioningRates = new List<ProvisioningRate>();
            provisionTable.Add(new ProvisioningRate { Number = 1, NbOfDaysMin = 0, NbOfDaysMax = 0, provisioning_value = 2, provisioning_interest=2, provisioning_penalty=2 });
            provisionTable.Add(new ProvisioningRate { Number = 2, NbOfDaysMin = 1, NbOfDaysMax = 30, provisioning_value = 10, provisioning_interest = 10, provisioning_penalty = 10 });
            provisionTable.Add(new ProvisioningRate { Number = 3, NbOfDaysMin = 31, NbOfDaysMax = 60, provisioning_value = 25, provisioning_interest = 25, provisioning_penalty = 25 });
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			provisionTable.ProvisioningRates = new List<ProvisioningRate>();
		}
		
		[Test]
		public void TestProvisioningRateNbOfDaysMin()
		{
			ProvisioningRate pR = new ProvisioningRate();
			pR.NbOfDaysMin = 10;
			Assert.AreEqual(10,pR.NbOfDaysMin);
		}

		[Test]
		public void TestProvisioningRateNbOfDaysMax()
		{
			ProvisioningRate pR = new ProvisioningRate();
			pR.NbOfDaysMax = 20;
			Assert.AreEqual(20,pR.NbOfDaysMax);
		}

		[Test]
		public void TestProvisioningRateOlb()
		{
			ProvisioningRate pR = new ProvisioningRate();
			pR.provisioning_value= 10.5;
			Assert.AreEqual(10.5,pR.provisioning_value);
		}
        
        [Test]
        public void TestProvisioningRateInterest()
        {
            ProvisioningRate pR = new ProvisioningRate();
            pR.provisioning_interest = 10.5;
            Assert.AreEqual(10.5, pR.provisioning_interest);
        }

        [Test]
        public void TestProvisioningRatePenalty()
        {
            ProvisioningRate pR = new ProvisioningRate();
            pR.provisioning_penalty = 10.5;
            Assert.AreEqual(10.5, pR.provisioning_penalty);
        }

		[Test]
		public void TestGetProvisioningRateByRank()
		{
			Assert.AreEqual(25,provisionTable.GetProvisioningRate(2).provisioning_value);
		}

		[Test]
		public void TestGetProvioningRateWhenNothingFound()
		{
			Assert.IsNull(provisionTable.GetProvisioningRate(-123));
		}

		[Test]
		public void TestGetProvisioningRateByNbOfDays()
		{
			Assert.AreEqual(10,provisionTable.GetProvisiningRateByNbOfDays(21).provisioning_value);
		}

		[Test]
		public void TestGetProvisioningRateByNbOfDaysWhenZero()
		{
			Assert.AreEqual(2,provisionTable.GetProvisiningRateByNbOfDays(0).provisioning_value);
		}

		[Test]
		public void TestGetProvioningRateByNbOfDaysWhenNothingFound()
		{
			Assert.IsNull(provisionTable.GetProvisiningRateByNbOfDays(-123));
		}

	}
}
