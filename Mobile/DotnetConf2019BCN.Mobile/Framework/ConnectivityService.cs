using DotnetConf2019BCN.Mobile.Framework;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectivityService))]

namespace DotnetConf2019BCN.Mobile.Framework
{
    internal class ConnectivityService : IConnectivityService
    {
        public bool IsThereInternet => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
