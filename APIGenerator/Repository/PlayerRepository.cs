using System;
using System.Collections.Generic;
using APIGenerator.Models;
using APIGenerator.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ILogger _Logger;

        public PlayerRepository(ILogger<PlayerRepository> Logger)
        {
            _Logger = Logger;
        }

        int IPlayerRepository.CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        int IPlayerRepository.DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Player> IPlayerRepository.GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        int IPlayerRepository.GetNextPlayerID()
        {
            throw new NotImplementedException();
        }

        int IPlayerRepository.UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}