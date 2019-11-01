using System.Threading.Tasks;
using Refit;
using DotnetConf2019BCN.Mobile.Features.Settings;

namespace DotnetConf2019BCN.Mobile.Features.Home
{
    public interface IHomeAPI
    {
        [Get("/products/landing")]
        Task<LandingDTO> GetAsync([Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader);
    }
}
