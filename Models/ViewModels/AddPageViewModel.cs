using TaskerApp.Models;
using System.Collections.ObjectModel;


namespace TaskerApp.Models.ViewModels
{
    internal class AddPageViewModel
    {
        // this get and set data
        public string Task { get; set; }
        public ObservableCollection<TTC> Tasks { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

    }
}
