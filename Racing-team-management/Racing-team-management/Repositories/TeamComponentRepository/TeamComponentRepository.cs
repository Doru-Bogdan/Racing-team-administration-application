using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Racing_team_management.Contexts;

namespace Racing_team_management.Repositories.TeamComponentsRepository
{
    public class TeamComponentRepository : ITeamComponentRepository
    {
        public Context _context { get; set; }
        public TeamComponentRepository(Context context)
        {
            _context = context;
        }

        public TeamComponent Create(TeamComponent teamComponent)
        {
            var result = _context.Add<TeamComponent>(teamComponent);
            _context.SaveChanges();
            return result.Entity;
        }

        public TeamComponent Get(int Id)
        {
            return _context.TeamComponents.SingleOrDefault(x => x.Id == Id);

        }

        public List<TeamComponent> GetAll()
        {
            return _context.TeamComponents.ToList();
        }

        public TeamComponent Update(TeamComponent teamComponent)
        {
            _context.Entry(teamComponent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return teamComponent;
        }

        public TeamComponent Delete(TeamComponent teamComponent)
        {
            var result = _context.Remove(teamComponent);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
