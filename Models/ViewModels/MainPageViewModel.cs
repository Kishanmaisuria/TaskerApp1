using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TaskerApp.Models.ViewModels;
using PropertyChanged;


namespace TaskerApp.Models.ViewModels
{


        [AddINotifyPropertyChangedInterface]
        public class MainPageViewModel
        {
        // these link models 
            public ObservableCollection<Category> Categories { get; set; }
            public ObservableCollection<TTC> Tasks { get; set; }

            public MainPageViewModel()
            {
                FileData();
                Tasks.CollectionChanged += Tasks_CollectionChanged;

                // Gets Tasks
                foreach (var category in Categories)
                {
                    category.Tasks = new ObservableCollection<TTC>(Tasks.Where(task => task.CategoryId == category.Id));
                    category.UpdateTotalTasks();
                }
            }

            private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                // Handle task changes
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (TTC task in e.NewItems)
                    {
                        Category category = Categories.FirstOrDefault(c => c.Id == task.CategoryId);
                        if (category != null)
                        {
                            category.Tasks.Add(task);
                            category.PT = category.Tasks.Count(t => !t.Completed);
                            category.PER = (float)category.Tasks.Count(t => t.Completed) / category.Tasks.Count;
                            category.UpdateTotalTasks();
                        }
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (TTC task in e.OldItems)
                    {
                        Category category = Categories.FirstOrDefault(c => c.Id == task.CategoryId);
                        if (category != null)
                        {
                            category.Tasks.Remove(task);
                            category.PT = category.Tasks.Count(t => !t.Completed);
                            category.PER = (float)category.Tasks.Count(t => t.Completed) / category.Tasks.Count;
                            category.UpdateTotalTasks();
                        }
                    }
                }
            }


            private void FileData()
            {
            // Stores data 
                Categories = new ObservableCollection<Category>()
            {
                new Category
                {
                    Id = 1,
                    CN = "Cleaning",
                    Color = "#ff0000"
                },  

                new Category
                {
                    Id = 2,
                    CN = "Bake",
                    Color = "#008000"
                },

                new Category
                {
                    Id = 3,
                    CN = "Marketing",
                    Color = "#007BFF"
                },
                };

                Tasks = new ObservableCollection<TTC>()
            {
                new TTC
            {
                TNAME = "Window cleaning",
                Completed = false,
                    CategoryId = 1,
            },
            new TTC
            {
                TNAME = "Moping",
                Completed = false,
                CategoryId = 1,
            },
            new TTC
            {
                TNAME = "Make baguette",
                Completed = false,
                CategoryId = 2,
            },
            new TTC
            {
                TNAME = "Make Croissant",
                Completed = false,
                CategoryId = 2,
            },
            new TTC
            {
                TNAME = "Buy A3 Paper",
                Completed = false,
                CategoryId = 3,
            },
            new TTC
            {
                TNAME = "Have a meeting with Protine",
                Completed = false,
                CategoryId = 3,
            }
            };
                UpdateData();
            }
        // makes and updata feature
            public void UpdateData()
            {
                foreach (var c in Categories)
                {
                    var tasks = from t in Tasks
                                where t.CategoryId == c.Id
                                select t;

                    var completed = from t in tasks
                                    where t.Completed == true
                                    select t;

                    var noCompleted = from t in tasks
                                      where t.Completed == false
                                      select t;

                    c.PT = noCompleted.Count();
                    c.PER = (float)completed.Count() / (float)tasks.Count();
                }

                foreach (var t in Tasks)
                {
                    var catColor =
                        (
                            from c in Categories
                            where c.Id == t.CategoryId
                            select c.Color
                        ).FirstOrDefault();
                    t.TCOL = catColor;
                }
            }
        }
    
}
