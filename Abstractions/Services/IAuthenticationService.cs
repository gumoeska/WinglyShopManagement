using WinglyShopAdmin.App.Models;

namespace WinglyShopAdmin.App.Abstractions.Services;

public interface IAuthenticationService
{
    User User { get; }
    Task Initialize();
    Task Login(string username, string password);
    Task Register(string username, string password, string email);
    Task Logout();
}
