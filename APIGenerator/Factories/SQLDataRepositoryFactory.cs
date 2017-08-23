

using System;
using APIGenerator.Factories.Interfaces;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Repository.SQL;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Factories
{
    /// <summary>
    /// Factory object to provide data repository class access for SQL requests
    /// </summary>
    public class SQLDataRepositoryFactory : IDataRepositoryFactory
    {
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public SQLDataRepositoryFactory(ILogger<SQLDataRepositoryFactory> Logger)
        {
            _Logger = Logger;
        }

        /// <summary>
        /// Request the SQL data repository access class
        /// </summary>
        /// <returns></returns>
        public IDayRepository GetDayRepository()
        {
            return new SQLDayRepository();
        }

        /// <summary>
        /// Request the SQL data repository access class
        /// </summary>
        /// <returns></returns>
        public IPlayerRepository GetPlayerRepository()
        {
            return new SQLPlayerRepository();
        }
    }
}