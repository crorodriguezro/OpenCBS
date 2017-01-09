using OpenCBS.ArchitectureV2.Accounting.Command;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extensions;
using StructureMap.Configuration.DSL;

namespace OpenCBS.ArchitectureV2.Accounting
{
    public class AccountingRegistry : Registry
    {
        public AccountingRegistry()
        {
            For<IMenu>().Use<AccountingMenu>();
            For<ICommand<ShowAccountsCommandData>>().Use<ShowAccountsCommand>();
            For<ICommand<AddAccountCommandData>>().Use<AddAccountCommand>();
            For<ICommand<EditAccountCommandData>>().Use<EditAccountCommand>();
            For<ICommand<DeleteAccountCommandData>>().Use<DeleteAccountCommand>();
            For<ICommand<ShowBookingsCommandData>>().Use<ShowBookingsCommand>();
            For<ICommand<AddBookingCommandData>>().Use<AddBookingCommand>();
            For<ICommand<EditBookingCommandData>>().Use<EditBookingCommand>();
            For<ICommand<DeleteBookingCommandData>>().Use<DeleteBookingCommand>();
            For<ICommand<ShowAnalyticBalancesCommandData>>().Use<ShowAnalyticBalancesCommand>();
        }
    }
}
