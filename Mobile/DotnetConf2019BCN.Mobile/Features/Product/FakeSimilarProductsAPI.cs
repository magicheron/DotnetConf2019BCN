using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DotnetConf2019BCN.Mobile.Features.Product
{
    public class FakeSimilarProductsAPI : ISimilarProductsAPI
    {
        public Task<IEnumerable<ProductDTO>> GetSimilarProductsAsync(
            [Header("Authorization")] string authorizationHeader,
            [AliasAs("file")] StreamPart stream)
        {
            var result = new List<ProductDTO>();
            result.Add(new ProductDTO() {
                ImageUrl = "http://www.biodelicies.com/Content/Images/Productes/Cookies/CookiesCoco.jpg",
                Name = "Cookie Coco",
                Price = 2.30f,
                Type = new TypeDTO(),
                Brand = new BrandDTO(),
                Features = new List<FeatureDTO>()
            });

            return Task.FromResult<IEnumerable<ProductDTO>>(result);
        }
    }
}