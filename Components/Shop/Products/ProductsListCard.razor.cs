using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Components.Shop.Products;

public partial class ProductsListCard
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public List<ProductModel> ProductsList { get; set; }

    [Parameter] public EventCallback<ProductModel> SelectedProductChanged { get; set; }

    private MudTable<ProductModel> mudTable;

    private async Task RowClickEvent(TableRowClickEventArgs<ProductModel> tableRowClickEventArgs)
    {
        await OnSelectedProductChanged(tableRowClickEventArgs.Item);
    }

    private async Task OnSelectedProductChanged(ProductModel product)
    {
        await SelectedProductChanged.InvokeAsync(product);
    }

    private void NewProductNavigate()
    {
        NavigationManager.NavigateTo("/loja/produtos/novo");
    }
}
