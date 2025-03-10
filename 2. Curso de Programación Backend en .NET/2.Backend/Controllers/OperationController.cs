using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength,
            [FromHeader(Name = "X-some")] string XSome)
        {
            Console.WriteLine("Host: " + Host);
            Console.WriteLine("ContentLength: " + ContentLength);
            Console.WriteLine("XSome: " + XSome);
            return numbers.A - numbers.B;
        }
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a * b;
        }

        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
