using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Categories;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Pages.Shop.Categories;

public partial class CategoriesPage
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ICategoryService CategoryService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    private List<CategoryModel> CategoriesList { get; set; }

    public CategoryModel? SelectedCategory { get; set; }

    private MudTable<CategoryModel> mudTable;

    private int selectedRowNumber = -1;
    private bool _loading;

    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        _loading = true;

        CategoriesList = await CategoryService.GetAllCategories();

        _loading = false;
    }

    private void HandleSelectedCategory(CategoryModel category)
    {
        SelectedCategory = category;
    }

    private void EditCategoryNavigation(CategoryModel category)
    {
        NavigationManager.NavigateTo($"/loja/categorias/editar/{category.Id}");
    }

    private async Task DeleteCategory(CategoryModel category)
    {
        try
        {
            await CategoryService.DeleteCategory(category.Id);
            await LoadCategories();

            _snackbar.Add("Categoria deletada com sucesso!", Severity.Success);
            SelectedCategory = null;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            _snackbar.Add(ex.Message, Severity.Error);
            StateHasChanged();
        }
    }

    private void CloseSelectedCategoryCard()
    {
        SelectedCategory = null;
        StateHasChanged();
    }
}
