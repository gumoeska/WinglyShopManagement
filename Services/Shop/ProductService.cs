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

    public async Task<bool> CreateNewProduct(NewProductModel product)
    {
        return await _httpService.Post<bool>("/Products/Create", product);
    }
}
