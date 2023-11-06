using System.Threading.Tasks;
using TaskerApp.Models;
using TaskerApp.Models.ViewModels;

namespace TaskerApp.Pages;

public partial class AddPage : ContentPage
{
    public AddPage()
    {
        InitializeComponent();
    }

    // this will update tasks
    private async void AddTask_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as AddPageViewModel;
        var selectedCategory = vm.Categories.Where(x => x.ISS).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new TTC
            {
                TNAME = vm.Task,
                CategoryId = selectedCategory.Id,
                TCOL = selectedCategory.Color
            };

            vm.Tasks.Add(task);

            // Manually call UpdateData from MainViewModel
            var mainViewModel = App.Current.MainPage.BindingContext as MainPageViewModel;
            mainViewModel.UpdateData();

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Invalid Selection", "You must select a category", "OK");
        }
    }
    // this will Update categories
    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as AddPageViewModel;

        string category = await DisplayPromptAsync("New Category", "Write the category name", maxLength: 50, keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(category))
        {
            var random = new Random(); // this makes instance of random

            var newCategory = new Category
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)).ToHex(), // this will create random color
                CN = category
            };
            vm.Categories.Add(newCategory);

            // Manually call UpdateData from MainViewModel
            var mainViewModel = App.Current.MainPage.BindingContext as MainPageViewModel;
            mainViewModel.UpdateData();
        }
    }
}