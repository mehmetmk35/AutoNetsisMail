using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendEMail.Infrastructur.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SendEMail.Infrastructur.RestService.GetItemSlip
{
    public class GetItemSlipDesign
    {
        public async Task<string> GetItemSlip(string customerCode,string OrderNumber,int documentType,int designNumber,string branchCode)
        {
            RestService restService = new RestService();
            RestToken token = await restService.GetToken(new() { DbName = Configuration.Company, BranchCode = branchCode, UserName = Configuration.RestUsername, Password = Configuration.RestPassword });
            
            ItemSlipsPrinting İtemSlipsPrinting = new()
            {
                CustomerCode = customerCode,
                DesignNumber= designNumber,
                DocumentType= documentType,
                DocumentNumber= OrderNumber
            };
            HttpPostAsync httpPostAsync = new ();
            string result = await httpPostAsync.PostAsync("api/v2/Print/ItemSlipsPrinting", token.token, İtemSlipsPrinting);
            var restResult = JsonConvert.DeserializeObject(result);

            string resut = jsonParse(result);
            if (token.token != null)
                await restService.revokeToken(token.token);
           return resut;


        }
        public string jsonParse(string value)
        {
            string data = string.Empty;
            try
            {
                JObject json = JObject.Parse(value);
                // Check if the "Data" property exists and is not null
                JToken result = json["Data"];
                if (result != null)
                {
                    data = result.ToString();
                }
                return data;
            }
            catch (Exception)
            {
                return "aaaaaaaaaa";
            }

             
        }
    }
}
