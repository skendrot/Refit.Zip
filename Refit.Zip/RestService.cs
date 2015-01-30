using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Refit.Zip
{
    public static class RestService
    {
        public static T For<T>(string hostUrl, RefitSettings settings)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }
            var client = new HttpClient(handler) { BaseAddress = new Uri(hostUrl) };
            return Refit.RestService.For<T>(client, settings);
        }

        public static T For<T>(string hostUrl)
        {
            return RestService.For<T>(hostUrl, null);
        }
    }
}
