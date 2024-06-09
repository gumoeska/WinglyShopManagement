using Microsoft.AspNetCore.Components;
using MudBlazor;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Components.Shop.Categories;

public partial class EditCategoryCard
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] private ICategoryService CategoryService { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }

    [Parameter] public EventCallback<CategoryModel> DataCategoryChanged { get; set; }
    [Parameter] public CategoryModel? InitialCategoryData { get; set; }

    private CategoryModel _model = new();

    private CategoryModel _categoryModel = new();

    private List<CategoryModel> CategoryList { get; set; } = new();

    private bool _loading;

    private string _error;

    protected override async Task OnInitializedAsync()
    {
        // Setting the initial product data
        _model = InitialCategoryData;
        StateHasChanged();

        //await OnDataProductChanged(_model);

        CategoryList = await CategoryService.GetAllCategories();
    }

    private async Task OnDataCategoryChanged(CategoryModel product)
    {
        await DataCategoryChanged.InvokeAsync(product);
    }

    private async void HandleValidSubmit()
    {
        _loading = true;
        try
        {
            await CategoryService.EditCategory(_model);

            _snackbar.Add("Categoria alterada com sucesso!", Severity.Success);

            NavigationManager.NavigateTo("/loja/categorias");
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            _snackbar.Add(ex.Message, Severity.Error);
            _loading = false;
            StateHasChanged();
        }
    }

    private void NewCategoryNavigate()
    {
        NavigationManager.NavigateTo("/loja/categorias/nova");
    }

    private void CancelNavigate()
    {
        NavigationManager.NavigateTo("/loja/categorias");
    }

    private async Task OnValueChanged(CategoryModel value)
    {
        if (value != null)
        {
            _model.Id = value.Id;
            _model.Description = value.Description;

        }
        else
        {
            _model.Id = 0;
            _model.Description = string.Empty;
        }

        await OnDataCategoryChanged(_model);
    }
}
