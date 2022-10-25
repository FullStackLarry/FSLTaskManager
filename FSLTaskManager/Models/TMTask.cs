using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLTaskManager.Models
{
    public class TMTask
    {
        public string _id { get; set; } = "";
        public string owner { get; set; } = "";
        public string ownerName { get; set; } = "";
        public string assignedTo { get; set; } = "";
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public string status { get; set; } = "";
        public string assignedDate { get; set; } = "";
        public string startedDate { get; set; } = "";
        public string completedDate { get; set; } = "";
    }
}
