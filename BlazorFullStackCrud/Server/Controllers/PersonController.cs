using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        // HTTP ATTRIBUTES
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            var people = await _context.People.ToListAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetSinglePerson(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound("Sorry, person not found.");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPeople());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person, int id)
        {
            var dbPerson = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPerson == null)
                return NotFound("Person not found.");

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.EmailAddress = person.EmailAddress;

            await _context.SaveChangesAsync();
            return Ok(await GetDbPeople());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(Person person, int id)
        {
            var dbPerson = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
            if (dbPerson == null)
                return NotFound("Person not found.");

            _context.People.Remove(dbPerson);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPeople());
        }



        private async Task<List<Person>> GetDbPeople()
        {
            return await _context.People.ToListAsync();
        }
    }
}
