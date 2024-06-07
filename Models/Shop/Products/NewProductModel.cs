using System.ComponentModel.DataAnnotations;

namespace WinglyShopAdmin.App.Models.Shop.Products;

public class NewProductModel
{
    [Required]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public bool HasStock { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public string HasStockString() => HasStock ? "Sim" : "Não";

    public string GetDefaultDescription() => (string.IsNullOrWhiteSpace(Description)) ? "Produto sem nome" : Description;

    public string GetDefaultCode() => (string.IsNullOrWhiteSpace(Code)) ? "001" : Code;

    public decimal GetDefaultValue() => (Price == decimal.Zero) ? decimal.Zero : Price;

    public char GetAvatarDescription() => (string.IsNullOrWhiteSpace(Description)) ? 'P' : Description[0];
}
