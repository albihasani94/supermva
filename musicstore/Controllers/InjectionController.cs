using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace musicstore.Controllers
{
    public class InjectionController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}