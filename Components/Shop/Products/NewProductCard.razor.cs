using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using WinglyShop.Shared;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Categories;
using WinglyShopAdmin.App.Models.Shop.Products;
using WinglyShopAdmin.App.Services.Shop;

namespace WinglyShopAdmin.App.Components.Shop.Products;

public partial class NewProductCard
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private ICategoryService CategoryService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    [Parameter] public EventCallback<NewProductModel> DataProductChanged { get; set; }

    private NewProductModel _model = new();

    private CategoryModel _categoryModel = new();

    private List<CategoryModel> CategoryList { get; set; } = new();

    private bool _loading;

    private string _error;

    protected override async Task OnInitializedAsync()
    {
        CategoryList = await CategoryService.GetAllCategories();
    }

    private async Task OnDataProductChanged(NewProductModel product)
    {
        await DataProductChanged.InvokeAsync(product);
    }

    private async void HandleValidSubmit()
    {
        _loading = true;
        try
        {
            await ProductService.CreateNewProduct(_model);

            _snackbar.Add("Produto criado com sucesso!", Severity.Success);

            NavigationManager.NavigateTo("/loja/produtos");
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            _snackbar.Add(ex.Message, Severity.Error);
            _loading = false;
            StateHasChanged();
        }
    }

    private void NewProductNavigate()
    {
        NavigationManager.NavigateTo("/loja/produtos/novo");
    }

    private void OnValueChanged(CategoryModel value)
    {
        if (value != null)
        {
            _model.CategoryId = value.Id;
        }
        else
        {
            _model.CategoryId = 0;
        }
    }
}
