using Microsoft.AspNetCore.Components;
using WinglyShopAdmin.App.Abstractions.Services;

namespace WinglyShopAdmin.App.Pages.Auth;
public partial class Logout
{
    [Inject] private IAuthenticationService AuthenticationService { get; set; }

    protected override async void OnInitialized()
    {
        await AuthenticationService.Logout();
    }
}
