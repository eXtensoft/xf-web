using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilverBullet
{
    
    class Program
    {
        static HttpClient caller = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            caller.BaseAddress = new Uri("http://api.oneclickdigital.com/");
            caller.DefaultRequestHeaders.Accept.Clear();
            caller.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Console.ReadLine();
        }

        static async Task<IEnumerable<string>> GetAsync(string path)
        {
            List<string> list = new List<string>();
            HttpResponseMessage message = await caller.GetAsync(path);
            if (message.IsSuccessStatusCode)
            {
                list = await message.Content.ReadAsAsync<List<string>>();
            }
            return list;
        }
    }
}
