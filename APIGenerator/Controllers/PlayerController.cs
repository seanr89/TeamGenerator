using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerController(ILogger<PlayerController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            JSONFileReader reader = new JSONFileReader();
            string FileContents = reader.ReadFileContentsForContentType(FileType.PLAYER);

            if(string.IsNullOrWhiteSpace(FileContents))
            {
                return NotFound();
            }

            IEnumerable<Player> Players;
            try
            {
               Players = UtilityMethods.ConvertJsonStringToProvidedGenericType<IEnumerable<Player>>(FileContents);
               if(Players == null && Players.Count() <= 0)
               {
                   return NotFound();
               }
               return Ok(Players);
            }
            catch(Exception e)
            {
                //TODO - Log the error
                _Logger.LogError("1", $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return BadRequest();
            }
        }

    }
}