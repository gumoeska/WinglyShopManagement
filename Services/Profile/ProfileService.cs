using WinglyShopAdmin.App.Abstractions.Services;
using WinglyShopAdmin.App.Abstractions.Services.Profile;
using WinglyShopAdmin.App.Models.Profile;

namespace WinglyShopAdmin.App.Services.Profile;

public class ProfileService : IProfileService
{
    private IHttpService _httpService;

    public ProfileService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<bool> UpdateProfileInformation(AnyProfileModel? profileInfo)
    {
        var profileInfoObj = new ProfileInformationModel
        {
            Name = profileInfo?.FirstField ?? string.Empty,
            Surname = profileInfo?.SecondField ?? string.Empty,
            Phone = profileInfo?.ThirdField ?? string.Empty
        };

        return await _httpService.Put<bool>("/Profile/Update-Profile", profileInfoObj);
    }

    public async Task<bool> UpdateAccountInformation(AnyProfileModel? accountInfo)
    {
        var accountInfoObj = new AccountInformationModel
        {
            Email = accountInfo?.FirstField ?? string.Empty,
            Password = accountInfo?.SecondField ?? string.Empty
        };

        return await _httpService.Put<bool>("/Profile/Update-Account", accountInfoObj);
    }
}
