using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prime_check_web_version_.Models;

namespace Prime_check_web_version_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> IsPrime(long number)
        {
            if (number <= 0)
            {
                Console.WriteLine("{0} is not Prime", number);
                await Response.WriteAsync(String.Format("{0} is not Prime", number));
                return RedirectToAction("Privacy");

            }
            if (number == 1)
            {
                Console.WriteLine("{0} is not Prime", number);
                await Response.WriteAsync(String.Format("{0} is not Prime", number));
                return RedirectToAction("Privacy");

            }
            if (number == 2)
            {
                Console.WriteLine("{0} is Prime", number);
                await Response.WriteAsync(String.Format("{0} is Prime", number));
                return RedirectToAction("Privacy");

            }
            for (long i = 2; i <= Math.Floor(Math.Sqrt(number)); i += 2)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("{0} is not Prime", number);
                    await Response.WriteAsync(String.Format("{0} is not Prime", number));
                    return RedirectToAction("Privacy");

                }
                if (i == 2)
                    i--;
            }
            Console.WriteLine("{0} is Prime", number);
            await Response.WriteAsync(String.Format("{0} is Prime", number));
            return RedirectToAction("Privacy");

        }

        public IActionResult Privacy()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Privacy(Number number)
        {
            if (ModelState.IsValid)
            {
                var checkPrime = await IsPrime(number.n);

                //if (IsPrime(number.n))
                //    return Content("Prime");
                //else
                //    return Content("Not Prime");
                return RedirectToAction("Privacy");


            }
            else
                return View(number);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
