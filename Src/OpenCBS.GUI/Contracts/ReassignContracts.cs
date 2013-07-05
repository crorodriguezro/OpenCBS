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
using System.Linq;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts;
using OpenCBS.GUI.UserControl;
using OpenCBS.Services;

namespace OpenCBS.GUI.Contracts
{
    public partial class ReassignContractsForm : SweetForm
    {
        private List<User> users;
        IEnumerable<ReassignContractItem> reassignContractItemList;
        public ReassignContractsForm()
        {
            InitializeComponent();
            LoadUsers();
            reassignContractItemList = InitializerContracts(0);
            fromCombobox.SelectedIndex = 0;
            toCombobox.SelectedIndex = 0;
        }


        private void LoadUsers()
        {
            fromCombobox.Items.Clear();

            users = ServicesProvider.GetInstance().GetUserServices().FindAll(false).OrderBy(item => item.FirstName).ThenBy(item => item.LastName).ToList();

            foreach (User user in users)
            {
                fromCombobox.Items.Add(user);

                if (!user.IsDeleted && (user.UserRole.IsRoleForLoan || user.UserRole.IsRoleForSaving))
                {
                    toCombobox.Items.Add(user);
                }
            }
        }

        private IEnumerable<ReassignContractItem> InitializerContracts(int officerId)
        {
            //bool onlyActive = chkBox_only_active.Checked;
            //listViewAlert.Items.Clear();

            //reassignContractItemList = ServicesProvider.GetInstance().GetContractServices().FindContractsByLoanOfficerId(officerId, onlyActive);

            //foreach (ReassignContractItem item in reassignContractItemList)
            //{
            //    //listViewAlert.Items.Add(CreateListViewItem(item));
            //}

            //toolStripStatusLabelTotal.Text = String.Format("Total contracts: {0}", listViewAlert.Items.Count);
            //return reassignContractItemList;
            return null;
        }

        private int GetLoanOfficerID(string loanOfficer)
        {
            List<User> myUser = users.FindAll(delegate(User officerId)
            {
                return officerId.Name == loanOfficer;
            });

            int Id = 0;
            myUser.ForEach(delegate(User officerId)
            {
                Id = officerId.Id;
            });
            return Id;
        }

        private void cbLoanOfficerFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializerContracts(GetLoanOfficerID(fromCombobox.Text));
            filterTextbox.Text = "";
            selectAllCheckbox.Checked = false;
        }

        private void cbLoanOfficerTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromCombobox.Text == toCombobox.Text)
            {
                toCombobox.SelectedIndex = 0;
            }
            selectAllCheckbox.Checked = false;
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

        private void listViewAlert_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in listViewAlert.Items)
            //{
            //    item.Checked = item.Selected;
            //}
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in listViewAlert.Items)
            //{
            //    item.Checked = checkBoxAll.Checked;
            //}
        }

        private void textBoxContractFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterContracts(filterTextbox.Text);
        }

        private void _FilterContracts(String filter)
        {
            //if (filter != null || !filter.Equals(""))
            //{
            //    filter = filter.ToUpper();

            //    listViewAlert.Items.Clear();

            //    foreach (ReassignContractItem item in reassignContractItemList)
            //    {
            //        if (item.ClientFirstName.ToUpper().Contains(filter) ||
            //            item.ClientLastName.ToUpper().Contains(filter))
            //        {
            //            //listViewAlert.Items.Add(CreateListViewItem(item));
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (ReassignContractItem item in reassignContractItemList)
            //    {
            //        //listViewAlert.Items.Add(CreateListViewItem(item));

            //    }
            //}
            //toolStripStatusLabelTotal.Text = String.Format("Total contracts: {0}", listViewAlert.Items.Count);

        }

        private void chkBox_only_active_CheckedChanged(object sender, EventArgs e)
        {
            InitializerContracts(GetLoanOfficerID(fromCombobox.Text));
        }
    }
}
