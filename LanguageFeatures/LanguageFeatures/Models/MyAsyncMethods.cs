using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            var client   = new HttpClient();
            var response = await client.GetAsync("http://apress.com");

            return response.Content.Headers.ContentLength;
        }
    }
}
