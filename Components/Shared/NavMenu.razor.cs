using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.UserData;

namespace WinglyShopAdmin.App.Components.Shared;

public partial class NavMenu
{
    [Inject] private IUserService UserService { get; set; }

    private UserBasicInformation? _userData;

    private bool _alternaTema;
    private bool _paletaComandosAberta;

    private readonly Palette _darkPalette = new()
    {
        Black = "#27272f",
        Background = "rgb(21,27,34)",
        BackgroundGrey = "#27272f",
        Surface = "#212B36",
        DrawerBackground = "rgb(21,27,34)",
        DrawerText = "rgba(255,255,255, 0.50)",
        DrawerIcon = "rgba(255,255,255, 0.50)",
        AppbarBackground = "#27272f",
        AppbarText = "rgba(255,255,255, 0.70)",
        TextPrimary = "rgba(255,255,255, 0.70)",
        TextSecondary = "rgba(255,255,255, 0.50)",
        ActionDefault = "#adadb1",
        ActionDisabled = "rgba(255,255,255, 0.26)",
        ActionDisabledBackground = "rgba(255,255,255, 0.12)",
        Divider = "rgba(255,255,255, 0.12)",
        DividerLight = "rgba(255,255,255, 0.06)",
        TableLines = "rgba(255,255,255, 0.12)",
        LinesDefault = "rgba(255,255,255, 0.12)",
        LinesInputs = "rgba(255,255,255, 0.3)",
        TextDisabled = "rgba(255,255,255, 0.2)"
    };

    private readonly Palette _lightPalette = new();

    private bool _loading;

    [EditorRequired]
    [Parameter]
    public bool IsMiniMenu { get; set; }

    [EditorRequired]
    [Parameter]
    public EventCallback AlternarMenuLateral { get; set; }

    [EditorRequired]
    [Parameter]
    public EventCallback AbrirPaletaComandos { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _loading = true;
        _userData = await UserService.GetUserInformation();
        _loading = false;
    }

    private void FazerNada()
    {
    }
}
