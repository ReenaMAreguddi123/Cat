using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace Cat.Web.Services
{
    public abstract class BaseService
    {
        private readonly ILogger<BaseService> _logger;
        protected BaseService(ILogger<BaseService> logger)
        {
            _logger = logger;
        }

        protected ILogger Logger => _logger;
        protected HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.thecatapi.com/v1/"),
            };

            httpClient.DefaultRequestHeaders.Add("x-api-key", "4c735798-7ec0-4a32-89dd-2b79710f1ca0");

            return httpClient;
        }
    }
}
