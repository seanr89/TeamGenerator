using System;
using System.Collections.Generic;
using System.Linq;
using APIGenerator.Business.Interfaces;
using APIGenerator.Models;
using APIGenerator.Models.Utility;
using APIGenerator.Utilities;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Business
{
    /// <summary>
    /// Class to handle random team generation with player rating management
    /// implements the ITeamGenerator interface
    /// </summary>
    public class RatingTeamsGenerator : ITeamGenerator
    {
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public RatingTeamsGenerator(ILogger<RatingTeamsGenerator> Logger)
        {
            _Logger = Logger;
        }

        /// <summary>
        /// Operation to handle the generation of two unique teams that are balanced by average player rating
        /// Not yet implemented
        /// </summary>
        /// <param name="Players"></param>
        /// <returns>NotImplementedException</returns>
        public IEnumerable<Team> CreateRandomTeamsFromPlayerList(IEnumerable<Player> Players)
        {
            throw new NotImplementedException();

            List<Team> ModelList = null;
            Team TeamOne = null;
            Team TeamTwo = null;

            //Check if any players have been inserted
            if(Players != null && Players.Count() > 0)
            {
                //Check if the player count is even
                if(!UtilityMethods.IsEven(Players.Count()))
                {
                    _Logger.LogInformation(LoggingEvents.INFORMATION, $"Player count is not even, with count {Players.Count()}");
                }

                //Initialise all of the corresponding objects
                ModelList = new List<Team>();
                TeamOne = new Team();
                TeamTwo = new Team();

                //Ok shuffle the players with a utility call
                //Please note we may not need this here!!!
                //UtilityMethods.Shuffle<Player>(Players.ToList());

                //it could be useful to sort players by rating!!
                Players = SortPlayersByRating(Players).ToList();

                //Use boolean variable to highlight if the previous player was added to team one
                bool AddedToTeamOne = false;

                //Initialise the rating for both teams
                double TeamOneRating, TeamTwoRating = 0.0;

                //Now we can loop through the players
                foreach(Player player in Players)
                {

                }
            }

            return ModelList;
        }

        /// <summary>
        /// private method to check if Two teams have the same player count
        /// </summary>
        /// <param name="TeamOne">First team to check</param>
        /// <param name="TeamTwo">Second team to be compared</param>
        /// <returns>A Boolean True/False</returns>
        bool AreTeamNumbersEven(Team TeamOne, Team TeamTwo)
        {
            bool result = false;
            if(TeamOne.Players.Count == TeamTwo.Players.Count)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Operation to sort all players by the rating starting from highest to lowest
        /// </summary>
        /// <param name="players">a collection of players</param>
        /// <returns>A sorted list of players</returns>
        IEnumerable<Player> SortPlayersByRating(IEnumerable<Player> players)
        {
            return players.ToList().OrderBy(p => p.Rating);
        }

        double CalculateTeamRatingAverage(Team team)
        {
            throw new NotImplementedException();
        }
    }
}