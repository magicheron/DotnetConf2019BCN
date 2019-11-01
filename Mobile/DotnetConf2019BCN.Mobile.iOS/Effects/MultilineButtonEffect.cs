using DotnetConf2019BCN.Mobile.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(
    typeof(DotnetConf2019BCN.Mobile.IOS.Effects.MultilineButtonEffect), nameof(MultilineButtonEffect))]

namespace DotnetConf2019BCN.Mobile.IOS.Effects
{
    public class MultilineButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var button = Control as UIButton;
            button.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
        }

        protected override void OnDetached()
        {
        }
    }
}
