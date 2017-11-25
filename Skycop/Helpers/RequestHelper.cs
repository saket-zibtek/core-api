using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Skycop.Helpers
{
    public static class RequestHelper
    {
        public static string GetRequestValue(HttpRequestMessage request, string keyName)
        {
            IEnumerable<string> headerValues;
            var apiKey = string.Empty;
            var keyFound = request.Headers.TryGetValues(keyName, out headerValues);
            if (keyFound)
            {
                apiKey = headerValues.FirstOrDefault();
            }
            return apiKey;
        }
    }
}
