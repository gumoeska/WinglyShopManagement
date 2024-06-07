namespace WinglyShopAdmin.App.Models.Auth.Requests;

public sealed class RegisterRequestModel
{
    // When registering a new account
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // When editing the account data
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Image { get; set; }
    public string Phone { get; set; }
}
