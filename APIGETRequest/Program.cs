using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net;

namespace APIGETRequest
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly String sURL = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";
        
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CallWebAPIAsync().Wait();
        }

        static async Task CallWebAPIAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(sURL);

                if (result.IsSuccessStatusCode)
                {                
                    var content = await client.GetStringAsync(sURL);
                    Console.WriteLine(content);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }         
        }
    }
}
