using Microsoft.AspNetCore.Mvc;

namespace musicstore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        public string Get() => "Hello API";
    }
}