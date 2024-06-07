using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Abstractions.Services.Shop;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProducts();
    Task<bool> CreateNewProduct(NewProductModel product);
}
