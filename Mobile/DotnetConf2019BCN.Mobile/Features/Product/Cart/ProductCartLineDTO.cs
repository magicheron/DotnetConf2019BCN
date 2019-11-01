using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetConf2019BCN.Mobile.Features.Product.Cart
{
    public class ProductCartLineDTO
    {
        public int Quantity { get; set; }

        public ProductDTO Product { get; set; }
    }
}
