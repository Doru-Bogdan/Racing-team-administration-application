using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.RaceRepository
{
    public interface IRaceRepository
    {
        List<Race> GetAll();
        Race Get(int Id);
        Race Create(Race Race);
        Race Update(Race Race);
        Race Delete(Race Race);

    }
}
