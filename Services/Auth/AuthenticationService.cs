using WinglyShopAdmin.App.Helpers;
using WinglyShopAdmin.App.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.Auth.Requests;
using WinglyShop.Shared;

namespace WinglyShopAdmin.App.Services.Auth;

public class AuthenticationService : IAuthenticationService
{
    private IHttpService _httpService;
    private NavigationManager _navigationManager;
    private ILocalStorageService _localStorageService;

    public User User { get; private set; }

    public AuthenticationService(
        IHttpService httpService,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService
    )
    {
        _httpService = httpService;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task Initialize()
    {
        User = await _localStorageService.GetItem<User>("user");
    }

    public async Task Login(string username, string password)
    {
        var loginRequest = new LoginRequestModel
        {
            Login = username,
            Password = password
        };

        User = await _httpService.Post<User>($"/Auth/Login", loginRequest);

        await _localStorageService.SetItem("user", User);
    }

    public async Task Register(string username, string password, string email)
    {
        var registerRequest = new RegisterRequestModel
        {
            Login = username,
            Password = password,
            Email = email,

            Name = string.Empty,
            Image = string.Empty,
            Phone = string.Empty,
            Surname = string.Empty
        };

        var result = await _httpService.Post<bool>("/Auth/Register", registerRequest);
    }

    public async Task Logout()
    {
        User = null;
        await _localStorageService.RemoveItem("user");
        _navigationManager.NavigateTo("login");
    }
}


