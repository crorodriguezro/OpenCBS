using System.Collections.Generic;

namespace OpenCBS.Extensions
{
    public interface ICorporateInterceptor
    {
        void Save(IDictionary<string, object> interceptorParams);
        void Update(IDictionary<string, object> interceptorParams);
    }
}