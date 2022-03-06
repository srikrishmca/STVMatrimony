using Newtonsoft.Json;
using STVMatrimony.APIModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STVMatrimony.Services
{
    public class CommonService : ICommonService
    {
        private static readonly CommonService instance = new CommonService();
        public static CommonService Instance
        {
            get => instance;
        }
        static CommonService()
        {
        }
        public async Task<ApiResponse<T>> GetResponseAsync<T>(string url)
        {
            try
            {
                UriBuilder uriBuilder = new UriBuilder(string.Format(ServiceConstants.ApiBaseURL + url));
                //Uri uri = new Uri();
                HttpClient _client = ServiceConfig.GetHttpClient(uriBuilder.Uri);
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
                HttpResponseMessage response = _client.SendAsync(message).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var responseResult = JsonConvert.DeserializeObject<ApiResponse<T>>(result);
                    
                    return responseResult;
                }

                else
                {
                    ApiResponse<T> res = new ApiResponse<T>
                    {
                        StatusCode=401,
                        Message = "Some thing went wrong",
                        Version = null
                    };
                    return res;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(ApiResponse<T>);
            }
        }
        public async Task<ApiResponse<T1>> PostResponseAsync<T1, T2>(string url, T2 model)
        {
            try
            {

                Uri uri = new Uri(string.Format(ServiceConstants.ApiBaseURL + url));
                HttpClient _client = ServiceConfig.GetHttpClient(uri);
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, content);
                ApiResponse<T1> responseResult = new ApiResponse<T1>();

                if (response.IsSuccessStatusCode)
                {
                    using (Stream s = await response.Content.ReadAsStreamAsync())
                    using (StreamReader sr = new StreamReader(s))
                    {
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            // read the json from a stream
                            // json size doesn't matter because only a small piece is read at a time from the HTTP request
                            var result = serializer.Deserialize<ApiResponse<T1>>(reader);

                            responseResult = result;
                        }
                    }
                }
                else
                {
                    responseResult.Version = "1.0";
                    responseResult.IsError = true;
                    responseResult.Message = "Some thing went wrong";
                }
                return responseResult;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(ApiResponse<T1>);
            }
        }
    }
}
