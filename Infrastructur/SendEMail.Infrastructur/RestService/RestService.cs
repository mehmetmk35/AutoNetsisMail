using Newtonsoft.Json;
using SendEMail.Infrastructur.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMail.Infrastructur.RestService
{
    public class RestService
    {
        public async Task<RestToken> GetToken(RestContent company)
        {
            RestToken tokenModel = new RestToken();
            tokenModel.status = false;
            tokenModel.token = string.Empty;

            HttpResponseMessage response;


            var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type",company.GrantType),
                        new KeyValuePair<string, string>("branchcode", company.BranchCode),
                        new KeyValuePair<string, string>("password", company.Password),
                        new KeyValuePair<string, string>("username", company.UserName),
                        new KeyValuePair<string, string>("dbname", company.DbName),
                        new KeyValuePair<string, string>("dbuser", company.DbUser),
                        new KeyValuePair<string, string>("dbpassword", company.DbPassword),
                        new KeyValuePair<string, string>("dbtype", company.Dbtype)
            });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri(Configuration.Rest_RestUrl), "api/v2/token");

                response = await client.PostAsync(client.BaseAddress.AbsoluteUri, formContent);
            }
            string result = await response.Content.ReadAsStringAsync();
            response.Dispose();

            dynamic jsonResponse = JsonConvert.DeserializeObject(result);
            tokenModel.token = jsonResponse?.access_token;
            if (tokenModel.token != null)
                tokenModel.status = true;
            else
            {
                tokenModel.status = false;
                tokenModel.messaj = jsonResponse?.error_description;
            }

            return tokenModel;
        }
        public async Task revokeToken(string token)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri(Configuration.Rest_RestUrl), "api/v2/revoke");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                response = await client.GetAsync(client.BaseAddress.AbsoluteUri);
            }
            var result = response.Content.ReadAsStringAsync().Result;
            response.Dispose();
        }

    }

}
