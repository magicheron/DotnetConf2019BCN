using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetConf2019BCN.Mobile.Features.Product;

namespace DotnetConf2019BCN.Mobile.Features.Scanning.Photo
{
    public interface IVisionService
    {
        Task<IEnumerable<ProductDTO>> GetRecommendedProductsFromPhotoAsync(string photoPath);
    }
}
