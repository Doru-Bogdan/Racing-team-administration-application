using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Racing_team_management.Contexts;

namespace Racing_team_management.Repositories.TeamRaceRepository
{
    public class TeamRaceRepository : ITeamRaceRepository
    {
        public Context _context { get; set; }
        public TeamRaceRepository(Context context)
        {
            _context = context;
        }

        public TeamRace Create(TeamRace teamRace)
        {
            var result = _context.Add<TeamRace>(teamRace);
            _context.SaveChanges();
            return result.Entity;
        }

        public TeamRace Get(int Id)
        {
            return _context.TeamRaces.SingleOrDefault(x => x.Id == Id);

        }

        public List<TeamRace> GetAll()
        {
            return _context.TeamRaces.ToList();
        }

        public TeamRace Update(TeamRace teamRace)
        {
            _context.Entry(teamRace).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return teamRace;
        }

        public TeamRace Delete(TeamRace teamRace)
        {
            var result = _context.Remove(teamRace);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
