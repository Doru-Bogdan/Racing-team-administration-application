using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public int Age { get; set; }
        public string Function { get; set; }


        public virtual Team Team { get; set; }
    }
}
