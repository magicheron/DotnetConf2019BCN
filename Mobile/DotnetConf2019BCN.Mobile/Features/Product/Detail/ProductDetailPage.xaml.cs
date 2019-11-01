using System.Collections.Generic;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.Product.Detail
{
    public partial class ProductDetailPage
    {
        public ProductDetailPage(int productId)
        {
            InitializeComponent();

            BindingContext = new ProductDetailViewModel(productId);
        }

        internal override IEnumerable<VisualElement> GetStateAwareVisualElements() => new VisualElement[]
        {
            refreshButton,
            stateAwareStackLayout,
        };
    }
}
