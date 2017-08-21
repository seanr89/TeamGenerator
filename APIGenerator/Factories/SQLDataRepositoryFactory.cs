

using System;
using APIGenerator.Factories.Interfaces;
using APIGenerator.Repository.Interfaces;
using APIGenerator.Repository.SQL;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Factories
{
    public class SQLDataRepositoryFactory : IDataRepositoryFactory
    {
        private readonly ILogger _Logger;

        public SQLDataRepositoryFactory(ILogger<SQLDataRepositoryFactory> Logger)
        {
            _Logger = Logger;
        }

        public IDayRepository GetDayRepository()
        {
            return new SQLDayRepository();
        }

        public IPlayerRepository GetPlayerRepository()
        {
            return new SQLPlayerRepository();
        }
    }
}