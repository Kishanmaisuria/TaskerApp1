using TaskerApp.Pages;
using TaskerApp.Models.ViewModels;

namespace TaskerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            BindingContext = new MainPageViewModel();
        }
    }
}