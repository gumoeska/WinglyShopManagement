using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Common.Enums;
using WinglyShopAdmin.App.Models.SideMenu;

namespace WinglyShopAdmin.App.Components.Shared;

public partial class SideMenu
{
    private List<MenuSectionModel> _menuSections = new()
    {
        new MenuSectionModel
        {
            Title = "Menu",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "Início",
                    Icon = Icons.Material.Filled.Home,
                    Href = ""
                }
            }
        },

        new MenuSectionModel
        {
            Title = "Cadastro",
            SectionItems = new List<MenuSectionItemModel>
            {
                // Produtos
                new()
                {
                    Title = "Produtos",
                    Icon = Icons.Material.Filled.ShoppingCart,
                    Href = "/cadastro/produtos"
                },

                // Categorias
                new()
                {
                    Title = "Categorias",
                    Icon = Icons.Material.Filled.Category,
                    Href = "/cadastro/categorias"
                }
            }
        },

        new MenuSectionModel
        {
            Title = "Loja",
            SectionItems = new List<MenuSectionItemModel>
            {
                // Produtos
                new()
                {
                    Title = "Pedidos",
                    Icon = Icons.Material.Filled.Assignment,
                    Href = "/loja/pedidos"
                },

                // Categorias
                new()
                {
                    Title = "Entregas",
                    Icon = Icons.Material.Filled.DeliveryDining,
                    Href = "/loja/entregas"
                }
            }
        },

        new MenuSectionModel
        {
            Title = "Usuários",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "Contas",
                    Icon = Icons.Material.Filled.PeopleAlt,
                    Href = "/usuarios/contas"
                },

                new()
                {
                    Title = "Autorizações",
                    Icon = Icons.Material.Filled.VerifiedUser,
                    Href = "/usuarios/autorizacoes"
                },
            }
        },

        new MenuSectionModel
        {
            Title = "Dashboard",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "Vendas",
                    Icon = Icons.Material.Filled.Sell,
                    Href = "/dashboard/vendas",
                    PageStatus = PageStatus.EmBreve
                },

                new()
                {
                    Title = "Prospecção de Clientes",
                    Icon = Icons.Material.Filled.PersonSearch,
                    Href = "/dashboard/prospeccao-clientes",
                    PageStatus = PageStatus.EmBreve
                },
            }
        }
    };

    [EditorRequired]
    [Parameter]
    public bool SideMenuDrawerOpen { get; set; }

    [EditorRequired]
    [Parameter]
    public EventCallback<bool> SideMenuDrawerOpenChanged { get; set; }

    [EditorRequired]
    [Parameter]
    public bool CanMiniSideMenuDrawer { get; set; }

    [EditorRequired]
    [Parameter]
    public EventCallback<bool> CanMiniSideMenuDrawerChanged { get; set; }
}
