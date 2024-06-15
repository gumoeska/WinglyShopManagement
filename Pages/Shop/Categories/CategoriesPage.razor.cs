using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Helpers;
using WinglyShopAdmin.App.Models.Shop.Categories;
using WinglyShopAdmin.App.Models.Shop.Products;
using WinglyShopAdmin.App.Services.Shop;

namespace WinglyShopAdmin.App.Pages.Shop.Categories;

public partial class CategoriesPage
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ICategoryService CategoryService { get; set; }
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    private List<CategoryModel> CategoriesList { get; set; } = new();
    private List<NewProductModel> ProductList { get; set; } = new();

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

        var CategoriesListRequest = await CategoryService.GetAllCategories();

        if (!CategoriesListRequest.IsNullOrEmpty())
        {
            CategoriesList = CategoriesListRequest;
        }

        _loading = false;
    }

    private async Task HandleSelectedCategory(CategoryModel category)
    {
        // Buscar lista de Produtos desta categoria
        ProductList = await ProductService.GetProductsByCategoryId(category.Id);

        SelectedCategory = category;
    }

    private void EditCategoryNavigation(CategoryModel category)
    {
        NavigationManager.NavigateTo($"/cadastro/categorias/editar/{category.Id}");
    }

    private async Task UnlinkCategoryProductsNavigation(CategoryModel category)
    {
        try
        {
            await ProductService.UnlinkCategoryProducts(category.Id);
            await LoadCategories();

            _snackbar.Add("Produtos desvinculados da Categoria com sucesso!", Severity.Success);
            SelectedCategory = null;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            _snackbar.Add(ex.Message, Severity.Error);
            StateHasChanged();
        }
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
