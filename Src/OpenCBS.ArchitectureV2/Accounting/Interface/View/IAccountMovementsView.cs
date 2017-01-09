using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.View
{
    public interface IAccountMovementsView : IView<IAccountMovementsPresenterCallbacks>
    {
        DateTime From { get; set; }
        DateTime To { get; set; }
        Account Account { get; set; }
        List<Account> Accounts { set; }
        void SetAccountMovements(List<AccountMovement> accountMovements);
        Control Control { get; }
    }
}
