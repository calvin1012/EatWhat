using EatWhat.Common;
using EatWhat.Framework;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EatWhat.Page.Login
{
    public class NewUserViewModel : BaseViewModel
    {
        private string password;
        private string email;
        private string username;

        public NewUserViewModel()
        {
            RegisterCommand = new Command(Register);
            SignUpCommand = new Command(OnSignUp);
        }

        private async void Register()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                if (await authService.CreateUser(Username, Email, Password))
                {
                    await Xamarin.Forms.Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    Console.WriteLine("A problem occurs when creating a user");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Create User", "An error occurs", "OK");
            }
        }

        private async void OnSignUp()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }

        #region Properties
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        #endregion

        public ICommand SignUpCommand { get; }
        public ICommand RegisterCommand { get; }
    }
}