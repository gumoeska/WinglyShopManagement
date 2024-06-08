namespace WinglyShopAdmin.App.Models.Shop.Products;

public sealed class ProductModel
{
    // Product data
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool HasStock { get; set; }

    // Product category data
    public int IdCategory { get; set; }
    public string? CategoryDescription { get; set; }

    // Methods
    public string HasStockString() => HasStock ? "Sim" : "Não";
}
