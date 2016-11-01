using OpenCBS.ArchitectureV2.Interface;
using StructureMap.Configuration.DSL;

namespace OpenCBS.ArchitectureV2
{
    public class AccrualInterestFuseRegistry : Registry
    {
        public AccrualInterestFuseRegistry()
        {
            For<IStartupProcess>().Use<UpdatePasswordProcess>();
        }
    }
}

