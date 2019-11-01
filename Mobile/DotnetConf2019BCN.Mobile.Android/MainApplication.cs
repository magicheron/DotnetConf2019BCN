using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;
using DotnetConf2019BCN.Mobile.Features.Settings;

[assembly: Xamarin.Forms.ResolutionGroupName(nameof(DotnetConf2019BCN))]

namespace DotnetConf2019BCN.Mobile.Droid
{
    [Application(Debuggable = DefaultSettings.AndroidDebuggable)]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
            : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CrossCurrentActivity.Current.Init(this);
        }
    }
}