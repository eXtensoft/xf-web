using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilverBullet
{
    public  class Harness
    {



        public async Task<string> ExecuteAsync()
        {
            HttpResponseMessage message;
            string url = @"http://api.oneclickdigital.com/v1/countries";
            string s = string.Empty;
            //using (HttpClient caller = new HttpClient())
            //{
            //    var x = await caller.GetAsync(url).Result;
            //    s = x;
            //}
            return s;
        }

        //public static async Task<T> MakeRequest<T>(string url, Dictionary<string, string> args, object reqObject)
        //{
        //    var reqJson = JsonConvert.SerializeObject(reqObject);
        //    var data = await MakeRequest(url, args, reqJson);
        //    if (data != null)
        //    {
        //        var obj = await JsonConvert.DeserializeObjectAsync<T>(data);
        //        return obj;
        //    }
        //    else
        //    {
        //        return default(T);
        //    }
        //}

    }
}
