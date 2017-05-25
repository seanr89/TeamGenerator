using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGenerator.DataLayer;
using APIGenerator.Models;
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
            
        }

    }
}