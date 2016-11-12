using OpenCBS.CoreDomain.Clients;
using TinyMessenger;

namespace OpenCBS.ArchitectureV2.CommandData
{
    public class SearchClientNotification:ITinyMessage
    {
        public SearchClientNotification(object sender, IClient client)
        {
            Sender = sender;
            Client = client;
        }

        public IClient Client { get; set; }
        public object Sender { get; set; }

    }
}
