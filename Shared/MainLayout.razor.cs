using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using System;
using Microsoft.AspNetCore.Components.Routing;
using WinglyShopAdmin.App.Abstractions.Services;

namespace WinglyShopAdmin.App.Shared;

public partial class MainLayout
{
    [Inject] private NavigationManager NavigationManager { get; set; }

    [Inject] private IAuthenticationService AuthenticationService { get; set; }

    private bool _canMiniSideMenuDrawer = true;
    private bool _sideMenuDrawerOpen;
}
