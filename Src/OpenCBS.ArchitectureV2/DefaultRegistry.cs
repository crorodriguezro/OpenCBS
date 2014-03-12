using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Presenter;
using StructureMap.Configuration.DSL;

namespace OpenCBS.ArchitectureV2
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scanner =>
            {
                scanner.Assembly("OpenCBS.GUI");
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
            });

            For<ITranslationService>().Singleton().Use<TranslationService>();
        }
    }
}
