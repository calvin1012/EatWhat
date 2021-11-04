using EatWhat.Common;
using EatWhat.Framework;
using System;
using Xamarin.Forms;

namespace EatWhat.Page.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            CheckWhetherTheUserIsSignIn();
        }

        private async void CheckWhetherTheUserIsSignIn()
        {
            try
            {
                var authenticationService = DependencyService.Resolve<IAuthenticationService>();
                if (!authenticationService.IsSignIn())
                {
                    await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}