using OpenSenseMapAssessment.Helpers;
using System.IO;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net;
using OpenSenseMapAssessment.Models.User;

namespace OpenSenseMapAssessment.Services.User
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Register a user
        public async Task<UserRegisterResponse> RegisterUserAsync(UserRegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"users/register", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"User Register failed: {error}");
            }

            // Deserialize directly into the Model
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserRegisterResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result == null)
            {
                throw new ApplicationException("Deserialization failed. JSON might not match Data Model structure.");
            }

            return result;
        }
        #endregion

        #region User Login
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("users/sign-in", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Login failed: {error}");
            }
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserLoginResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result == null || string.IsNullOrEmpty(result.Token))
            {
                throw new ApplicationException("Deserialization failed. JSON might not match Data Model structure.");
            }

            // Store tokens for later use
            TokenHelper.Token = result.Token;
            TokenHelper.RefreshToken = result.RefreshToken;

            return result;
        }
        #endregion

        #region User Logout
        public async Task<bool> LogoutUserAsync()
        {
            if (string.IsNullOrEmpty(TokenHelper.Token))
                throw new ApplicationException("User is not logged in.");

            var request = new HttpRequestMessage(HttpMethod.Post, "users/sign-out");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TokenHelper.Token);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // Clear tokens
                TokenHelper.Clear();
                return true;
            }

            else if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ApplicationException("Unauthorized: Invalid or expired token.");
            }
            else
            {
                throw new ApplicationException($"Logout failed: {response.StatusCode}");
            }
        }
        #endregion
    }
}
