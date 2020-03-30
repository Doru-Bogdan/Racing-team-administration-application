using System;
namespace Racing_team_management.DTOs
{
    public class ComponentDTO
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
