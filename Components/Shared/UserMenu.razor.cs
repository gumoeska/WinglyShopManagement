using Microsoft.AspNetCore.Components;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.UserData;

namespace WinglyShopAdmin.App.Components.Shared;

public partial class UserMenu
{
    [Inject] public IAuthenticationService AuthenticationService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [EditorRequired] [Parameter] public UserBasicInformation? UserInfo { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    public void Logout()
    {
        AuthenticationService.Logout();
    }
}
