using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Auth;
using WinglyShopAdmin.App.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System;
using WinglyShopAdmin.App.Abstractions.Services;

namespace WinglyShopAdmin.App.Pages.Auth;

public partial class LoginPage
{
    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private IAuthenticationService AuthenticationService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private LoginModel model = new LoginModel();
    private bool _loading;
    private string _error;
    private bool _success;

    protected override void OnInitialized()
    {
        if (AuthenticationService.User != null)
        {
            NavigationManager.NavigateTo("");
        }
    }

    private async void HandleValidSubmit()
    {
        _loading = true;
        try
        {
            await AuthenticationService.Login(model.Username, model.Password);
            
            var returnUrl = NavigationManager.GetUriWithQueryParameter("returnUrl", false);
            if (returnUrl == "returnUrl")
                NavigationManager.NavigateTo(returnUrl);
            else
                NavigationManager.NavigateTo("");
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            _snackbar.Add(ex.Message, Severity.Error);
            _loading = false;
            StateHasChanged();
        }
    }
}
