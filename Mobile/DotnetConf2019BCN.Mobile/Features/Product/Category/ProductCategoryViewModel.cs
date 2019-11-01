﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DotnetConf2019BCN.Mobile.Features.Product.Cart;
using DotnetConf2019BCN.Mobile.Features.Product.Detail;
using DotnetConf2019BCN.Mobile.Framework;
using Xamarin.Forms;

namespace DotnetConf2019BCN.Mobile.Features.Product.Category
{
    public class ProductCategoryViewModel : BaseStateAwareViewModel<ProductCategoryViewModel.State>
    {
        private readonly string typeId;

        public enum State
        {
            EverythingOK,
            Error,
            Empty,
        }

        private bool isAlreadyInitialized;
        private string title;
        private IEnumerable<ProductDTO> products;

        public string Title
        {
            get => title;
            set => SetAndRaisePropertyChanged(ref title, value);
        }

        public IEnumerable<ProductDTO> Products
        {
            get => products;
            set => SetAndRaisePropertyChanged(ref products, value);
        }

        public ICommand LoadCommand { get; }

        public ICommand DetailCommand { get; }

        public ICommand CartCommand => new AsyncCommand(_ => App.NavigateToAsync(new ProductCartPage()));

        public ProductCategoryViewModel(string typeId)
        {
            this.typeId = typeId;

            LoadCommand = new AsyncCommand(() => LoadDataAsync(typeId));
            DetailCommand = new Command<int>(
                productId => App.NavigateToAsync(new ProductDetailPage(productId)).ConfigureAwait(false));
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (isAlreadyInitialized)
            {
                return;
            }

            isAlreadyInitialized = true;
            LoadCommand.Execute(null);
        }

        private async Task LoadDataAsync(string type)
        {
            CurrentState = State.EverythingOK;
            Products = null;

            var response = await TryExecuteWithLoadingIndicatorsAsync(
                RestPoolService.ProductsAPI.GetProductsAsync(AuthenticationService.AuthorizationHeader, type));

            if (response.IsError)
            {
                CurrentState = State.Error;
                return;
            }

            if (response.Value == null || response.Value.Products == null || !response.Value.Products.Any())
            {
                CurrentState = State.Empty;
                return;
            }

            Products = response.Value.Products;
            Title = products.First().Type.Name;
        }
    }
}
