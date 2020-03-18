using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Contexts;
using Racing_team_management.Models;


namespace Racing_team_management.Repositories.RaceRepository
{
    public class RaceRepository : IRaceRepository
    {
        public Context _context { get; set; }
        public RaceRepository(Context context)
        {
            _context = context;
        }

        public Race Create(Race race)
        {
            var result = _context.Add<Race>(race);
            _context.SaveChanges();
            return result.Entity;
        }

        public Race Get(int Id)
        {
            return _context.Races.SingleOrDefault(x => x.Id == Id);

        }

        public List<Race> GetAll()
        {
            return _context.Races.ToList();
        }

        public Race Update(Race race)
        {
            _context.Entry(race).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return race;
        }

        public Race Delete(Race race)
        {
            var result = _context.Remove(race);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
