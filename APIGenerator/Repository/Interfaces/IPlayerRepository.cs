
using System.Collections.Generic;
using APIGenerator.Models;

namespace APIGenerator.Repository.Interfaces
{
    /// <summary>
    /// Interface to detail the repository operations to be made available for player information
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Interface operation to Create a new player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        int CreatePlayer(Player player);

        /// <summary>
        /// Interface operation to read out all knownplayers
        /// </summary>
        /// <returns></returns>
        IEnumerable<Player> GetAllPlayers();

        /// <summary>
        /// Interface operation to Update an individual player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        int UpdatePlayer(Player player);

        /// <summary>
        /// Interface operation to Delete an individual player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        int DeletePlayer(Player player);

        /// <summary>
        /// Interface operation to return the next ID to be used
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        int GetNextPlayerID(IEnumerable<Player> Players);
    }
}