using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Enums;

namespace OpenCBS.ArchitectureV2.CommandData
{
    public class SearchClientCommandData
    {
        public SearchClientCommandData()
        {
            OpeningNewClientForm = true;
        }
        public SearchClientCommandData(OClientTypes tiersType,bool includeNotactiveOnly)
        {
            OpeningNewClientForm = false;
            TiersType = tiersType;
            IncludeNotactiveOnly = includeNotactiveOnly;
        }
        public bool OpeningNewClientForm { get; }
        public OClientTypes TiersType { get;  }
        public bool IncludeNotactiveOnly { get; }
        
    }
}
