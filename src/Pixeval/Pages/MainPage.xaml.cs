﻿using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Pixeval.ViewModel;

namespace Pixeval.Pages
{
    // This class cannot be put inside the MainPage due to the property of x:Bind
    public sealed class MainPageRootNavigationViewTag
    {
        public Type NavigateTo { get; }

        public object Parameter { get; }

        public MainPageRootNavigationViewTag(Type navigateTo, object parameter)
        {
            NavigateTo = navigateTo;
            Parameter = parameter;
        }

        public static readonly MainPageRootNavigationViewTag Recommends = new(typeof(RecommendsPage), App.MakoClient.Recommends());

        public static readonly MainPageRootNavigationViewTag Settings = new(typeof(SettingsPage), App.MakoClient.Configuration);
    }

    public sealed partial class MainPage
    {
        private readonly MainPageViewModel _viewModel = new();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void MainPageRootNavigationView_OnLoaded(object sender, RoutedEventArgs e)
        {
            SetMainPageRootNavigationViewItem(RecommendationTab);
        }

        private void MainPageRootNavigationView_OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem {Tag: MainPageRootNavigationViewTag tag})
            {
                MainPageRootFrame.Navigate(tag.NavigateTo, tag.Parameter, new DrillInNavigationTransitionInfo());
            }
        }

        #region Helper Functions

        private void SetMainPageRootNavigationViewItem(NavigationViewItem navigationViewItem)
        {
            MainPageRootNavigationView.SelectedItem = navigationViewItem;
        }

        #endregion
    }
}
