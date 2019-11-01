using DotnetConf2019BCN.Mobile.Features.Home;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Product.Cart;

namespace DotnetConf2019BCN.Mobile.Features.Common
{
    public class FakeRestPoolService : IRestPoolService
    {
        public IProfilesAPI ProfilesAPI { get; } = new FakeProfilesAPI();

        public IHomeAPI HomeAPI { get; } = new FakeHomeAPI();

        public IProductsAPI ProductsAPI { get; } = new FakeProductsAPI();

        public ILoginAPI LoginAPI { get; } = new FakeLoginAPI();

        public ISimilarProductsAPI SimilarProductsAPI { get; } = new FakeSimilarProductsAPI();

        public IProductCartAPI ProductCartAPI { get; } = new FakeProductCartAPI();

        public void UpdateApiUrl(string newApiUrl)
        {
            // Intentionally blank
        }
    }
}
