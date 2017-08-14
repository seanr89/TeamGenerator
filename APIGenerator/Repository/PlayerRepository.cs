using System;
using System.Collections.Generic;
using System.Linq;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Models.Utility;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace APIGenerator.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ILogger _Logger;
        private readonly JSONFileReader _DataFileAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        /// <param name="DataFileAccessor"></param>
        public PlayerRepository(ILogger<PlayerRepository> Logger,
            JSONFileReader DataFileAccessor)
        {
            _Logger = Logger;
            _DataFileAccessor = DataFileAccessor;
        }

        /// <summary>
        /// Operation to handle the insertion of a new player into the system
        /// </summary>
        /// <param name="player">The player object to add</param>
        /// <returns>An integer value to denote if success or not</returns>
        public int CreatePlayer(Player player)
        {
            try
            {
                //Request all players and convert to the list item
                List<Player> ModelList = GetAllPlayers().ToList();

                //next increment the player ID value
                int NewPlayerID = GetNextPlayerID(ModelList);
                //ensure that an ID was discovered
                if(NewPlayerID != -1)
                {
                    player.ID = NewPlayerID;
                }

                //Append the new day to the list
                ModelList.Add(player);
                //Convert the upgraded list to a JSON object
                string JSONObject = UtilityMethods.ConvertObjectToJSONString(ModelList);
                //Write the contents to a file
                int result = _DataFileAccessor.WriteToFileForType(JSONObject, FileType.PLAYER);
                //return the output of the file write
                return result;
            }
            catch(JsonSerializationException e)
            {
                //TODO - log stuff
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"exception caught in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return -1;
            }
        }

        /// <summary>
        /// TODO - currently not implemented
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Operation to request and return all Known Players
        /// </summary>
        /// <returns>An IEumerable of Player objects</returns>
        public IEnumerable<Player> GetAllPlayers()
        {
            string DayFileContents = _DataFileAccessor.ReadFileContentsForContentType(FileType.PLAYER);
            List<Player> ModelList = null;

            if(string.IsNullOrWhiteSpace(DayFileContents))
            {
                return ModelList;
            }
            
            try
            {
                ModelList = (List<Player>)UtilityMethods.ConvertJsonStringToProvidedGenericType<IEnumerable<Player>>(DayFileContents);
                return ModelList;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Operation to request the highest ID in the player list and to return next increment
        /// </summary>
        /// <param name="Players"></param>
        /// <returns>-1 returned if not found</returns>
        public int GetNextPlayerID(IEnumerable<Player> Players)
        {
            try
            {
                var result = Players.OrderByDescending(p => p.ID).FirstOrDefault();
                if(result != null)
                {
                    return result.ID + 1;
                }
                return -1;
            }
            catch(ArgumentNullException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} " +
                "with exception {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}