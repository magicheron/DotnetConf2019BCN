namespace DotnetConf2019BCN.Mobile.Features.Settings
{
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = new SettingsViewModel();
        }
    }
}
