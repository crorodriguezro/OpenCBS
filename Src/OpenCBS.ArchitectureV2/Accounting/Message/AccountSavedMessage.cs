using OpenCBS.Extension.Accounting.Model;
using TinyMessenger;

namespace OpenCBS.Extension.Accounting.Message
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
