using System.Windows.Input;

namespace DotnetConf2019BCN.Mobile.Features.Product
{
    public class ProductViewModel
    {
        public ProductViewModel(ProductDTO product, ICommand command)
        {
            Product = product;
            Command = command;
        }

        public ProductDTO Product { get; }

        public ICommand Command { get; }
    }
}
