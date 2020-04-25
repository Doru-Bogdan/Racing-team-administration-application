using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.TeamRepository;
using Racing_team_management.Repositories.TeamRaceRepository;
using Racing_team_management.Repositories.EmployeeRepository;
using Racing_team_management.Repositories.RaceRepository;
using Racing_team_management.Repositories.TeamComponentsRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeamController : ControllerBase
    {
        ITeamRepository ITeamRepository;
        ITeamRaceRepository ITeamRaceRepository;
        IRaceRepository IRaceRepository;
        IEmployeeRepository IEmployeeRepository;
        ITeamComponentRepository ITeamComponentRepository;

        public TeamController(ITeamRepository TeamRepository, ITeamRaceRepository TeamRaceRepository, IRaceRepository RaceRepository,
            IEmployeeRepository EmployeeRepository, ITeamComponentRepository TeamComponentRepository)
        {
            ITeamRepository = TeamRepository;
            ITeamRaceRepository = TeamRaceRepository;
            IRaceRepository = RaceRepository;
            IEmployeeRepository = EmployeeRepository;
            ITeamComponentRepository = TeamComponentRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            return ITeamRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TeamDetailsDTO Get(int id)
        {
            Team Team = ITeamRepository.Get(id);
            TeamDetailsDTO TeamDTO = new TeamDetailsDTO()
            {
                Team_name = Team.Team_name,
                RealeaseYear = Team.RealeaseYear,
                Image = Team.Image
            };

            IEnumerable<Employee> employees = IEmployeeRepository.GetAll().Where(x => x.TeamId == id);
            if (employees != null)
            {
                List<string> employeeNames = employees.Select(x => x.First_name + " " + x.Second_name).ToList();
                TeamDTO.Employees = employeeNames;
            }

            IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.TeamId == id);
            if (teamRaces != null)
            {
                List<string> races = new List<string>();
                foreach (TeamRace teamRace in teamRaces)
                {
                    Race race = IRaceRepository.GetAll().SingleOrDefault(x => x.Id == teamRace.RaceId);
                    races.Add(race.Location);
                }
                TeamDTO.Races = races;
            }

            return TeamDTO;
        }

        // POST api/values
        [HttpPost]
        public void Post(TeamDTO value)
        {
            Team model = new Team()
            {
                Team_name = value.Team_name,
                RealeaseYear = value.RealeaseYear,
                Image = value.Image
            };
            ITeamRepository.Create(model);


            if(value.Employees != null)
            {
                foreach (EmployeeDTO employee in value.Employees)
                {
                    Employee newEmployee = new Employee()
                    {
                        TeamId = model.Id,
                        First_name = employee.First_name,
                        Second_name = employee.Second_name,
                        Function = employee.Function,
                        Age = employee.Age
                    };
                    IEmployeeRepository.Create(newEmployee);
                }
            }
           

            if(value.ComponentsId != null)
            {
                for (int i = 0; i < value.ComponentsId.Count; i++)
                {
                    TeamComponent newTeamComponent = new TeamComponent()
                    {
                        ComponentId = value.ComponentsId[i],
                        TeamId = model.Id
                    };
                    ITeamComponentRepository.Create(newTeamComponent);
                }
            }
            
            if(value.RacesId != null)
            {
                for (int i = 0; i < value.RacesId.Count; i++)
                {
                    TeamRace newTeamRace = new TeamRace()
                    {
                        TeamId = model.Id,
                        RaceId = value.RacesId[i]
                    };
                    ITeamRaceRepository.Create(newTeamRace);
                }
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Team Put(int id, TeamDTO value)
        {
            Team model = ITeamRepository.Get(id);

            if (value.RealeaseYear != 0)
            {
                model.RealeaseYear = value.RealeaseYear;
            }
            if (value.Team_name != null)
            {
                model.Team_name = value.Team_name;
            }
            if (value.Image != null)
            {
                model.Image = value.Image;
            }

            if (value.ComponentsId != null)
            {
                IEnumerable<TeamComponent> teamComponents = ITeamComponentRepository.GetAll().Where(x => x.TeamId == id);
                foreach (TeamComponent teamComponent in teamComponents)
                    ITeamComponentRepository.Delete(teamComponent);

                for (int i = 0; i < value.ComponentsId.Count; i++)
                {
                    TeamComponent newTeamComponent = new TeamComponent()
                    {
                        ComponentId = value.ComponentsId[i],
                        TeamId = model.Id
                    };
                    ITeamComponentRepository.Create(newTeamComponent);
                }
            }

            if (value.Employees != null)
            {
                IEnumerable<Employee> employees = IEmployeeRepository.GetAll().Where(x => x.TeamId == id);
                foreach (Employee employee in employees)
                    IEmployeeRepository.Delete(employee);

                foreach (EmployeeDTO employee in value.Employees)
                {
                    Employee newEmployee = new Employee()
                    {
                        TeamId = model.Id,
                        First_name = employee.First_name,
                        Second_name = employee.Second_name,
                        Function = employee.Function,
                        Age = employee.Age
                    };
                    IEmployeeRepository.Create(newEmployee);
                }
            }

            if (value.RacesId != null)
            {
                IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.TeamId == id);
                foreach (TeamRace teamRace in teamRaces)
                    ITeamRaceRepository.Delete(teamRace);

                for (int i = 0; i < value.RacesId.Count; i++)
                {
                    TeamRace newTeamRace = new TeamRace()
                    {
                        TeamId = model.Id,
                        RaceId = value.RacesId[i]
                    };
                    ITeamRaceRepository.Create(newTeamRace);
                }
            }

            return ITeamRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Team Delete(int id)
        {
            Team model = ITeamRepository.Get(id);

            IEnumerable<Employee> employees = IEmployeeRepository.GetAll().Where(x => x.TeamId == id);
            foreach (Employee employee in employees)
                IEmployeeRepository.Delete(employee);

            IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.TeamId == id);
            foreach (TeamRace teamRace in teamRaces)
                ITeamRaceRepository.Delete(teamRace);

            IEnumerable<TeamComponent> teamComponents = ITeamComponentRepository.GetAll().Where(x => x.TeamId == id);
            foreach (TeamComponent teamComponent in teamComponents)
                ITeamComponentRepository.Delete(teamComponent);

            return ITeamRepository.Delete(model);
        }
    }
}
