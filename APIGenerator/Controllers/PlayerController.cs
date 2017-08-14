using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace APIGenerator.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ILogger _Logger;
        private readonly IPlayerRepository _PlayerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerController(ILogger<PlayerController> logger,
            IPlayerRepository playerRepository)
        {
            _Logger = logger;
            _PlayerRepository = playerRepository;
        }

        /// <summary>
        /// Operation to request all Players stored
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //_Logger.LogInformation("Get called");
            try
            {
                IEnumerable<Player> ModelList = _PlayerRepository.GetAllPlayers();
                if(ModelList != null)
                {
                    return Ok(ModelList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError("1", $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest(e.Message);
            }
        }
        
        /// <summary>
        /// POST operation to create/insert a new player object
        /// </summary>
        /// <param name="player">A player object model</param>
        /// <returns>An IActionResult</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Player player)
        {
            int result = _PlayerRepository.CreatePlayer(player);
            if(result == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}