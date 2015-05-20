using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Model;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class VillageBankView : Form, IVillageBankView
    {
        public VillageBankView()
        {
            InitializeComponent();
            _memberActiveColumn.AspectToStringConverter = v => ((bool) v) ? "Yes" : "No";
        }

        public void Attach(IVillageBankPresenterCallbacks presenterCallbacks)
        {
        }

        public void SetVillageBank(VillageBank villageBank)
        {
            Name = "VillageBankView" + villageBank.Id;
            Text = "Village Bank - " + villageBank.Name;
            _membersListView.SetObjects(villageBank.Members);
        }
    }
}
