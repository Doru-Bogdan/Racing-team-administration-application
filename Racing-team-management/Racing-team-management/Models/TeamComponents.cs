using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class TeamComponents
{
        public int Id { get; set; }
        public int Id_team { get; set; }
        public int Id_component { get; set; }

        public virtual Team Team { get; set; }
        public virtual Components Components { get; set; }

    }
}
