namespace WinglyShopAdmin.App.Models.Shop.Categories;

public class CategoryModel
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
