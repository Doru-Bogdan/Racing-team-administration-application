using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Contexts;
using Racing_team_management.Models;

namespace Racing_team_management.Repositories.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        public Context _context { get; set; }
        public TeamRepository(Context context)
        {
            _context = context;
        }

        public Team Create(Team team)
        {
            var result = _context.Add<Team>(team);
            _context.SaveChanges();
            return result.Entity;
        }

        public Team Get(int Id)
        {
            return _context.Teams.SingleOrDefault(x => x.Id == Id);

        }

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        public Team Update(Team team)
        {
            _context.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return team;
        }

        public Team Delete(Team team)
        {
            var result = _context.Remove(team);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
