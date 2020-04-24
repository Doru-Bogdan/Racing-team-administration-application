using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.TeamRaceRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeamRaceController : ControllerBase
    {
        public ITeamRaceRepository ITeamRaceRepository;

        public TeamRaceController(ITeamRaceRepository repository)
        {
            ITeamRaceRepository = repository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<TeamRace>> Get()
        {
            return ITeamRaceRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TeamRace> Get(int id)
        {
            return ITeamRaceRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public TeamRace Post(TeamRaceDTO value)
        {
            TeamRace model = new TeamRace()
            {
                RaceId = value.Id_race,
                TeamId = value.Id_team
            };

            return ITeamRaceRepository.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public TeamRace Put(int id, TeamRaceDTO value)
        {
            TeamRace model = ITeamRaceRepository.Get(id);

            if (value.Id_race != 0)
            {
                model.RaceId = value.Id_race;
            }
            if (value.Id_team != 0)
            {
                model.TeamId = value.Id_team;
            }

            return ITeamRaceRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public TeamRace Delete(int id)
        {
            TeamRace model = ITeamRaceRepository.Get(id);
            return ITeamRaceRepository.Delete(model);
        }
    }
}
