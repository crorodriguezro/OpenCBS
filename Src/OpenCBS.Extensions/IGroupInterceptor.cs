using System.Collections.Generic;

namespace OpenCBS.Extensions
{
    public interface IGroupInterceptor
    {
        void Save(IDictionary<string, object> interceptorParams);
        void Update(IDictionary<string, object> interceptorParams);
    }
}