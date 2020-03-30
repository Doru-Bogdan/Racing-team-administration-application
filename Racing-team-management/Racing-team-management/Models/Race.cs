using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class Race
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public int NumberOfSpectators { get; set; }

        public List<TeamComponent> TeamComponents { get; set; }
    }
}
