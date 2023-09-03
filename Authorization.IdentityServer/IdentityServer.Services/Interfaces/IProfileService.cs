
using IdentityServer.ViewModel;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Response;

namespace IdentityServer.Services.Interfaces
{
    public interface IProfileService
    {
        Task<Response<ProfileViewModel>> GetProfile(string userName);
        Task<Response<Profile>> Save(ProfileViewModel model);
    }
}
