using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Pages.Shop.Categories;

public partial class NewCategoryPage
{
    private CategoryModel CategoryModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
    }

    private void HandleCategoryDataChanged(CategoryModel category)
    {
        CategoryModel = category;
    }
}
