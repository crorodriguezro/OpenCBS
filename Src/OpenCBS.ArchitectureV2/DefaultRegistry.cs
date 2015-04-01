using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Presenter;
using StructureMap.Configuration.DSL;
using TinyMessenger;

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
                scanner.ConnectImplementationsToTypesClosing(typeof (ICommand<>));
                scanner.AssembliesFromPath("Extensions");
                scanner.LookForRegistries();
            });

            For<ITranslationService>().Singleton().Use<TranslationService>();
            For<IApplicationController>().Singleton().Use<ApplicationController>();
            For<IEventPublisher>().Singleton().Use<EventPublisher>();

            For<ITinyMessengerHub>().Singleton().Use<TinyMessengerHub>();

            RegisterInterceptor(new EventAggregatorInterceptor());
        }
    }
}
