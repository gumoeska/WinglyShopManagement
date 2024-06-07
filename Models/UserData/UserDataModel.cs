namespace WinglyShopAdmin.App.Models.UserData;

public sealed class UserDataModel
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Image { get; set; }

    public string? Phone { get; set; }

    public bool? IsActive { get; set; }
    public int? IdRole { get; set; }
}
