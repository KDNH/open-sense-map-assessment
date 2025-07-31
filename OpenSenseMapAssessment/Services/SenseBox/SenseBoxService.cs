using OpenSenseMapAssessment.Helpers;
using OpenSenseMapAssessment.Models.SenseBox;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OpenSenseMapAssessment.Services.SenseBox
{
    public class SenseBoxService :ISenseBoxService
    {
        private readonly HttpClient _httpClient;

        public SenseBoxService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Create Sense Box
        public async Task<SenseBoxResponse> CreateNewSenseBoxAsync(SenseBoxRequest request)
        {
            // Attach Bearer Token from TokenHelper 
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenHelper.Token);

            var response = await _httpClient.PostAsJsonAsync("boxes", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error, null, response.StatusCode);
            }

            var result = await response.Content.ReadFromJsonAsync<SenseBoxResponse>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result!;           
        }
        #endregion

        #region Get Sense Box By Id
        public async Task<SenseBoxData> GetSenseBoxByIdAsync(string senseBoxId)
        {           
            var response = await _httpClient.GetAsync($"boxes/{senseBoxId}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            var result = await response.Content.ReadFromJsonAsync<SenseBoxData>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result!;
        }
        #endregion

    }
}
