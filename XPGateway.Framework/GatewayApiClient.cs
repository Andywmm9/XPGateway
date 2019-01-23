using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
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
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
        }

        public async Task<GetAllAirportsResponse> GetAllAirportsResponse()
        {
            var response = await _httpClient.GetAsync("airports");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<GetAllAirportsResponse>();
        }

        public async Task<GetSceneryResponse> GetSceneryResponse(int sceneryId)
        {
            var response = await _httpClient.GetAsync($"scenery/{sceneryId}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<GetSceneryResponse>();
        }
    }
}
