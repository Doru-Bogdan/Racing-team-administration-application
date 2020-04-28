using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.ComponentsRepository;
using Racing_team_management.Repositories.TeamComponentsRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComponentController : ControllerBase
    {
        public IComponentRepository IComponentRepository { get; set; }
        public ITeamComponentRepository ITeamComponentRepository { get; set; }

        public ComponentController(IComponentRepository ComponentRepository, ITeamComponentRepository TeamComponentRepository)
        {
            IComponentRepository = ComponentRepository;
            ITeamComponentRepository = TeamComponentRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Component>> Get()
        {
            return IComponentRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Component> Get(int id)
        {
            return IComponentRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Component Post(ComponentDTO value)
        {
            Component model = new Component()
            {
                ManufacturerId = value.ManufacturerId,
                Name = value.Name,
                Price = value.Price,
                Quantity = value.Quantity,
                Status = value.Status,
                Image = value.Image
            };

            return IComponentRepository.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Component Put(int id, ComponentDTO value)
        {
            Component model = IComponentRepository.Get(id);

            if (value.ManufacturerId != 0)
            {
                model.ManufacturerId = value.ManufacturerId;
            }
            if (value.Quantity != 0)
            {
                model.Quantity = value.Quantity;
            }
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (Math.Abs(value.Price - 0.0000) > 0.01)
            {
                model.Price = value.Price;
            }
            if (value.Quantity > -1)
            {
                model.Quantity = value.Quantity;
            }
            if (value.Status != null)
            {
                model.Status = value.Status;
            }
            if (value.Image != null)
            {
                model.Image = value.Image;
            }

            return IComponentRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Component Delete(int id)
        {
            IEnumerable<TeamComponent> MyTeamComponents = ITeamComponentRepository.GetAll().Where(x => x.Id == id);
            foreach (TeamComponent MyTeamComponent in MyTeamComponents)
            {
                ITeamComponentRepository.Delete(MyTeamComponent);
            }

            Component component = IComponentRepository.Get(id);
            return IComponentRepository.Delete(component);
        }
    }
}
