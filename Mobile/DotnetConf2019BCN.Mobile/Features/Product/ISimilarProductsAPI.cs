using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using DotnetConf2019BCN.Mobile.Features.Settings;

namespace DotnetConf2019BCN.Mobile.Features.Product
{
    public interface ISimilarProductsAPI
    {
        [Multipart]
        [Post("/products/imageclassifier")]
        Task<IEnumerable<ProductDTO>> GetSimilarProductsAsync(
            [Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader,
            [AliasAs("file")] StreamPart stream);
    }
}
