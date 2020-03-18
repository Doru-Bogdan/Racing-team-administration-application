using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.TeamRaceRepository
{
    public interface ITeamRaceRepository
    {
        List<TeamRace> GetAll();
        TeamRace Get(int Id);
        TeamRace Create(TeamRace TeamRace);
        TeamRace Update(TeamRace TeamRace);
        TeamRace Delete(TeamRace TeamRace);
    }
}
