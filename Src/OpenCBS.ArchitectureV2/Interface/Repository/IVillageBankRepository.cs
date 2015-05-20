using OpenCBS.ArchitectureV2.Model;

namespace OpenCBS.ArchitectureV2.Interface.Repository
{
    public interface IVillageBankRepository
    {
        VillageBank Get(int id);
    }
}
