using Microsoft.AspNetCore.Components;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Pages.Shop.Categories;

public partial class EditCategoryPage
{
    [Parameter] public string CategoryId { get; set; }

    [Inject] private ICategoryService CategoryService { get; set; }

    private CategoryModel CategoryModel { get; set; }
    
    private int _categoryId;

    protected override async Task OnInitializedAsync()
    {
        _categoryId = int.TryParse(CategoryId, out int convertedId) ? convertedId : 0;

        await LoadCategoryData(_categoryId);
    }

    private async Task LoadCategoryData(int id)
    {
        var category = await CategoryService.GetCategoryById(id);

        HandleCategoryDataChanged(category);
    }

    private void HandleCategoryDataChanged(CategoryModel category)
    {
        CategoryModel = category;
        StateHasChanged();
    }
}
