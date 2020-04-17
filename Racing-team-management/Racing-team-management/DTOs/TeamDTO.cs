using System;
using System.Collections.Generic;

namespace Racing_team_management.DTOs
{
    public class TeamDTO
    {
        public string Team_name { get; set; }
        public int RealeaseYear { get; set; }

        public List<int> RacesId { get; set; }
        public List<int> ComponentsId { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
