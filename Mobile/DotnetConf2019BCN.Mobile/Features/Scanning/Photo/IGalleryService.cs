using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetConf2019BCN.Mobile.Features.Scanning.Photo
{
    public interface IGalleryService
    {
        Task<List<string>> GetGalleryPhotosAsync(int photoCount = 10);
    }
}
