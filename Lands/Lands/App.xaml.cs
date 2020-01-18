﻿namespace Lands
{

    using Views;
    using ViewModels;
    using Xamarin.Forms;
    using Helpers;

    public partial class App : Application
    {
        #region Propiedades
        public static NavigationPage Navigator
        {
            get;
            internal set;
        } 
        #endregion

        #region Constructores
        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else 
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Lands = new LandsViewModel();
                this.MainPage = new MasterPage();
            }
        }
        #endregion

        #region Metodos
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
