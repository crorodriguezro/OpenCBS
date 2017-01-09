using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.Enums;
using OpenCBS.Extension.ExcelReports;
using OpenCBS.Extensions;
using OpenCBS.Services;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2.Accounting
{
    public class AccountingMenu : IMenu
    {
        private readonly IApplicationController _applicationController;
        private readonly ITranslationService _translationService;
        private ToolStripMenuItem _menuItem;

        public AccountingMenu(IApplicationController applicationController,
            ITranslationService translationService)
        {
            _applicationController = applicationController;
            _translationService = translationService;
        }

        public ToolStripMenuItem GetItem()
        {
            if (_menuItem != null) return _menuItem;

            var role = User.CurrentUser.UserRole;
            var menuItems = ServicesProvider.GetInstance().GetMenuItemServices().GetMenuList(OSecurityObjectTypes.MenuItem);
            var item = new ToolStripMenuItem
            {
                Name = "mnuAccounting",
                Text = _translationService.Translate("Accounting"),
            };
            var chartItem = new ToolStripMenuItem
            {
                Name = "mnuNewChartOfAccounts",
                Text = _translationService.Translate("Chart of Accounts")
            };
            var chartOfAcountsMenu = menuItems.Find(i => i == chartItem.Name);
            if (chartOfAcountsMenu != null)
            {
                chartItem.Enabled = role.IsMenuAllowed(chartOfAcountsMenu);
            }

            chartItem.Click += (sender, e) => _applicationController.Execute(new ShowAccountsCommandData());
            var bookingsItem = new ToolStripMenuItem
            {
                Name = "mnuNewBooking",
                Text = _translationService.Translate("Bookings")
            };
            var bookingMenu = menuItems.Find(i => i == bookingsItem.Name);
            if (bookingMenu != null)
            {
                bookingsItem.Enabled = role.IsMenuAllowed(bookingMenu);
            }
            bookingsItem.Click += (sender, args) => _applicationController.Execute(new ShowBookingsCommandData());

            var turnoverItem = new ToolStripMenuItem
            {
                Name = "mnuNewTurnoverBalances",
                Text = _translationService.Translate("Turnover Balance Sheet")
            };
            var turnoverMenu = menuItems.Find(i => i == turnoverItem.Name);
            if (turnoverMenu != null)
            {
                turnoverItem.Enabled = role.IsMenuAllowed(turnoverMenu);
            }
            turnoverItem.Click +=
                (sender, args) => _applicationController.Execute(new ShowTurnoverBalancesCommandData());

            var balancesItem = new ToolStripMenuItem
            {
                Name = "mnuNewBalances",
                Text = _translationService.Translate("Balance Sheet")
            };
            var balancesMenu = menuItems.Find(i => i == balancesItem.Name);
            if (balancesMenu != null)
            {
                balancesItem.Enabled = role.IsMenuAllowed(balancesMenu);
            }
            balancesItem.Click +=
                (sender, args) =>
                    _applicationController.Execute(new ShowTurnoverBalancesCommandData {BalancesOnly = true});

            var movementsItem = new ToolStripMenuItem
            {
                Name = "mnuNewAccountMovements",
                Text = _translationService.Translate("Account Movements")
            };
            movementsItem.Click +=
                (sender, args) => _applicationController.Execute(new ShowAccountMovementsCommandData());
            var movementsMenu = menuItems.Find(i => i == movementsItem.Name);
            if (movementsMenu != null)
            {
                movementsItem.Enabled = role.IsMenuAllowed(movementsMenu);
            }

            var reportsItem = new ToolStripMenuItem
            {
                Name = "mnuAccountingReports",
                Text = _translationService.Translate("Reports")
            };

            var directory = TechnicalSettings.ReportPath;
            if (string.IsNullOrEmpty(directory))
            {
                directory = AppDomain.CurrentDomain.BaseDirectory;
            }
            directory = Path.Combine(directory, "Reports");
            directory = Path.Combine(directory, "Excel");
            if (Directory.Exists(directory))
            {
                var reports = Directory.GetFiles(directory, "*.zip")
                    .Select(file => new Report(file))
                    .Where(report => report.AttachmentPoint == "Accounting")
                    .ToList();
                foreach (var report in reports)
                {
                    var temp = report;
                    var reportItem = new ToolStripMenuItem
                    {
                        Name = "mnu" + report.Title,
                        Text = report.Title
                    };
                    reportItem.Click += (sender, e) => Initializer.ShowReport(temp, new Dictionary<string, object>());
                    reportsItem.DropDownItems.Add(reportItem);
                }
            }
            var customReports = _applicationController.GetAllInstances<IReportItem>().ToList();
            customReports.Sort((x, y) => x.Order.CompareTo(y.Order));
            foreach (var report in customReports)
            {
                reportsItem.DropDownItems.Add(report.GetItem());
            }
            reportsItem.Visible = reportsItem.DropDownItems.Count > 0;

            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = bookingsItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { bookingsItem });
            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = chartItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { chartItem });
            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = balancesItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { balancesItem });
            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = turnoverItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { turnoverItem });
            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = movementsItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { movementsItem });
            if (User.CurrentUser.UserRole.IsMenuAllowed(new MenuObject { Name = reportsItem.Name }))
                item.DropDownItems.AddRange(new ToolStripItem[] { reportsItem });

            var extensions = _applicationController.GetAllInstances<IAccountingMenu>().ToList();
            extensions.Sort((x, y) => x.Order.CompareTo(y.Order));
            foreach (var extensionMenu in extensions)
            {
                item.DropDownItems.Add(extensionMenu.GetItem());
            }
            _menuItem = item;
            return item;
        }

        public string InsertAfter
        {
            get { return "_modulesMenuItem"; }
        }
    }
}
