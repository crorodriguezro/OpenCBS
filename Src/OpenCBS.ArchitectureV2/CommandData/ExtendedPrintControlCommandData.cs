using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.CommandData
{
    public class ExtendedPrintControlCommandData
    {
        public Control Control { get; set; }
        public string StartPosition { get; set; }
        public Dictionary<string,string> AdditionalValues { get;set; } 
    }
}
