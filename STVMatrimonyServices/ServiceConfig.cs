using System;
using System.Net.Http;

namespace STVMatrimonyServices
{
    public class ServiceConfig
    {
        public static HttpClient GetHttpClient(Uri serviceUrl)
        {
            HttpClient _client;
            HttpClientHandler handler = new HttpClientHandler() { UseCookies = false };
            _client = new HttpClient(handler) { BaseAddress = serviceUrl, Timeout = new TimeSpan(0, 3, 0) };
            _client.DefaultRequestHeaders.Add("ApiKey", "AckesE1skAase8fUg6vNhg8PgrTFYdpAdd3ds3sd");
            return _client;
        }
    }
}
