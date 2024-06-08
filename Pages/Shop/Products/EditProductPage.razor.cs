using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Shop.Products;

public partial class EditProductPage
{
    [Parameter] public string ProductId { get; set; }

    [Inject] private IProductService ProductService { get; set; }

    private NewProductModel ProductModel { get; set; }
    
    private int _productId;

    protected override async Task OnInitializedAsync()
    {
        _productId = int.TryParse(ProductId, out int convertedId) ? convertedId : 0;

        await LoadProductData(_productId);
    }

    private async Task LoadProductData(int id)
    {
        var product = await ProductService.GetProductById(id);

        HandleProductDataChanged(product);
    }

    private void HandleProductDataChanged(NewProductModel product)
    {
        ProductModel = product;
        StateHasChanged();
    }
}
