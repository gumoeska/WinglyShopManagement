using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using WinglyShopAdmin.App;
using WinglyShopAdmin.App.Models.Auth;
using WinglyShopAdmin.App.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using System;
using WinglyShopAdmin.App.Abstractions.Services;

namespace WinglyShopAdmin.App.Pages.Auth;

public partial class RegisterPage
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private IAuthenticationService AuthenticationService { get; set; }

    private RegisterModel model = new();
    private bool _loading;
    private string _error;
    private bool _success;

    protected override void OnInitialized()
    {
        // redirect to home if already logged in
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
            await AuthenticationService.Register(model.Username, model.Password, model.Email);

            var returnUrl = NavigationManager.GetUriWithQueryParameter("returnUrl", false);
            if (returnUrl == "returnUrl")
                NavigationManager.NavigateTo(returnUrl);
            else
            {
                _snackbar.Add("Conta criada com sucesso!", Severity.Success);
                NavigationManager.NavigateTo("/login");
            }
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
