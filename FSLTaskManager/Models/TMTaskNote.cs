using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLTaskManager.Models
{
    public class TMTaskNote
    {
        public string _id { get; set; } = "";
        public string task { get; set; } = "";
        public User owner { get; set; } = new User();
        public string note { get; set; } = "";
        public string enteredDate { get; set; } = "";
    }
}
