using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwinWebApiClient_DB
{
    public static class ContentReader
    {
        public static Task<dynamic> ReadAsJsonAsync(this HttpContent content)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            return content.ReadAsStringAsync().ContinueWith(t =>
                JsonConvert.DeserializeObject(t.Result));
        }

    }
}
