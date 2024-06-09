using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Services.Shop;

public class CategoryService : ICategoryService
{
    private readonly IHttpService _httpService;

    public CategoryService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        return await _httpService.Get<List<CategoryModel>>("/Categories");
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        return await _httpService.Get<CategoryModel>($"/Categories/{id}");
    }

    public async Task<bool> CreateCategory(CategoryModel category)
    {
        return await _httpService.Post<bool>("/Categories/Create", category);
    }

    public async Task<bool> EditCategory(CategoryModel category)
    {
        return await _httpService.Post<bool>("/Categories/Update", category);
    }

    public async Task<bool> DeleteCategory(int id)
    {
        return await _httpService.Delete<bool>($"/Categories/Delete/{id}");
    }
}
