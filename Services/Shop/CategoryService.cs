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
}
