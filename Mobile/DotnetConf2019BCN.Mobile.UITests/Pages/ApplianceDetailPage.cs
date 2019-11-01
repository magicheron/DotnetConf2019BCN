﻿// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace DotnetConf2019BCN.UITests
{
    public class ApplianceDetailPage : BasePage
    {
        private readonly Query addCartButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("shellcontent.scrollview"),
            iOS = x => x.Class("UIImageView").Index(0),
        };

        public ApplianceDetailPage()
        {
            addCartButton = x => x.Marked("ADD TO CART");
        }

        public ApplianceDetailPage AddToCart()
        {
            app.ScrollDownTo(addCartButton);
            app.WaitForElement(addCartButton);
            app.Tap(addCartButton);

            return this;
        }
    }
}
