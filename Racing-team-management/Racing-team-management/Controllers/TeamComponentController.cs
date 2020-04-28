using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.TeamComponentsRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeamComponentController : ControllerBase
    {
        public ITeamComponentRepository ITeamComponentRepository;

        public TeamComponentController(ITeamComponentRepository repository)
        {
            ITeamComponentRepository = repository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<TeamComponent>>Get()
        {
            return ITeamComponentRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TeamComponent> Get(int id)
        {
            return ITeamComponentRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public TeamComponent Post(TeamComponentDTO value)
        {
            TeamComponent model = new TeamComponent()
            {
                TeamId = value.Id_team,
                ComponentId = value.Id_component
            };

            return ITeamComponentRepository.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public TeamComponent Put(int id, TeamComponentDTO value)
        {
            TeamComponent model = ITeamComponentRepository.Get(id);

            if (value.Id_team > 0)
            {
                model.TeamId = value.Id_team;
            }
            if (value.Id_component > 0)
            {
                model.ComponentId = value.Id_component;
            }

            return ITeamComponentRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public TeamComponent Delete(int id)
        {
            TeamComponent model = ITeamComponentRepository.Get(id);
            return ITeamComponentRepository.Delete(model);
        }
    }
}
