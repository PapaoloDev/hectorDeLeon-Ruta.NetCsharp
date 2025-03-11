using _2.Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService();
        }

        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
        }

        [HttpGet("{id}")]
        public ActionResult<People> GetPerson(int id)
        {
            var person = Repository.People.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpGet("name/{name}")]
        public ActionResult<List<People>> GetName(string name)
        {
            var persons = Repository.People.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            if (persons.Count == 0)
                return NotFound();

            return Ok(persons);
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if(!_peopleService.Validate(people))
                return BadRequest("Nombre es Requerido.");

            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class Repository
    { 
        public static List<People> People = new List<People>
        {
            new People { Id = 1, Name = "Paolo", Birthdate = new DateTime(1987, 5, 12) },
            new People { Id = 2, Name = "Macarena", Birthdate = new DateTime(1995, 5, 10) },
            new People { Id = 3, Name = "Pascuala", Birthdate = new DateTime(2022, 5, 19) },
            new People { Id = 4, Name = "Leandro", Birthdate = new DateTime(1993, 10, 8) },
            new People { Id = 5, Name = "James", Birthdate = new DateTime(1994, 5, 5) },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
