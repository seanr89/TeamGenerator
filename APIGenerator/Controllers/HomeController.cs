
using Microsoft.AspNetCore.Mvc;

namespace APIGenerator.Controllers
{
    /// <summary>
    /// Use as the default controller to allow access to the swagger files
    /// </summary>
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}