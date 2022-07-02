using Auth0.OidcClient;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFwithAuth0.Droid;

[assembly: Dependency(typeof(UserAuthService))]
namespace XFwithAuth0.Droid
{
    public class UserAuthService : IUserAuthService
    {
        private readonly Auth0Client _client;

        public UserAuthService()
        {
            _client = new Auth0Client(new Auth0ClientOptions
            {
                ClientId = Constants.ClientId,
                Domain = Constants.Domain,
            });
        }

        public async Task<LoginResult> Auth0UserLogin()
        {
            return await _client.LoginAsync();
        }

        public async Task<BrowserResultType> Auth0UserLogout()
        {
            return await _client.LogoutAsync();
        }
    }
}
