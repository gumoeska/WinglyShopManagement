using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Abstractions.Services.Shop;
using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Services.Shop;

public class ProductService : IProductService
{
    private readonly IHttpService _httpService;

    public ProductService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        return await _httpService.Get<List<ProductModel>>("/Products");
    }

    public async Task<NewProductModel> GetProductById(int id)
    {
        return await _httpService.Get<NewProductModel>($"/Products/{id}");
    }

    public async Task<bool> CreateNewProduct(NewProductModel product)
    {
        return await _httpService.Post<bool>("/Products/Create", product);
    }

    public async Task<bool> EditProduct(NewProductModel product)
    {
        return await _httpService.Post<bool>("/Products/Update", product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        return await _httpService.Delete<bool>($"/Products/Delete/{id}");
    }
}
