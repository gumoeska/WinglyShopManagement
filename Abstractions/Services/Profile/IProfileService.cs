using WinglyShopAdmin.App.Models.Profile;

namespace WinglyShopAdmin.App.Abstractions.Services.Profile;

public interface IProfileService
{
    Task<bool> UpdateProfileInformation(AnyProfileModel profileInfo);
    Task<bool> UpdateAccountInformation(AnyProfileModel accountInfo);
}
