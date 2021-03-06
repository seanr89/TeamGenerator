
using System;
using System.Collections.Generic;
using System.Linq;
using APIGenerator.Business;
using APIGenerator.Business.Interfaces;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Models.Utility;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        private readonly IDayRepository _DayRepository;
        private readonly ITeamGenerator _TeamGenerator;

        /// <summary>
        /// Constructor with DI injection
        /// </summary>
        public DayController(ILogger<DayController> Logger,
            IDayRepository DayRepository,
            ITeamGenerator TeamGenerator)
        {
            _Logger = Logger;
            _DayRepository = DayRepository;
            _TeamGenerator = TeamGenerator;
        }

        /// <summary>
        /// GET operation to request all Day Events stored
        /// </summary>
        /// <returns>An IAction result of all Days available</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Day> Days = null;
            try
            {
                Days = _DayRepository.GetAllDays();
                if(Days == null || Days.Count() <= 0)
                {
                    return NotFound();
                }
                else
                {
                    //Ok we can return the standard days for now
                    return Ok(Days);
                }
            }
            catch(JsonSerializationException e)
            {
                //TODO - Log the error and change from default Exception
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Operation to get the Day operation by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Day model = null;
            try
            {
                model = _DayRepository.GetDayByID(id);
                if(model == null)
                {
                    return NotFound();
                }
                else
                {
                    //Ok we can return the standard days for now
                    return Ok(model);
                }
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// POST operation to request a collection of Day objects available within a date range
        /// </summary>
        /// <param name="StartDate">The date to start the filter/search</param>
        /// <param name="EndDate">The date to end the filter/search</param>
        /// <returns>An IActionResult with the number of days in range</returns>
        [HttpPost]
        public IActionResult DaysInRange([FromBody]DateTime StartDate, [FromBody]DateTime EndDate)
        {
            IEnumerable<Day> Days = null;
            try
            {
                Days = _DayRepository.GetDaysInDateRange(StartDate, EndDate);
                if(Days == null || Days.Count() <= 0)
                {
                    return NotFound();
                }
                else
                {
                    //Ok we can return the standard days for now
                    return Ok(Days);
                }
            }
            catch(Exception e)
            {
                //TODO - Log the error and change from default Exceptioj
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// POST operation to handle the creation and storage of a new day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NewMatchDay")]
        public IActionResult CreateNewDay([FromBody] Day day)
        {
            int result = _DayRepository.AddNewDay(day);

            if(result == 1)
            {
                return Ok("Day added");
            }
            else
            {
                return BadRequest("Failed to add day");
            }

        }

        /// <summary>
        /// Operation to POST a group of players and a date and to return a playing day
        /// with a random order/grouping of teams
        /// </summary>
        /// <param name="Players">Collection of players to sort</param>
        /// <param name="Date">The date to generate it on</param>
        /// <returns>An IActionResult</returns>
        [HttpPost]
        [Route("CreateDayForPlayersOnDate")]
        public IActionResult CreateDayForPlayersOnDate([FromBody] IEnumerable<Player> Players, [FromBody]DateTime Date)
        {
            IEnumerable<Team> Teams = _TeamGenerator.CreateRandomTeamsFromPlayerList(Players);

            Day Result = new Day();

            if(Teams != null && Teams.Count() > 0)
            {
                //Set the date of the Day
                Result.Date = Date;

                //Initialise both teams and populate
                Result.TeamOne = Teams.ToList()[0];
                Result.TeamTwo = Teams.ToList()[1];

                return Ok(Result);
            }
            return NotFound();
        }
    }
}