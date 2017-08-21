using System;
using System.Collections.Generic;
using APIGenerator.Models;
using APIGenerator.Repository.Interfaces;

namespace APIGenerator.Repository.SQL
{
    public class SQLPlayerRepository : IPlayerRepository
    {
        public int CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public int DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public int GetNextPlayerID(IEnumerable<Player> Players)
        {
            throw new NotImplementedException();
        }

        public int UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}