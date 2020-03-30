using System;
using System.Collections.Generic;

namespace Racing_team_management.DTOs
{
    public class ManufacturerDetailsDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> Components { get; set; }
    }
}
