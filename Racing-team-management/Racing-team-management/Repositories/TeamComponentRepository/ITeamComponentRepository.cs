using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.TeamComponentsRepository
{
    public interface ITeamComponentRepository
    {
        List<TeamComponent> GetAll();
        TeamComponent Get(int Id);
        TeamComponent Create(TeamComponent TeamComponent);
        TeamComponent Update(TeamComponent TeamComponent);
        TeamComponent Delete(TeamComponent TeamComponent);
    }
}
