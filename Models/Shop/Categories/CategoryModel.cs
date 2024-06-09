namespace WinglyShopAdmin.App.Models.Shop.Categories;

public class CategoryModel
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string IsActiveString() => IsActive ? "Sim" : "Não";

    public string GetDefaultDescription() => (string.IsNullOrWhiteSpace(Description)) ? "Categoria sem nome" : Description;

    public string GetDefaultCode() => (string.IsNullOrWhiteSpace(Code)) ? "001" : Code;

    public char GetAvatarDescription() => (string.IsNullOrWhiteSpace(Description)) ? 'P' : Description[0];
}
