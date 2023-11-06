using TaskerApp.Models.ViewModels;

namespace TaskerApp.Pages;

public partial class MainPage : ContentPage
{
   // this gets MainPageViewModel 
    private MainPageViewModel _mainViewModel = new MainPageViewModel();
    public MainPage()
    {
        InitializeComponent();
        BindingContext = _mainViewModel;

    }

    // this will update the update the data
    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _mainViewModel.UpdateData();
    }

    // this will add both task and categores
    private void Adding_Clicked(object sender, EventArgs e)
    {
        var taskView = new AddPage()
        {
            BindingContext = new AddPageViewModel
            {
                Tasks = _mainViewModel.Tasks,
                Categories = _mainViewModel.Categories
            }
        };

        if (taskView != null)
        {
            Navigation.PushAsync(taskView);
        }
        else
        {
            DisplayAlert("ERROR", "Loading page", "Ok");
        }


    }
}