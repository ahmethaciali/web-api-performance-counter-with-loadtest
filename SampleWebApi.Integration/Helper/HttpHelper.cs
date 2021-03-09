using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data2.Helper
{
    public class HttpHelper
    {
        public static async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public static async Task<T> Post<T>(string url, object content) where T : class, new()
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            using(var client = new HttpClient())
            {
                var response = await client.PostAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
                string resultContentString = await response.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public static async Task<T> Put<T>(string url, object content) where T : class, new()
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            using(var client = new HttpClient())
            {
                var response = await client.PutAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
                var resultContentString = await response.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public static async Task<T> Delete<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                {
                    var resultContentString = await response.Content.ReadAsStringAsync();
                    T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resultContent;
                }
            }
        }
    }
    public class Ogrenci
    {
        public string Name { get; set; }
    }
}