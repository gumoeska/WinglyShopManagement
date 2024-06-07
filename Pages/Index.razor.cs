using Microsoft.AspNetCore.Components;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.UserData;

namespace WinglyShopAdmin.App.Pages;

public partial class Index
{
    [Inject] private IUserService UserService { get; set; }

    private bool _loading;

    private UserBasicInformation? _userData;

    protected override async Task OnInitializedAsync()
    {
        // Buscar Informações da tela Home (?)

        //_loading = true;
        //users = await UserService.GetAll();
        //_loading = false;

        _loading = true;
        _userData = await UserService.GetUserInformation();
        _loading = false;
    }
}
