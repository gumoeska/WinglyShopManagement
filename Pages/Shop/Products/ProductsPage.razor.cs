using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Shop.Products;

public partial class ProductsPage
{
    [Inject] private NavigationManager NavigationManager { get; set; }
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

    private void EditProductNavigation(ProductModel product)
    {
        NavigationManager.NavigateTo($"/loja/produtos/editar/{product.Id}");
    }

    private async Task DeleteProduct(ProductModel product)
    {
        try
        {
            await ProductService.DeleteProduct(product.Id);
            await LoadProducts();

            _snackbar.Add("Produto deletado com sucesso!", Severity.Success);
            SelectedProduct = null;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            _snackbar.Add(ex.Message, Severity.Error);
            StateHasChanged();
        }
    }

    private void CloseSelectedProductCard()
    {
        SelectedProduct = null;
        StateHasChanged();
    }
}
