using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Team_name { get; set; }
        public int RealeaseYear { get; set; }
        public string img { get; set; }

        public List<TeamRace> TeamRaces { get; set; }
        public List<Employee> Employees { get; set; }
        public List<TeamComponent> TeamComponents { get; set; }
    }
}
