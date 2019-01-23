using System;
using System.Net.Http;
using System.Threading.Tasks;
using XPGateway.Framework.Responses;

namespace XPGateway.Framework
{
    public class GatewayApiClient
    {
        private const string _ApiUrl = "http://gateway.x-plane.com/apiv1/";
        private readonly HttpClient _httpClient = new HttpClient();

        public GatewayApiClient()
        {
            _httpClient.BaseAddress = new Uri(_ApiUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<GetAllAirportsResponse> GetAllAirportsResponse()
        {
            var response = await _httpClient.GetAsync("airports");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<GetAllAirportsResponse>();
        }
    }
}
