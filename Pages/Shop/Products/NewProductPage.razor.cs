using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Shop.Products;

public partial class NewProductPage
{
    private NewProductModel ProductModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
    }

    private void HandleProductDataChanged(NewProductModel product)
    {
        ProductModel = product;
    }
}
