using OpenCBS.ArchitectureV2.Accounting.Model;
using TinyMessenger;

namespace OpenCBS.ArchitectureV2.Accounting.Message
{
    public class AccountSavedMessage : ITinyMessage
    {
        public AccountSavedMessage(object sender, Account account)
        {
            Sender = sender;
            Account = account;
        }

        public object Sender { get; private set; }
        public Account Account { get; private set; }
    }
}
