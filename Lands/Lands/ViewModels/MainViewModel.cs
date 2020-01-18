namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Helpers;

    public class MainViewModel
    {
        #region Propiedades
        public List<Land> LandsList
        {
            get;
            set;
        }

        public string Token { get; set; }

        public string TokenType { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get; set;
        }
        public LandsViewModel Lands
        {
            get; set;
        }
        public LandViewModel Land
        {
            get; set;
        }

        public RegisterViewModel Register
        {
            get; set;
        }
        #endregion

        #region Contructores
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Metodos
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title=Languages.MyProfile
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart_outlined",
                PageName = "StatisticsPage",
                Title = Languages.Statistics
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_transit_enterexit",
                PageName = "LoginPage",
                Title = Languages.LogOut
            });
        } 
        #endregion
    }
}
