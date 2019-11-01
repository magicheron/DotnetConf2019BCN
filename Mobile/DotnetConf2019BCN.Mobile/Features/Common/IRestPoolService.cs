using DotnetConf2019BCN.Mobile.Features.Home;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Product.Cart;

namespace DotnetConf2019BCN.Mobile.Features.Common
{
    public interface IRestPoolService
    {
        IProfilesAPI ProfilesAPI { get; }

        IHomeAPI HomeAPI { get; }

        IProductsAPI ProductsAPI { get; }

        ILoginAPI LoginAPI { get; }

        ISimilarProductsAPI SimilarProductsAPI { get; }

        IProductCartAPI ProductCartAPI { get; }

        void UpdateApiUrl(string newApiUrl);
    }
}