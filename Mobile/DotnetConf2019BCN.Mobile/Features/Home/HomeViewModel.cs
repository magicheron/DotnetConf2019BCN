﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DotnetConf2019BCN.Mobile.Features.Localization;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Product;
using DotnetConf2019BCN.Mobile.Features.Product.Cart;
using DotnetConf2019BCN.Mobile.Features.Scanning.AR;
using DotnetConf2019BCN.Mobile.Features.Scanning.Photo;
using DotnetConf2019BCN.Mobile.Framework;
using DotnetConf2019BCN.Mobile.Helpers;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.Home
{
    public class HomeViewModel : BaseStateAwareViewModel<HomeViewModel.State>
    {
        public enum State
        { 
            EverythingOK,
            Error,
        }

        private IEnumerable<Tuple<string, string, ICommand>> recommendedProducts;
        private IEnumerable<ProductViewModel> popularProducts;
        private IEnumerable<ProductDTO> previouslySeenProducts;

        public HomeViewModel()
        {
            IsBusy = true;

            MessagingCenter.Subscribe<LoginViewModel>(
                this,
                LoginViewModel.LogInFinishedMessage,
                _ => LoadCommand.Execute(null));
        }

        public bool IsNoOneLoggedIn => !AuthenticationService.IsAnyOneLoggedIn;

        public IEnumerable<Tuple<string, string, ICommand>> RecommendedProducts
        {
            get => recommendedProducts;
            set => SetAndRaisePropertyChanged(ref recommendedProducts, value);
        }

        public IEnumerable<ProductViewModel> PopularProducts
        {
            get => popularProducts;
            set => SetAndRaisePropertyChanged(ref popularProducts, value);
        }

        public IEnumerable<ProductDTO> PreviouslySeenProducts
        {
            get => previouslySeenProducts;
            set => SetAndRaisePropertyChanged(ref previouslySeenProducts, value);
        }

        public ICommand PhotoCommand => new AsyncCommand(_ => App.NavigateToAsync(
            new CameraPreviewTakePhotoPage()));

        public ICommand ARCommand => new AsyncCommand(_ => App.NavigateToAsync(new CameraPreviewPage()));

        public ICommand LoadCommand => new AsyncCommand(_ => LoadDataAsync());

        public ICommand CartCommand => new AsyncCommand(_ => App.NavigateToAsync(new ProductCartPage()));

        public ICommand AddToCartCommand => new AsyncCommand((product) => AddProductToCartAsync(product));

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (IsNoOneLoggedIn)
            {
                await App.NavigateModallyToAsync(new LogInPage());
                IsBusy = false;
            }
        }

        public override async Task UninitializeAsync()
        {
            await base.UninitializeAsync();
        }

        private async Task LoadDataAsync()
        {
            CurrentState = State.EverythingOK;

            RecommendedProducts = new List<Tuple<string, string, ICommand>>
            {
                Tuple.Create("Power Tools", "recommended_powertools.jpg", FeatureNotAvailableCommand),
                Tuple.Create("Plants", "recommended_plants.jpg", FeatureNotAvailableCommand),
                Tuple.Create("Bathrooms", "recommended_bathrooms.jpg", FeatureNotAvailableCommand),
                Tuple.Create("Lighting", "recommended_lighting.jpg", FeatureNotAvailableCommand),
            };

            var homeResult = await TryExecuteWithLoadingIndicatorsAsync(
                RestPoolService.HomeAPI.GetAsync(AuthenticationService.AuthorizationHeader));

            if (homeResult.IsError || homeResult.Value == null || homeResult.Value.PopularProducts == null)
            {
                CurrentState = State.Error;
                return;
            }

            var popularProductsRaw = homeResult.Value.PopularProducts;
            var popularProductsWithCommand = popularProductsRaw.Select(
                item => new ProductViewModel(item, AddToCartCommand));
            PopularProducts = new List<ProductViewModel>(popularProductsWithCommand);

            var randomProducts = popularProductsRaw.Shuffle().Take(3);
            PreviouslySeenProducts = new List<ProductDTO>(randomProducts);
        }

        private async Task AddProductToCartAsync(object product)
        {
            if (product as ProductDTO != null)
            {
                await TryExecuteWithLoadingIndicatorsAsync(
                    RestPoolService.ProductCartAPI.AddProductAsync((ProductDTO)product));

                XSnackService.ShowMessage(Resources.Snack_Message_AddedToCart_OK);
            }
            else
            {
                XSnackService.ShowMessage(Resources.Snack_Message_AddedToCart_Error);
            }
        }
    }
}
