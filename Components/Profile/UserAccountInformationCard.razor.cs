using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Profile;

namespace WinglyShopAdmin.App.Components.Profile;

public partial class UserAccountInformationCard
{
    [Parameter] public UserFullAccountInformationModel Model { get; set; } = new();

    [Inject] private ISnackbar _snackbar { get; set; }

    private bool _loading;
    private string _error;
}
