using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.View;
using StructureMap;

namespace OpenCBS.ArchitectureV2
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
        }

        public void Execute<T>(T commandData)
        {
            try
            {
                var command = _container.TryGetInstance<ICommand<T>>();
                if (command != null)
                {
                    command.Execute(commandData);
                }
            }
            catch (Exception error)
            {
                var errorView = _container.GetInstance<IErrorView>();
                errorView.Run(error.Message);
            }
        }

        public void Raise<T>(T eventData)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(object eventHandlers)
        {
            throw new System.NotImplementedException();
        }
    }
}
