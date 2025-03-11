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
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Task<int> task1 = new(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Conexión a bd terminada");
                return 1;
            });

            Task<int> task2 = new(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Envío de mail terminado");
                return 2;
            });

            task1.Start();
            task2.Start();
            Console.WriteLine("hago otra cosa");

            var result = await task1;
            var result2 = await task2;
            Console.WriteLine("todo ha terminado");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }
    }
}
