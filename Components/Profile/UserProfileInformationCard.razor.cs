using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Profile;

namespace WinglyShopAdmin.App.Components.Profile;

public partial class UserProfileInformationCard
{
    [Parameter] public UserFullAccountInformationModel? Model { get; set; } = new();

    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private IDialogService DialogService { get; set; }

    private bool _loading;
    private string _error;

    private async Task EditUserProfileInformation()
    {
        var profileModel = BuildProfileInformation(Model);

        var parameters = new DialogParameters<EditInformationDialog>
        {
            { x => x.ProfileModel, profileModel }
        };

        var dialog = await DialogService.ShowAsync<EditInformationDialog>("Editar", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            return;
        }
    }

    private ProfileInformationModel BuildProfileInformation(
        UserFullAccountInformationModel? accountInfo) =>
        new ProfileInformationModel
        {
            Name = accountInfo?.Name,
            Surname = accountInfo?.Surname,
            Phone = accountInfo?.Phone
        };
}
