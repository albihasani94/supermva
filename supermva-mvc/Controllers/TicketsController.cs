using Microsoft.AspNetCore.Mvc;

namespace supermva_mvc.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet("/ticket")]
        public IActionResult Index() {
            return View();
        }

        public string Index2()
        {
            return "Hello from tickets!";
        }
    }
}