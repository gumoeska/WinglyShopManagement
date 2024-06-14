using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Profile;

namespace WinglyShopAdmin.App.Components.Profile;

public partial class UserAccountInformationCard
{
    [Parameter] public UserFullAccountInformationModel? Model { get; set; } = new();

    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private IDialogService DialogService { get; set; }

    private bool _loading;
    private string _error;

    private async Task EditUserAccountInformation()
    {
        var accountModel = BuildProfileInformation(Model);

        var parameters = new DialogParameters<EditInformationDialog>
        {
            { x => x.AccountInformationModel, accountModel }
        };

        var dialog = await DialogService.ShowAsync<EditInformationDialog>("Editar", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            return;
        }
    }

    private AccountInformationModel BuildProfileInformation(
        UserFullAccountInformationModel? accountInfo) =>
        new AccountInformationModel
        {
            Email = accountInfo?.Email,
            Password = accountInfo?.Password
        };
}
