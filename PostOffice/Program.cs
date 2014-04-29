using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 2)
                return;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var msg = new { Name = args[0], Message = args[1] };
            HttpResponseMessage response = client.PostAsJsonAsync("/WebServices/Messaging", JsonConvert.SerializeObject(msg)).Result;            
        }
        
    }
}
