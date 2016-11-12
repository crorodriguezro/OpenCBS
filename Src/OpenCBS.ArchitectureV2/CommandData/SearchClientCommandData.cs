namespace OpenCBS.ArchitectureV2.CommandData
{
    public class SearchClientCommandData
    {
        public SearchClientCommandData(bool openingNewClientForm=true)
        {
            OpeningNewClientForm = openingNewClientForm;
        }
        public bool OpeningNewClientForm { get; set; }
        
    }
}
