using System;
using System.Collections.Generic;

namespace Racing_team_management.DTOs
{
    public class RaceDetailsDTO
    {
        public int Duration { get; set; }
        public string Location { get; set; }
        public int NumberOfSpectators { get; set; }
        public List<string> ParticipantTeams { get; set; }
    }
}
