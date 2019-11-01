using Refit;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DotnetConf2019BCN.Mobile.Features.Common;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Scanning.Photo;
using Xamarin.Forms;

[assembly: Dependency(typeof(VisionService))]

namespace DotnetConf2019BCN.Mobile.Features.Scanning.Photo
{
    public class VisionService : IVisionService
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IRestPoolService restPoolService;

        public VisionService()
        {
            authenticationService = DependencyService.Get<IAuthenticationService>();
            restPoolService = DependencyService.Get<IRestPoolService>();
        }

        public async Task<IEnumerable<ProductDTO>> GetRecommendedProductsFromPhotoAsync(string photoPath)
        {
            using (var photoStream = File.Open(photoPath, FileMode.Open))
            {
                var streamPart = new StreamPart(photoStream, "photo.jpg", "image/jpeg");

                return await restPoolService.SimilarProductsAPI.GetSimilarProductsAsync(
                    authenticationService.AuthorizationHeader, streamPart);
            }
        }
    }
}
