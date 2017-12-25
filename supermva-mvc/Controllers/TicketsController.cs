using Microsoft.AspNetCore.Mvc;

namespace supermva_mvc.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet("/ticket")]
        public string Index() => "Hello from tickets!";
    }
}