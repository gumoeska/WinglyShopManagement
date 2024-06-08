﻿using WinglyShopAdmin.App.Models.Shop.Products;

namespace WinglyShopAdmin.App.Abstractions.Services.Shop;

public interface IProductService
{
    Task<List<ProductModel>> GetAllProducts();
    Task<NewProductModel> GetProductById(int id);
    Task<bool> CreateNewProduct(NewProductModel product);
    Task<bool> EditProduct(NewProductModel product);
    Task<bool> DeleteProduct(int id);
}
