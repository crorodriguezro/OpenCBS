// Copyright © 2013 Open Octopus Ltd.
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
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts;
using OpenCBS.GUI.UserControl;
using OpenCBS.Services;

namespace OpenCBS.GUI.Contracts
{
    public partial class ReassignContractsForm : SweetForm
    {
        private List<User> _users;
        private IEnumerable<ReassignContractItem> _contracts;
        private string _filter;

        public ReassignContractsForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            fromCombobox.SelectedIndexChanged += (sender, args) => ReloadContracts();
            filterTextbox.TextChanged += (sender, args) =>
            {
                _filter = filterTextbox.Text;
                ShowContracts();
            };
        }

        private void LoadForm()
        {
            LoadUsers();
            fromCombobox.SelectedIndex = 0;
            toCombobox.SelectedIndex = 0;
            olbColumn.AspectToStringConverter =
            amountColumn.AspectToStringConverter = value =>
            {
                var amount = (decimal)value;
                return amount.ToString("N2");
            };
            startDateColumn.AspectToStringConverter =
            closeDateColumn.AspectToStringConverter = value =>
            {
                var date = (DateTime)value;
                return date.ToShortDateString();
            };
            interestRateColumn.AspectToStringConverter = value =>
            {
                var interestRate = (decimal)value;
                return (interestRate*100).ToString("N2") + " %";
            };
        }

        private void LoadUsers()
        {
            fromCombobox.Items.Clear();

            _users = ServicesProvider.GetInstance().GetUserServices().FindAll(false).OrderBy(item => item.LastName).ThenBy(item => item.FirstName).ToList();

            foreach (var user in _users)
            {
                fromCombobox.Items.Add(user);

                if (!user.IsDeleted && (user.UserRole.IsRoleForLoan || user.UserRole.IsRoleForSaving))
                {
                    toCombobox.Items.Add(user);
                }
            }
        }

        private void buttonAssing_Click(object sender, EventArgs e)
        {
            //bool isCheked = false;
            //if ((cbLoanOfficerTo.Text.Length > 0) && (cbLoanOfficerFrom.Text.Length > 0))
            //{

            //    foreach (ListViewItem item in listViewAlert.Items)
            //    {
            //        if (item.Checked)
            //        {
            //            isCheked = true;
            //            ServicesProvider.GetInstance().GetContractServices().ReassignContract(Convert.ToInt32(item.Tag), GetLoanOfficerID(cbLoanOfficerTo.Text), GetLoanOfficerID(cbLoanOfficerFrom.Text));

            //        }
            //    }
            //    if (!isCheked)
            //    {
            //        MessageBox.Show(MultiLanguageStrings.GetString(Ressource.ReassingContract, "selectContract.Text"),
            //                MultiLanguageStrings.GetString(Ressource.ReassingContract, "title.Text"), MessageBoxButtons.OK,
            //                            MessageBoxIcon.Information);
            //    }
            //    InitializerContracts(GetLoanOfficerID(cbLoanOfficerFrom.Text));
            //}
            //else
            //{
            //    MessageBox.Show(MultiLanguageStrings.GetString(Ressource.ReassingContract, "dataerror.Text"),
            //            MultiLanguageStrings.GetString(Ressource.ReassingContract, "title.Text"), MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);
            //}

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in listViewAlert.Items)
            //{
            //    item.Checked = checkBoxAll.Checked;
            //}
        }

        private void Disable()
        {
            optionsPanel.Enabled = false;
        }

        private void Enable()
        {
            optionsPanel.Enabled = true;
        }

        private void ShowContracts()
        {
            if (string.IsNullOrEmpty(_filter))
            {
                contractsObjectListView.SetObjects(_contracts);
                return;
            }

            var filteredContracts = from contract in _contracts
                                    where contract.ClientLastName.ToLower().Contains(_filter.ToLower())
                                    select contract;
            contractsObjectListView.SetObjects(filteredContracts);
        }

        private void ReloadContracts()
        {
            var user = fromCombobox.SelectedItem as User;
            if (user == null) return;

            var cursor = Cursor;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) =>
            {
                var loanService = ServicesProvider.GetInstance().GetContractServices();
                _contracts = loanService.FindContractsByLoanOfficerId(user.Id, false);
            };
            backgroundWorker.RunWorkerCompleted += (sender, args) =>
            {
                Enable();
                Cursor = cursor;
                if (args.Error != null)
                {
                    Fail(args.Error.Message);
                    return;
                }
                ShowContracts();
            };
            Cursor = Cursors.WaitCursor;
            Disable();
            _contracts = new List<ReassignContractItem>();
            ShowContracts();
            backgroundWorker.RunWorkerAsync();
        }
    }
}
