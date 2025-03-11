using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(2000);
            Console.WriteLine("Conexión a bd terminada");

            Thread.Sleep(2000);
            Console.WriteLine("Envío de mail terminado");

            Console.WriteLine("todo ha terminado");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Task<int> task1 = new(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Conexión a bd terminada");
                return 8;
            });

            task1.Start();
            Console.WriteLine("hago otra cosa");

            var result = await task1;
            Console.WriteLine("todo ha terminado");

            return Ok(result);
        }
    }
}
