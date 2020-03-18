using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Racing_team_management.Contexts;



namespace Racing_team_management.Repositories.ManufacturerRepository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public Context _context { get; set; }
        public ManufacturerRepository(Context context)
        {
            _context = context;
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            var result = _context.Add<Manufacturer>(manufacturer);
            _context.SaveChanges();
            return result.Entity;
        }

        public Manufacturer Get(int Id)
        {
            return _context.Manufacturers.SingleOrDefault(x => x.Id == Id);

        }

        public List<Manufacturer> GetAll()
        {
            return _context.Manufacturers.ToList();
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return manufacturer;
        }

        public Manufacturer Delete(Manufacturer manufacturer)
        {
            var result = _context.Remove(manufacturer);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
