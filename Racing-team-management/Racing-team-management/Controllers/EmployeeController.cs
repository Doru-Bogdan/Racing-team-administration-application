using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.EmployeeRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository IEmployeeRepository;

        public EmployeeController(IEmployeeRepository repository)
        {
            IEmployeeRepository = repository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return IEmployeeRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            Employee employee = IEmployeeRepository.Get(id);
            EmployeeDTO dto = new EmployeeDTO()
            {
                IdTeam = employee.TeamId,
                First_name = employee.First_name,
                Second_name = employee.Second_name,
                Age = employee.Age,
                Function = employee.Function,

            };

            return dto;
        }

        // POST api/values
        [HttpPost]
        public Employee Post(EmployeeDTO value)
        {
            Employee model = new Employee()
            {
                TeamId = value.IdTeam,
                First_name = value.First_name,
                Second_name = value.Second_name,
                Age = value.Age,
                Function = value.Function
            };

            return IEmployeeRepository.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Employee Put(int id, EmployeeDTO value)
        {
            Employee model = IEmployeeRepository.Get(id);

            if (value.Age > 0)
            {
                model.Age = value.Age;
            }
            if (value.First_name != null)
            {
                model.First_name = value.First_name;
            }
            if (value.Second_name != null)
            {
                model.Second_name = value.Second_name;
            }
            if (value.Function != null)
            {
                model.Function = value.Function;
            }
            if (value.IdTeam > 0)
            {
                model.TeamId = value.IdTeam;
            }

            return IEmployeeRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Employee Delete(int id)
        {
            Employee model = IEmployeeRepository.Get(id);
            return IEmployeeRepository.Delete(model);
        }
    }
}
