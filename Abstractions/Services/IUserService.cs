using WinglyShopAdmin.App.Models.UserData;
using WinglyShopAdmin.App.Services;

namespace WinglyShopAdmin.App.Abstractions.Services;

public interface IUserService
{
    Task<UserBasicInformation> GetUserInformation();
    Task<IEnumerable<UserDataModel>> GetAll();
}
