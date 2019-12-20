namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class MainViewModel
    {
        #region Propiedades
        public List<Land> LandsList
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
        #endregion

        #region Contructores
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
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
    }
}
