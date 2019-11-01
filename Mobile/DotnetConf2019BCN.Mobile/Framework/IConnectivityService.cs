namespace DotnetConf2019BCN.Mobile.Framework
{
    public interface IConnectivityService
    {
        bool IsThereInternet { get; }
    }
}