using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInParser
{
    public class Parser
    {
        //public async static Task<RootObject> GetData()
        //{
        //    var http = new HttpClient();
        //    var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&amp;amp;lon={1}&amp;amp;units=metric");
        //    var response = await http.GetAsync(url);
        //    var result = await response.Content.ReadAsStringAsync();
        //    var serializer = new DataContractJsonSerializer(typeof(RootObject));

        //    var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));
        //    var data = (RootObject) serializer.ReadObject(ms);

        //    return data;
        //}
    }
}
