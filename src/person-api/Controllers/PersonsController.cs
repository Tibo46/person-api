using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using person_api.Database;
using person_api.Models;

namespace person_api.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private readonly PeopleContext _db;

        public PersonsController(PeopleContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get([FromRoute] string id)
        {
            var result = await _db.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Person>>> Search([FromQuery] string searchTerms)
        {
            var result = await _db.Persons.Where(x => searchTerms != null ? x.Group.Name.Contains(searchTerms) || x.Name.Contains(searchTerms) : true)
                .Include(x => x.Group)
                .OrderBy(x => x.CreationDate)
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Post([FromBody] Person person)
        {
            try
            {
                var result = await _db.Persons.AddAsync(person);

                await _db.SaveChangesAsync();

                return new OkObjectResult(result.Entity);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}