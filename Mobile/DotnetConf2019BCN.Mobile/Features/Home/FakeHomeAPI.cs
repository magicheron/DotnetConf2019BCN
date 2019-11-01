using System.Threading.Tasks;
using Refit;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Settings;
using DotnetConf2019BCN.Mobile.Helpers;

namespace DotnetConf2019BCN.Mobile.Features.Home
{
    public class FakeHomeAPI : IHomeAPI
    {
        public Task<LandingDTO> GetAsync([Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader)
            => FakeNetwork.ReturnAsync(new LandingDTO { PopularProducts = FakeProducts.Fakes, });
    }
}
