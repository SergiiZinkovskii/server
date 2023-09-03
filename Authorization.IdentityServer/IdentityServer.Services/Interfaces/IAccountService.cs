using IdentityServer.ViewModel;
using Restaurant.Domain.Response;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<Response<ClaimsIdentity>> Login(LoginViewModel model);
        Task<Response<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
