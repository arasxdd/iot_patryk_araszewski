using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2_araszewski.Rest.Context;
using lab2_araszewski.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab2_araszewski.Rest.Controllers
{
    [ApiController]
    [Route("/api/people")]
    public class PeopleController : Controller
    {
        private AzureDbContext azureDbContext;

        private readonly ILogger<PeopleController> _logger;
        public PeopleController(ILogger<PeopleController> logger, AzureDbContext azureDbContext)
        {
            _logger = logger;
            this.azureDbContext = azureDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var person = azureDbContext.People;
            return Ok(person);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var person = azureDbContext.People.First(w => w.PersonId == id);
                return Ok(person);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person newPerson)
        {
            try
            {
                azureDbContext.People.Add(newPerson);
                azureDbContext.SaveChanges();
                return Ok(newPerson);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            try
            {
                azureDbContext.People.Update(person);
                azureDbContext.SaveChanges();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var toRemove = azureDbContext.People.First(w => w.PersonId == id);
                azureDbContext.People.Remove(toRemove);
                azureDbContext.SaveChanges();
                return Ok(toRemove);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
