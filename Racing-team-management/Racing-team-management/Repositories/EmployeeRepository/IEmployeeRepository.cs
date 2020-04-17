using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;


namespace Racing_team_management.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee Get(int Id);
        Employee Create(Employee Employee);
        Employee Update(Employee Employee);
        Employee Delete(Employee Employee);
    }
}
