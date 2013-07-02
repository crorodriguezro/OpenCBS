using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.GUI.Contracts
{
    public partial class EditContractSchedule1 : Form
    {
        private Loan _loan;

        public EditContractSchedule1()
        {
            InitializeComponent();
        }
        public EditContractSchedule1(Loan pLoan)
        {
            InitializeComponent();
            _loan = pLoan;
            InitializeSchedule();
        }
        void InitializeSchedule()
        {
            olvSchedule.SetScheduleFor(_loan);
        }
    }
}
