using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace zadApi.Services
{
    class Client
    {
        protected HttpClient client;
        protected bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public Client()
        {
            client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain,
           errors) =>
            {
                return true;
            };
            return handler;
        }
    }
}
