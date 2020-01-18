﻿namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Servicios
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Propiedades
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructores
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Metodos
        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopToRootAsync();     // Navegar hacia atras
                return;
            }

            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }
        #endregion

        #region Metodos
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }

        #endregion

        #region Comandos
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel().Where
                        (l => l.Name.ToLower().Contains(this.Filter.ToLower()) || l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
