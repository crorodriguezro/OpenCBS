using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.View
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
