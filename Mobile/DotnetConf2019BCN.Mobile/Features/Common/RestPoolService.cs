using Refit;
using DotnetConf2019BCN.Mobile.Features.Home;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Product.Cart;
using DotnetConf2019BCN.Mobile.Features.Settings;
using DotnetConf2019BCN.Mobile.Helpers;

namespace DotnetConf2019BCN.Mobile.Features.Common
{
    public class RestPoolService : IRestPoolService
    {
        public IProfilesAPI ProfilesAPI { get; private set; }

        public IHomeAPI HomeAPI { get; private set; }

        public IProductsAPI ProductsAPI { get; private set; }

        public ILoginAPI LoginAPI { get; private set; }

        public ISimilarProductsAPI SimilarProductsAPI { get; private set; }

        // There is no real API for products cart, meanwhile must use a faked one
        public IProductCartAPI ProductCartAPI { get; } = new FakeProductCartAPI();

        public RestPoolService()
        {
            UpdateApiUrl(DefaultSettings.RootApiUrl);

            SimilarProductsAPI = RestService.For<ISimilarProductsAPI>(
                HttpClientFactory.Create(DefaultSettings.RootProductsWebApiUrl));
        }

        public void UpdateApiUrl(string newApiUrl)
        {
            ProfilesAPI = RestService.For<IProfilesAPI>(HttpClientFactory.Create(newApiUrl));
            HomeAPI = RestService.For<IHomeAPI>(HttpClientFactory.Create(newApiUrl));
            ProductsAPI = RestService.For<IProductsAPI>(HttpClientFactory.Create(newApiUrl));
            LoginAPI = RestService.For<ILoginAPI>(HttpClientFactory.Create(newApiUrl));
        }
    }
}
