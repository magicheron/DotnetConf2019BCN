using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public partial class LogInPage
    {
        public LogInPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            BindingContext = new LoginViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
