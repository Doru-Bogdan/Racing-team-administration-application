using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.ManufacturerRepository
{
    public interface IManufacturerRepository
    {
        List<Manufacturer> GetAll();
        Manufacturer Get(int Id);
        Manufacturer Create(Manufacturer Manufacturer);
        Manufacturer Update(Manufacturer Manufacturer);
        Manufacturer Delete(Manufacturer Manufacturer);
    }
}
