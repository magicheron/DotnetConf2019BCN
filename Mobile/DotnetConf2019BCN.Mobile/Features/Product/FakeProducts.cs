using System.Collections.Generic;
using Newtonsoft.Json;
using DotnetConf2019BCN.Mobile.Helpers;

namespace DotnetConf2019BCN.Mobile.Features.Product
{
    public static class FakeProducts
    {
        public static IEnumerable<ProductDTO> Fakes => 
            JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(
                EmbeddedResourceHelper.Load("DotnetConf2019BCN.Mobile.Features.Product.FakeProducts.json"));
    }
}
