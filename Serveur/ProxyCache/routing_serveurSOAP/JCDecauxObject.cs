using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace routing_serveurSOAP
{
    class JCDecauxObject
    {
        string json;
        public JCDecauxObject(string url)
        {
            this.json = GetContracts(url).Result;
        }

        public async Task<string> GetContracts(string url)
        {
            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
             

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }

        public string getJson()
        {
            return this.json;
        }
    }
}
