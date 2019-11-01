using System;
using DotnetConf2019BCN.Mobile.Features.Localization;
using DotnetConf2019BCN.Mobile.Framework;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private string rootApiUrl;

        public string RootApiUrl
        {
            get => rootApiUrl;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref rootApiUrl, value);
        }

        public Command SaveCommand { get; }

        public SettingsViewModel()
        {
            rootApiUrl = DefaultSettings.RootApiUrl;

            SaveCommand = new Command(Save);
        }

        private void Save()
        {
            if (!Uri.IsWellFormedUriString(RootApiUrl, UriKind.Absolute))
            {
                XSnackService.ShowMessage(Resources.Snack_Message_InvalidAbsoluteURL);
                return;
            }

            DefaultSettings.RootApiUrl = rootApiUrl;

            RestPoolService.UpdateApiUrl(rootApiUrl);

            XSnackService.ShowMessage(Resources.Snack_Message_SettingsSaved);
        }
    }
}
