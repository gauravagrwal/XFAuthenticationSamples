using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System.Threading.Tasks;

namespace XFwithAuth0
{
    public interface IUserAuthService
    {
        Task<LoginResult> Auth0UserLogin();
        Task<BrowserResultType> Auth0UserLogout();
    }
}
