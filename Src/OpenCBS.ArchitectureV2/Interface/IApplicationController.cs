namespace OpenCBS.ArchitectureV2.Interface
{
    public interface IApplicationController
    {
        void Execute<T>(T commandData);
        void Raise<T>(T eventData);
        void Subscribe(object eventHandlers);
        void Unsubscribe(object eventHandlers);
    }
}
