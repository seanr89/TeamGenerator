

using System;
using APIGenerator.DataLayer;
using APIGenerator.Factories.Interfaces;
using APIGenerator.Repository;
using APIGenerator.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Factories
{
    public class JSONDataRepositoryFactory : IDataRepositoryFactory
    {
        public readonly ILogger _Logger;
        private readonly JSONFileReader _FileReader;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        /// <param name="FileReader"></param>
        public JSONDataRepositoryFactory(ILogger<JSONDataRepositoryFactory> Logger, JSONFileReader FileReader)
        {
            _Logger = Logger;
            _FileReader = FileReader;
        }

        /// <summary>
        /// Request the Day Repository object
        /// </summary>
        /// <returns></returns>
        public IDayRepository GetDayRepository()
        {
            return new DayRepository(_FileReader);
        }

        /// <summary>
        /// Request an available Player Repository
        /// </summary>
        /// <returns></returns>
        public IPlayerRepository GetPlayerRepository()
        {
            return new PlayerRepository(_FileReader);
        }
    }
}