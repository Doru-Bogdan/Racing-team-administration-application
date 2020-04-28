using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.RaceRepository;
using Racing_team_management.Repositories.TeamRaceRepository;
using Racing_team_management.Repositories.TeamRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RaceController : ControllerBase
    {
        public IRaceRepository IRaceRepository;
        public ITeamRaceRepository ITeamRaceRepository;
        public ITeamRepository ITeamRepository;

        public RaceController(IRaceRepository RaceRepository, ITeamRaceRepository TeamRaceRepository, ITeamRepository TeamRepository)
        {
            IRaceRepository = RaceRepository;
            ITeamRaceRepository = TeamRaceRepository;
            ITeamRepository = TeamRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Race>> Get()
        {
            return IRaceRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RaceDetailsDTO Get(int id)
        {
            Race race = IRaceRepository.Get(id);
            RaceDetailsDTO raceDetails = new RaceDetailsDTO()
            {
                Duration = race.Duration,
                Location = race.Location,
                NumberOfSpectators = race.NumberOfSpectators,
                Image = race.Image
            };

            IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.RaceId == id);
            if (teamRaces != null)
            {
                List<String> teamNames = new List<string>();
                foreach (TeamRace teamRace in teamRaces)
                {
                    Team team = ITeamRepository.GetAll().SingleOrDefault(x => x.Id == teamRace.TeamId);
                    teamNames.Add(team.Team_name);
                }

                raceDetails.ParticipantTeams = teamNames;
            }

            return raceDetails;
        }

        // POST api/values
        [HttpPost]
        public void Post(RaceDTO value)
        {
            Race model = new Race()
            {
                Location = value.Location,
                Duration = value.Duration,
                NumberOfSpectators = value.NumberOfSpectators,
                Image = value.Image
            };

            IRaceRepository.Create(model);

            for (int i = 0; i < value.IdTeams.Count; i++)
            {
                TeamRace teamRace = new TeamRace()
                {
                    TeamId = value.IdTeams[i],
                    RaceId = model.Id
                };
                ITeamRaceRepository.Create(teamRace);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Race Put(int id, RaceDTO value)
        {
            Race model = IRaceRepository.Get(id);

            if (value.Duration > 0)
            {
                model.Duration = value.Duration;
            }
            if (value.Location != null)
            {
                model.Location = value.Location;
            }
            if (value.NumberOfSpectators > 0)
            {
                model.NumberOfSpectators = value.NumberOfSpectators;
            }
            if (value.Image != null)
            {
                model.Image = value.Image;
            }

            if (value.IdTeams != null)
            {
                IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.RaceId == id);
                foreach (TeamRace teamRace in teamRaces)
                {
                    ITeamRaceRepository.Delete(teamRace);
                }

                for (int i = 0; i < value.IdTeams.Count; i++)
                {
                    TeamRace teamRace = new TeamRace()
                    {
                        TeamId = value.IdTeams[i],
                        RaceId = model.Id
                    };
                    ITeamRaceRepository.Create(teamRace);
                }
            }

            return IRaceRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Race Delete(int id)
        {
            Race model = IRaceRepository.Get(id);

            IEnumerable<TeamRace> teamRaces = ITeamRaceRepository.GetAll().Where(x => x.RaceId == id);
            foreach (TeamRace teamRace in teamRaces)
            {
                ITeamRaceRepository.Delete(teamRace);
            }

            return IRaceRepository.Delete(model);
        }
    }
}
