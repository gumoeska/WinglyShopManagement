using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Models.Profile;
using WinglyShopAdmin.App.Models.UserData;

namespace WinglyShopAdmin.App.Services;

public class UserService : IUserService
{
    private IHttpService _httpService;

    public UserService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<UserBasicInformation> GetUserInformation()
    {
        return await _httpService.Get<UserBasicInformation>("/Auth/profile");
    }

    public async Task<UserFullAccountInformationModel> GetUserFullAccountInformation()
    {
        return null;
        //return await _httpService.Get<>("/");
    }

    public async Task<IEnumerable<UserDataModel>> GetAll()
    {
        return await _httpService.Get<IEnumerable<UserDataModel>>("/Users");
    }
}
