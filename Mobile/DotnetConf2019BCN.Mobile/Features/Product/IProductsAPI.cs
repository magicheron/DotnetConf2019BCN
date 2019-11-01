using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using DotnetConf2019BCN.Mobile.Features.Settings;

namespace DotnetConf2019BCN.Mobile.Features.Product
{
    public interface IProductsAPI
    {
        [Get("/products/{id}")]
        Task<ProductDTO> GetDetailAsync(
            [Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader, string id);

        [Get("/products")]
        Task<ProductsPerTypeDTO> GetProductsAsync(
            [Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader, string type);
    }
}
