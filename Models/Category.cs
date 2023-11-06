using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskerApp.Models
{
    [AddINotifyPropertyChangedInterface]

    public class Category
    {
        //CN = Category Name
        public string CN { get; set; }

        // PT = Pending Tasks
        public int PT { get; set; }

        //PER = Percentage
        public float PER { get; set; }

        //ISS = IsSelected
        public bool ISS { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }


        public ObservableCollection<TTC> Tasks { get; set; }

        // tot = totalTasks
        private int tot;

        //TOT = TotalTasks 
        public int TOT
        {
            get { return tot; }
            set
            {
                if (tot != value)
                {
                    tot = value;
                }
            }
        }

        public Category()
        {
            // Initialize tasks from TTC
            Tasks = new ObservableCollection<TTC>();
            UpdateTotalTasks();
        }

        public void AddTask(TTC task)
        {
            Tasks.Add(task);
            UpdateTotalTasks();
        }

        public void RemoveTask(TTC task)
        {
            Tasks.Remove(task);
            UpdateTotalTasks();
        }

        public void UpdateTotalTasks()
        {
            TOT = Tasks.Count;
        }
    }
}
