using WinglyShopAdmin.App.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinglyShopAdmin.App.Abstractions.Services;
using System.Text.Json.Serialization;
using static MudBlazor.Colors;

namespace WinglyShopAdmin.App.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;
    private NavigationManager _navigationManager;
    private ILocalStorageService _localStorageService;
    private IConfiguration _configuration;

    public HttpService(
        HttpClient httpClient,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService,
        IConfiguration configuration) 
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
        _configuration = configuration;
    }

    public async Task<T> Get<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_httpClient.BaseAddress}{uri}");
        return await SendRequest<T>(request);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_httpClient.BaseAddress}{uri}");
        request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return await SendRequest<T>(request);
    }

    public async Task<T> Put<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_httpClient.BaseAddress}{uri}");
        request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return await SendRequest<T>(request);
    }

    public async Task<T> Patch<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"{_httpClient.BaseAddress}{uri}");
        return await SendRequest<T>(request);
    }

    public async Task<T> Patch<T>(string uri, object value)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"{_httpClient.BaseAddress}{uri}");
        request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return await SendRequest<T>(request);
    }

    public async Task<T> Delete<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{_httpClient.BaseAddress}{uri}");
        return await SendRequest<T>(request);
    }

    // helper methods

    private async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        // add basic auth header if user is logged in and request is to the api url
        var user = await _localStorageService.GetItem<User>("user");
        var isApiUrl = !request.RequestUri.IsAbsoluteUri;

        if (user != null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.AuthData);

        using var response = await _httpClient.SendAsync(request);

        // auto logout on 401 response
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _navigationManager.NavigateTo("logout");
            return default;
        }

        // throw exception on error response
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            throw new Exception(error["message"]);
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }
}
