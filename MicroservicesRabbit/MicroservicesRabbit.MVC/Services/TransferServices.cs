using MicroservicesRabbit.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroservicesRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        private readonly IConfiguration _configuration;

        public TransferService(HttpClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = _configuration["API_URL"];
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                                            System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}

