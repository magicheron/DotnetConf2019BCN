﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using OperationResult;
using Plugin.XSnack;
using DotnetConf2019BCN.Mobile.Features.Common;
using DotnetConf2019BCN.Mobile.Features.Localization;
using DotnetConf2019BCN.Mobile.Features.Logging;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Framework
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected static readonly IAuthenticationService AuthenticationService;
        protected static readonly ILoggingService LoggingService;
        protected static readonly IRestPoolService RestPoolService;
        protected static readonly IXSnack XSnackService;

        private bool isBusy;

        static BaseViewModel()
        {
            AuthenticationService = DependencyService.Get<IAuthenticationService>();
            LoggingService = DependencyService.Get<ILoggingService>();
            RestPoolService = DependencyService.Get<IRestPoolService>();
            XSnackService = DependencyService.Get<IXSnack>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => isBusy;
            set => SetAndRaisePropertyChanged(ref isBusy, value);
        }

        public ICommand FeatureNotAvailableCommand { get; } = new AsyncCommand(ShowFeatureNotAvailableAsync);

        public virtual Task InitializeAsync() => Task.CompletedTask;

        public virtual Task UninitializeAsync() => Task.CompletedTask;

        protected static async Task ShowFeatureNotAvailableAsync()
        {
            await Application.Current.MainPage.DisplayAlert(
                Resources.Alert_Title_FeatureNotAvailable,
                Resources.Alert_Message_DemoApp,
                Resources.Alert_OK);
        }

        protected async Task<Status> TryExecuteWithLoadingIndicatorsAsync(
            Task operation,
            Func<Exception, Task<bool>> onError = null) =>
            await TaskHelper.Create()
                .WhenStarting(() => IsBusy = true)
                .WhenFinished(() => IsBusy = false)
                .TryWithErrorHandlingAsync(operation, onError);

        protected async Task<Result<T>> TryExecuteWithLoadingIndicatorsAsync<T>(
            Task<T> operation,
            Func<Exception, Task<bool>> onError = null) =>
            await TaskHelper.Create()
                .WhenStarting(() => IsBusy = true)
                .WhenFinished(() => IsBusy = false)
                .TryWithErrorHandlingAsync(operation, onError);

        protected void SetAndRaisePropertyChanged<TRef>(
            ref TRef field, TRef value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetAndRaisePropertyChangedIfDifferentValues<TRef>(
            ref TRef field, TRef value, [CallerMemberName] string propertyName = null)
            where TRef : class
        {
            if (field == null || !field.Equals(value))
            {
                SetAndRaisePropertyChanged(ref field, value, propertyName);
            }
        }
    }
}
