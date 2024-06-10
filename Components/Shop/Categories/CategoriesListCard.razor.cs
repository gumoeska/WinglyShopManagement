using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Components.Shop.Categories;

public partial class CategoriesListCard
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public List<CategoryModel>? CategoriesList { get; set; }
    [Parameter] public EventCallback<CategoryModel> SelectedCategoryChanged { get; set; }
    [Parameter] public bool LoadingParam { get; set; }

    private MudTable<CategoryModel> mudTable;

    private async Task RowClickEvent(TableRowClickEventArgs<CategoryModel> tableRowClickEventArgs)
    {
        await OnSelectedCategoryChanged(tableRowClickEventArgs.Item);
    }

    private async Task OnSelectedCategoryChanged(CategoryModel category)
    {
        await SelectedCategoryChanged.InvokeAsync(category);
    }

    private void NewCategoryNavigate()
    {
        NavigationManager.NavigateTo("/loja/categorias/nova");
    }
}
