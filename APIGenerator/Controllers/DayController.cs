
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Controllers
{
    /// <summary>
    /// Controller to handle the public activities to handle Day events
    /// </summary>
    public class DayController : Controller
    {
        /// <summary>
        /// private Logger object
        /// </summary>
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public DayController(ILogger<DayController> Logger)
        {
            _Logger = Logger;
        }

        
    }
}