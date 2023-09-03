using IdentityServer.ViewModel;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Response;

namespace IdentityServer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResponse<User>> CreateAsync(UserViewModel model);
        Response<Dictionary<int, string>> GetRoles();
        Task<Response<IEnumerable<UserViewModel>>> GetUsersAsync();
        Task<IResponse<bool>> DeleteUserAsync(long id);
    }
}
