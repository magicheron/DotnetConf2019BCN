﻿using System;
using Xamarin.UITest;

namespace DotnetConf2019BCN.UITests
{
    internal static class AppManager
    {
        private const string UITestAndroidPath = "../../../DotnetConf2019BCN.Mobile.Android/bin/UITEST/";
        private const string ApkPath = UITestAndroidPath + "com.microsoft.DotnetConf2019BCN-Signed.apk";

        private const string UITestiOSPath = "../../../DotnetConf2019BCN.Mobile.iOS/bin/iPhone/UITEST/";
        private const string AppPath = UITestiOSPath + "DotnetConf2019BCN.Mobile.iOS.app";
        private const string IpaFileName = "DotnetConf2019BCN.Mobile.iOS.ipa";

        private static IApp app;

        public static IApp App
        {
            get
            {
                if (app == null)
                {
                    throw new NullReferenceException(
                        "'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                }

                return app;
            }
        }

        private static Platform? platform;

        public static Platform Platform
        {
            get
            {
                if (platform == null)
                {
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                }

                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .ApkFile(ApkPath) // Used to run a .apk file
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS

                    // .AppBundle(AppPath) // Used to run a .app file on an ios simulator
                    .InstalledApp(IpaFileName) // Used to run a .ipa file on a physical ios device
                    .StartApp();
            }
        }
    }
}
