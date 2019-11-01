using System.Collections.Generic;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.Product.Cart
{
    public partial class ProductCartPage
    {
        public ProductCartPage()
        {
            InitializeComponent();

            BindingContext = new ProductCartViewModel();
        }

        internal override IEnumerable<VisualElement> GetStateAwareVisualElements() => new VisualElement[]
        {
            stateAwareStackLayout,
            emptyLabel,
            errorLabel,
        };
    }
}