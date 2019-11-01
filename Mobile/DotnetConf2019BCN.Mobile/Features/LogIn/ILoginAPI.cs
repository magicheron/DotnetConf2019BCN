using System.Threading.Tasks;
using Refit;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public interface ILoginAPI
    {
        [Post("/login")]
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);
    }
}
