using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Extensions;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Shop.Products;

public partial class ProductsPage
{
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    private List<ProductModel> ProductsList { get; set; }

    public ProductModel? SelectedProduct { get; set; }

    private MudTable<ProductModel> mudTable;

    private int selectedRowNumber = -1;
    private bool _loading;

    protected override async Task OnInitializedAsync()
    {
        await LoadProducts();
    }

    private async Task LoadProducts()
    {
        _loading = true;

        ProductsList = await ProductService.GetAllProducts();

        _loading = false;
    }

    private void HandleSelectedProduct(ProductModel product)
    {
        SelectedProduct = product;
    }

    private void CloseSelectedProductCard()
    {
        SelectedProduct = null;
        StateHasChanged();
    }
}
