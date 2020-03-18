using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.TeamRepository
{
    public interface ITeamRepository
    {
        List<Team> GetAll();
        Team Get(int Id);
        Team Create(Team Team);
        Team Update(Team Team);
        Team Delete(Team Team);
    }
}
