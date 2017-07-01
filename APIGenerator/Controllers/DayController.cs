
using System;
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

        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public IActionResult DaysInRange([FromBody]DateTime StartDate, [FromBody]DateTime EndDate)
        {
            return BadRequest();
        }
    }
}