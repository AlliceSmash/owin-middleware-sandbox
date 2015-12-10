using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OwinWebApiClient_DB
{
    public class CompanyClient
    {
        string _hostUri;
        public CompanyClient(string hostUri)
        {
            _hostUri = hostUri;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/companies/");
            return client;
        }

        public IEnumerable<Company> GetCompanies()
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }

            var result = response.Content.ReadAsStringAsync()
                .ContinueWith(c => JsonConvert.DeserializeObject<List<Company>>(c.Result));
            return result.Result;
        }

        public Company GetCompany(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(new Uri(client.BaseAddress, id.ToString())).Result;
            }

            var result = response.Content.ReadAsStringAsync()
                .ContinueWith(c => JsonConvert.DeserializeObject<Company>(c.Result));

            return result.Result;
        }

    }
}
