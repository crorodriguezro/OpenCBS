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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.Services;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts;
using OpenCBS.Enums;

namespace OpenCBS.GUI.Contracts
{
    public partial class ReassignContractsForm : Form
    {
        private List<User> users;
        List<ReassignContractItem> reassignContractItemList;
        public ReassignContractsForm()
        {
            InitializeComponent();
            _InitializeLoanOfficer();
            reassignContractItemList = InitializerContracts(0);
            cbLoanOfficerFrom.SelectedIndex = 0;
            cbLoanOfficerTo.SelectedIndex = 0;
        }


        private void _InitializeLoanOfficer()
        {
            cbLoanOfficerFrom.Items.Clear();

            users = ServicesProvider.GetInstance().GetUserServices().FindAll(false).OrderBy(item => item.FirstName).ThenBy(item => item.LastName).ToList();
            
            foreach (User user in users)
            {
                cbLoanOfficerFrom.Items.Add(user);

                if (!user.IsDeleted && (user.UserRole.IsRoleForLoan || user.UserRole.IsRoleForSaving))
                {
                    cbLoanOfficerTo.Items.Add(user);
                }
            }
        }

        private List<ReassignContractItem> InitializerContracts(int officerId)
        {
            bool onlyActive = chkBox_only_active.Checked;
            listViewAlert.Items.Clear();

            reassignContractItemList = ServicesProvider.GetInstance().GetContractServices().FindContractsByLoanOfficerId(officerId, onlyActive);

            foreach (ReassignContractItem item in reassignContractItemList)
            {
                listViewAlert.Items.Add(CreateListViewItem(item));
            }

            toolStripStatusLabelTotal.Text = String.Format("Total contracts: {0}", listViewAlert.Items.Count);
            return reassignContractItemList;
        }

        private ListViewItem CreateListViewItem(ReassignContractItem item)
        {
            ListViewItem listViewItem = new ListViewItem(item.LoanCode){
                                                    Tag = item.LoanId,
                                                    ImageIndex = (item.Type == 'D' ? 1 : 0)
                                                };
            listViewAlert.CheckBoxes = true;

            listViewItem.SubItems.Add(item.EffectDate.ToShortDateString());
            listViewItem.SubItems.Add(item.Amount.ToString());
            listViewItem.SubItems.Add(item.ClientFirstName);
            listViewItem.SubItems.Add(item.ClientLastName);
            listViewItem.SubItems.Add(item.DistrictName);
            listViewItem.SubItems.Add(item.StartDate.ToShortDateString());
            listViewItem.SubItems.Add(item.CloseDate.ToShortDateString());
            listViewItem.SubItems.Add(item.CreationDate.ToShortDateString());
            listViewItem.SubItems.Add(item.InstallmentTypes);
            listViewItem.SubItems.Add(item.InterestRate.ToString());
            listViewItem.SubItems.Add(item.Olb.ToString());
            listViewItem.SubItems.Add(item.LoanId.ToString());


            return listViewItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
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
            InitializerContracts(GetLoanOfficerID(cbLoanOfficerFrom.Text));
            textBoxContractFilter.Text="";
            checkBoxAll.Checked = false;
        }

        private void cbLoanOfficerTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoanOfficerFrom.Text == cbLoanOfficerTo.Text)
            {
                cbLoanOfficerTo.SelectedIndex = 0;
            }
            checkBoxAll.Checked = false;
        }

        private void buttonAssing_Click(object sender, EventArgs e)
        {
            bool isCheked = false;
            if ((cbLoanOfficerTo.Text.Length > 0) && (cbLoanOfficerFrom.Text.Length>0 ))
            {

                foreach (ListViewItem item in listViewAlert.Items)
                {
                    if (item.Checked)
                    {
                        isCheked = true;
                        ServicesProvider.GetInstance().GetContractServices().ReassignContract(Convert.ToInt32(item.Tag), GetLoanOfficerID(cbLoanOfficerTo.Text), GetLoanOfficerID(cbLoanOfficerFrom.Text));

                    }
                }
                if (!isCheked)
                {
                    MessageBox.Show(MultiLanguageStrings.GetString(Ressource.ReassingContract, "selectContract.Text"),
                            MultiLanguageStrings.GetString(Ressource.ReassingContract, "title.Text"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
                InitializerContracts(GetLoanOfficerID(cbLoanOfficerFrom.Text));
            }
            else
            {
                MessageBox.Show(MultiLanguageStrings.GetString(Ressource.ReassingContract, "dataerror.Text"),
                        MultiLanguageStrings.GetString(Ressource.ReassingContract, "title.Text"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            
        }

        private void listViewAlert_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAlert.Items)
            {
                item.Checked = item.Selected;
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAlert.Items)
            {
                item.Checked = checkBoxAll.Checked;
            }
        }

        private void textBoxContractFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterContracts(textBoxContractFilter.Text);
        }

       private void _FilterContracts(String filter)
       {
           if (filter != null || !filter.Equals(""))
           {
               filter = filter.ToUpper();

               listViewAlert.Items.Clear();

               foreach (ReassignContractItem item in reassignContractItemList)
               {
                   if (item.ClientFirstName.ToUpper().Contains(filter) || 
                       item.ClientLastName.ToUpper().Contains(filter))
                   {
                       listViewAlert.Items.Add(CreateListViewItem(item));
                   }
               }
           }
           else
           {
               foreach (ReassignContractItem item in reassignContractItemList)
               {
                   listViewAlert.Items.Add(CreateListViewItem(item));
                   
               }
           }
          toolStripStatusLabelTotal.Text = String.Format("Total contracts: {0}", listViewAlert.Items.Count);

       }

        private void chkBox_only_active_CheckedChanged(object sender, EventArgs e)
        {
            InitializerContracts(GetLoanOfficerID(cbLoanOfficerFrom.Text));
        }
    }
}
