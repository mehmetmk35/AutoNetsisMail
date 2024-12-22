using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMail.Infrastructur.RestService
{
    public class HttpPostAsync 
    {
        public async Task<string> PostAsync(string url, string token, object list)
        {
            var jsonval = JsonConvert.SerializeObject(list);
            var content = new StringContent(jsonval, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri(Configuration.Rest_RestUrl), url);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpResponseMessage responseMessage = await client.PostAsync(client.BaseAddress.AbsoluteUri, content);
                string result = await responseMessage.Content.ReadAsStringAsync();
                responseMessage.Dispose();
                return result;
            }
        }
    }
}
