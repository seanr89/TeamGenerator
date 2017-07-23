

using System.Collections.Generic;
using APIGenerator.Models;

namespace APIGenerator.Business.Interfaces
{
    /// <summary>
    /// Interface to provide methods for handling generation of teams
    /// </summary>
    public interface ITeamGenerator
    {
        /// <summary>
        /// Interface operation to handle the generation of two individual teams
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        IEnumerable<Team> CreateRandomTeamsFromPlayerList(IEnumerable<Player> Players);
    }
    
}