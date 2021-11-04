using System;
using System.Windows.Input;
using Xamarin.Forms;
using EatWhat.Common;
using EatWhat.Framework;

namespace EatWhat.Page.Login
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        private string email;

        public ForgotPasswordViewModel()
        {
            ResetPasswordCommand = new Command(OnResetPassword);
            SignUpCommand = new Command(SignUp);
        }

        private async void OnResetPassword(object obj)
        {
            try
            {

                var authService = DependencyService.Resolve<IAuthenticationService>();
                await authService.ResetPassword(Email);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Password Reset", "Password recovery sent, check your email", "OK");

                await Xamarin.Forms.Shell.Current
                    .GoToAsync("//LoginPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Password Reset", "An error occurs", "OK");
            }
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private async void SignUp()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }

        public ICommand ResetPasswordCommand { get; }
        public ICommand SignUpCommand { get; }


    }
}
