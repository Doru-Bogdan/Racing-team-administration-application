using System;
using System.Collections.Generic;

namespace Racing_team_management.DTOs
{
    public class TeamDetailsDTO
    {
        public string Team_name { get; set; }
        public int RealeaseYear { get; set; }

        public List<string> Employees { get; set; }
        public List<string> Races { get; set; }
    }
}
