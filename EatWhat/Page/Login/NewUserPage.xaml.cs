
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EatWhat.Page.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        public NewUserPage()
        {
            InitializeComponent();

            BindingContext = new NewUserViewModel();
        }
    }
}