using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLTaskManager.Models
{
    public class User
    {
        public string _id { get; set; } = "";
        public string email { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string fullName {
            get {
                return firstName + " " + lastName;
                }
        }
        public string avatarUrl { get; set; } = "";
    }
}
