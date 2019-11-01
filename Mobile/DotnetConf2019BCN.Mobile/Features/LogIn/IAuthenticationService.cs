using System.Threading.Tasks;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public interface IAuthenticationService
    {
        string AuthorizationHeader { get; }

        bool IsAnyOneLoggedIn { get; }

        Task LogInAsync(string email, string password);
    }
}