using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing_team_management.Models
{
    public class Component
{
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public List<TeamComponent> TeamComponent { get; set; }


    }
}
