using System.Collections.Generic;
using DotnetConf2019BCN.Mobile.Features.Product;

namespace DotnetConf2019BCN.Mobile.Features.Home
{
    public class LandingDTO
    {
        public IEnumerable<ProductDTO> PopularProducts { get; set; }
    }
}