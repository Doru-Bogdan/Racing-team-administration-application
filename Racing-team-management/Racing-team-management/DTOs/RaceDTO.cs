using System;
using System.Collections.Generic;
namespace Racing_team_management.DTOs
{
    public class RaceDTO
    {
        public int Duration { get; set; }
        public string Location { get; set; }
        public int NumberOfSpectators { get; set; }

        public List<int>IdTeams { get; set; }
    }
}
