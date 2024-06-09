using WinglyShopAdmin.App.Models.Shop.Categories;
using WinglyShopAdmin.App.Services;

namespace WinglyShopAdmin.App.Abstractions.Services.Shop;

public interface ICategoryService
{
    Task<List<CategoryModel>> GetAllCategories();
    Task<CategoryModel> GetCategoryById(int id);
    Task<bool> CreateCategory(CategoryModel category);
    Task<bool> EditCategory(CategoryModel category);
    Task<bool> DeleteCategory(int id);
}
