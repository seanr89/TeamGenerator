
using System;
using System.Collections.Generic;
using System.Linq;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Models.Utility;
using APIGenerator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Controllers
{
    [Route("api/[controller]")]
    /// <summary>
    /// Controller to handle the public activities to handle Day events
    /// </summary>
    public class DayController : Controller
    {
        /// <summary>
        /// private Logger object
        /// </summary>
        private readonly ILogger _Logger;
        private readonly JSONFileReader _DataFileReader;

        /// <summary>
        /// Constructor
        /// </summary>
        public DayController(ILogger<DayController> Logger,
            JSONFileReader dataFileReader)
        {
            _Logger = Logger;
            _DataFileReader = dataFileReader;
        }

        /// <summary>
        /// GET operation to request all Day Events stored
        /// </summary>
        /// <returns>An IAction result of all Days available</returns>
        [HttpGet]
        public IActionResult Get()
        {
            string DayFileContents = _DataFileReader.ReadFileContentsForContentType(FileType.DAY);

            if(string.IsNullOrWhiteSpace(DayFileContents))
            {
                return NotFound();
            }

            IEnumerable<Day> Days = null;

            try
            {
                Days = UtilityMethods.ConvertJsonStringToProvidedGenericType<IEnumerable<Day>>(DayFileContents);
                if(Days == null || Days.Count() <= 0)
                {
                    return NotFound();
                }
                else
                {
                    //Ok we can return the standard days for now
                    return Ok(Days);

                    //But what we want to do is actually go and parse the teams as well
                    string TeamsFileContents = _DataFileReader.ReadFileContentsForContentType(FileType.TEAM);

                    //Then we want to parse the players on each team
                    string PlayersFileContents = _DataFileReader.ReadFileContentsForContentType(FileType.PLAYER);
                }
            }
            catch(Exception e)
            {
                //TODO - Log the error and change from default Exceptioj
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest();
            }

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