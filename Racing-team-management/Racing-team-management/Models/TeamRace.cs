using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class TeamRace
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int RaceId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Race Race { get; set; }
    }
}
