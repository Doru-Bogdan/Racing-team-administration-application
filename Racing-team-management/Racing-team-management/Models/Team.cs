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

        public List<TeamRace> TeamRace { get; set; }
        public List<Employee> Employee { get; set; }
        public List<TeamComponent> TeamComponent { get; set; }

    }
}
