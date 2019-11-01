using System.Windows.Input;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product.Category;
using DotnetConf2019BCN.Mobile.Features.Scanning.AR;
using DotnetConf2019BCN.Mobile.Features.Scanning.Photo;
using DotnetConf2019BCN.Mobile.Features.Settings;
using DotnetConf2019BCN.Mobile.Framework;

namespace DotnetConf2019BCN.Mobile.Features.Shell
{
    internal class TheShellViewModel : BaseViewModel
    {
        public ICommand PhotoCommand => new AsyncCommand(
            _ => App.NavigateModallyToAsync(new CameraPreviewTakePhotoPage(), animated: false));

        public ICommand ARCommand => new AsyncCommand(
            _ => App.NavigateToAsync(new CameraPreviewPage(), closeFlyout: true));

        public ICommand LogOutCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new LogInPage()));

        public ICommand ProductTypeCommand => new AsyncCommand(
            typeId => App.NavigateToAsync(new ProductCategoryPage(typeId as string), closeFlyout: true));

        public ICommand ProfileCommand => FeatureNotAvailableCommand;

        public ICommand SettingsCommand => new AsyncCommand(
            _ => App.NavigateToAsync(new SettingsPage(), closeFlyout: true));
    }
}