using System;
using System.Net.Http;

namespace DotnetConf2019BCN.Mobile.Helpers
{
    public static class HttpClientFactory
    {
        public static HttpClient Create(string baseAddress) => new HttpClient
        {
            BaseAddress = new Uri(baseAddress),
            Timeout = TimeSpan.FromSeconds(5),
        };
    }
}
