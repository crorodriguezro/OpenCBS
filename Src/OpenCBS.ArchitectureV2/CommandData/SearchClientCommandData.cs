using OpenCBS.Enums;

namespace OpenCBS.ArchitectureV2.CommandData
{
    public class SearchClientCommandData
    {
        public SearchClientCommandData()
        {
            OpeningNewClientForm = true;
        }

        public SearchClientCommandData(OClientTypes tiersType, bool includeNotactiveOnly)
        {
            OpeningNewClientForm = false;
            TiersType = tiersType;
            IncludeNotactiveOnly = includeNotactiveOnly;
        }

        public bool OpeningNewClientForm { get; set; }
        public OClientTypes TiersType { get; set; }
        public bool IncludeNotactiveOnly { get; set; }
    }
}
