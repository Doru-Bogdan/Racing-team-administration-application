using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Racing_team_management.Contexts;

namespace Racing_team_management.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Context _context { get; set; }
        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public Employee Create(Employee employee)
        {
            var result = _context.Add<Employee>(employee);
            _context.SaveChanges();
            return result.Entity;
        }

        public Employee Get(int Id)
        {
            return _context.Employees.SingleOrDefault(x => x.Id == Id);

        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee Update(Employee employee)
        {
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            var result = _context.Remove(employee);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
