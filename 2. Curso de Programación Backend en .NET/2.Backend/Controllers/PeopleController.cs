using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
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
