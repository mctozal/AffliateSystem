// AuthService.cs
using Blazored.LocalStorage;
using MeSoft.Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MeSoft.Blazor.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigation;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigation)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigation = navigation;
        }

        public async Task<(bool Success, string ErrorMessage)> LoginAsync(LoginViewModel loginModel)
        {
            try
            {
                
                var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginModel);
                response.EnsureSuccessStatusCode();
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseModel>();
                await _localStorage.SetItemAsync("token", loginResponse.Token);
                _navigation.NavigateTo("/");
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Login failed: " + ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(RegisterViewModel registerModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerModel);
                response.EnsureSuccessStatusCode();
                _navigation.NavigateTo("/login");
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, "Registration failed: " + ex.Message);
            }
        }
    }
}