using WinglyShopAdmin.App.Models.Shop.Categories;

namespace WinglyShopAdmin.App.Abstractions.Services.Shop;

public interface ICategoryService
{
    Task<List<CategoryModel>> GetAllCategories();
}
