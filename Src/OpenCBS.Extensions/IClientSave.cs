using System.Collections.Generic;

namespace OpenCBS.Extensions
{
    public interface IClientSave
    {
        void PersonSave(IDictionary<string, object> interceptorParams);
    }
}
