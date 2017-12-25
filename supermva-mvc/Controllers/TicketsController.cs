using Microsoft.AspNetCore.Mvc;
using supermva_mvc.Models;

namespace supermva_mvc.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet("/ticket")]
        public IActionResult Index() {
            //go to the database
            //get some model
            var s = new Seat() { Location = "Orchestra", Price = 300.00 };

            return View(s);
        }

        public string Index2() => "Hello from tickets!";
    }
}