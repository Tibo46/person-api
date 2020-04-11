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
    public class GroupsController : Controller
    {
        private readonly PeopleContext _db;

        public GroupsController(PeopleContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            var results = await _db.Groups.ToListAsync();

            return Ok(results);
        }
    }
}