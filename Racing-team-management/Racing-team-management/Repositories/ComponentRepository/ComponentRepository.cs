using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Racing_team_management.Contexts;

namespace Racing_team_management.Repositories.ComponentsRepository
{
    public class ComponentRepository : IComponentRepository
    {
        public Context _context { get; set; }
        public ComponentRepository(Context context)
        {
            _context = context;
        }

        public Component Create(Component component)
        {
            var result = _context.Add<Component>(component);
            _context.SaveChanges();
            return result.Entity;
        }

        public Component Get(int Id)
        {
            return _context.Components.SingleOrDefault(x => x.Id == Id);

        }

        public List<Component> GetAll()
        {
            return _context.Components.ToList();
        }

        public Component Update(Component component)
        {
            _context.Entry(component).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return component;
        }

        public Component Delete(Component component)
        {
            var result = _context.Remove(component);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
