﻿namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class MenuItemViewModel
    {
        #region Propiedades
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; } 
        #endregion

        #region Comandos
        public ICommand NavigateCommand 
        {
            get 
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            if (this.PageName=="LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
        #endregion
    }
}
