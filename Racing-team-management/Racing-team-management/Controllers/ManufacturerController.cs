using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Racing_team_management.DTOs;
using Racing_team_management.Models;
using Racing_team_management.Repositories.ManufacturerRepository;
using Racing_team_management.Repositories.ComponentsRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Racing_team_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {

        public IManufacturerRepository IManufacturerRepo { set; get; }
        public IComponentRepository IComponentRepo { set; get; }

        public ManufacturerController(IManufacturerRepository manufacturerRepo, IComponentRepository componentRepo)
        {
            IManufacturerRepo = manufacturerRepo;
            IComponentRepo = componentRepo;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            return IManufacturerRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ManufacturerDetailsDTO Get(int id)
        {
            Manufacturer manufacturer = IManufacturerRepo.Get(id);
            ManufacturerDetailsDTO manufacturerDetails = new ManufacturerDetailsDTO()
            {
                Name = manufacturer.Name,
                Location = manufacturer.Location
            };

            IEnumerable<Component> components = IComponentRepo.GetAll().Where(x => x.ManufacturerId == manufacturer.Id);
            if (components != null)
            {
                List<string> componentsName = new List<string>();
                foreach (Component component in components)
                {
                    componentsName.Add(component.Name);
                }
                manufacturerDetails.Components = componentsName;
            }

            return manufacturerDetails;
        }

        // POST api/values
        [HttpPost]
        public Manufacturer Post(ManufacturerDTO value)
        {
            Manufacturer manufacturer = new Manufacturer()
            {
                Name = value.Name,
                Location = value.Location
            };

            return IManufacturerRepo.Create(manufacturer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, ManufacturerDTO value)
        {
            Manufacturer manufacturer = IManufacturerRepo.Get(id);
            if (value.Name != null)
            {
                manufacturer.Name = value.Name;
            }
            if (value.Location != null)
            {
                manufacturer.Location = value.Location;
            }

            IManufacturerRepo.Update(manufacturer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Manufacturer Delete(int id)
        {
            Manufacturer manufacturer = IManufacturerRepo.Get(id);
            foreach (Component component in IComponentRepo.GetAll())
            {
                if (component.ManufacturerId == id)
                    IComponentRepo.Delete(component);
            }
            return IManufacturerRepo.Delete(manufacturer);
        }
    }
}
