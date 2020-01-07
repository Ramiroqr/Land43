using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Attibutes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "ram@gmail.com";
            this.Password = "123";
        }
        #endregion

        #region Commansd
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }
        #endregion

        #region Methods
        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email...",
                    "Accept");
                return;
            }

            if(string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;
            
            if(this.Email != "ram@gmail.com"  || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrect...",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
