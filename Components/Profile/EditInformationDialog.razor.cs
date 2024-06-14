using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using WinglyShop.Shared;
using WinglyShopAdmin.App.Abstractions.Services.Profile;
using WinglyShopAdmin.App.Models.Profile;
using WinglyShopAdmin.App.Services.Auth;

namespace WinglyShopAdmin.App.Components.Profile;

public partial class EditInformationDialog
{
    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private IProfileService _profileService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    [Parameter] public ProfileInformationModel? ProfileModel { get; set; }
    [Parameter] public AccountInformationModel? AccountInformationModel { get; set; }

    private AnyProfileModel? _anyProfileModel { get; set; }
    private List<string> _profileFields { get; set; } = new();

    private bool _loading = false;
    private string _error;

    protected override void OnInitialized()
    {
        _profileFields.Clear();

        if (ProfileModel is not null)
        {
            _anyProfileModel = BuildAnyProfileModel(ProfileModel, null);

            var properties = new ProfileInformationModel()
                .GetType()
                .GetProperties();

            foreach (var prop in properties)
            {
                _profileFields.Add(prop.Name);
            }
        }

        if (AccountInformationModel is not null)
        {
            _anyProfileModel = BuildAnyProfileModel(null, AccountInformationModel);

            var properties = new AccountInformationModel()
                .GetType()
                .GetProperties();

            foreach (var prop in properties)
            {
                _profileFields.Add(prop.Name);
            }
        }
    }

    private AnyProfileModel? BuildAnyProfileModel(ProfileInformationModel? profile, AccountInformationModel? account)
    {
        if (profile is not null)
        {
            return new AnyProfileModel
            {
                FirstField = profile.Name,
                SecondField = profile.Surname,
                ThirdField = profile.Phone
            };
        }

        if (account is not null)
        {
            return new AnyProfileModel
            {
                FirstField = account.Email,
                SecondField = account.Password
            };
        }

        return null;
    }

    private void CancelAction() => MudDialog.Cancel();

    private async Task HandleValidSubmit()
    {
        _loading = true;
        try
        {
            if (ProfileModel is not null)
            {
                await _profileService.UpdateProfileInformation(_anyProfileModel);
            }

            if (AccountInformationModel is not null)
            {
                await _profileService.UpdateAccountInformation(_anyProfileModel);
            }

            NavigationManager.NavigateTo("minha-conta");
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
