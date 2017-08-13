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

        public PlayerRepository(ILogger<PlayerRepository> Logger,
            JSONFileReader DataFileAccessor)
        {
            _Logger = Logger;
            _DataFileAccessor = DataFileAccessor;
        }

        public int CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public int DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Operation to request and return all Known Players
        /// </summary>
        /// <returns>An IEumerable of Player objects</returns>
        IEnumerable<Player> GetAllPlayers()
        {
            string DayFileContents = _DataFileAccessor.ReadFileContentsForContentType(FileType.DAY);
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
        /// <returns>-1 returned if not found</returns>
        int IPlayerRepository.GetNextPlayerID()
        {
            try
            {
                List<Player> ModelList = GetAllPlayers().ToList();
                var result = ModelList.OrderByDescending(p => p.ID).FirstOrDefault();
                if(result != null)
                {
                    return result.ID + 1;
                }
                return -1;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
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