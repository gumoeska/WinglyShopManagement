using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.Profile;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Profile;

public partial class ProfilePage
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IUserService UserService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    private UserFullAccountInformationModel UserFullAccountInformation { get; set; }

    private bool _loading;

    protected override async Task OnInitializedAsync()
    {
        await LoadAccountInformation();
    }

    private async Task LoadAccountInformation()
    {
        _loading = true;

        UserFullAccountInformation = await UserService.GetUserFullAccountInformation();

        _loading = false;
    }
}
