using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskerApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TTC
        // gets and sets data
    {
        //TCOL = Task Color  
        public string TCOL { get; set; }

        //TNAME = Task Name
        public string TNAME { get; set; }

        // task if its complete
        public bool Completed { get; set; }

        //tasks ID
        public int CategoryId { get; set; }
    }
}
