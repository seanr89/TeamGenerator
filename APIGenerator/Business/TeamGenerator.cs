
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
    /// Class object to provide business logic to randomly generate two teams based on the provided list of players
    /// </summary>
    public class TeamGenerator : ITeamGenerator
    {
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamGenerator(ILogger<TeamGenerator> Logger)
        {
            _Logger = Logger;
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
        /// operation to populate and return two teams with "random" players
        /// </summary>
        /// <param name="Players">List of players to allocate to the teams</param>
        /// <returns>a collection of two teams</returns>
        public IEnumerable<Team> CreateRandomTeamsFromPlayerList(IEnumerable<Player> Players)
        {
            List<Team> ModelList = null;
            Team TeamOne = null;
            Team TeamTwo = null;

            //Check if any players have been inserted
            if(Players != null && Players.Count() > 0)
            {
                //Check if the player count is even
                if(!IsEven(Players.Count()))
                {
                    _Logger.LogInformation(LoggingEvents.INFORMATION, $"Player count is not even, with count {Players.Count}");
                }

                //Initialise all of the corresponding objects
                ModelList = new List<Team>();
                TeamOne = new Team();
                TeamTwo = new Team();

                //Ok shuffle the players with a utility call
                UtilityMethods.Shuffle(Players);

                //Use boolean variable to highlight if the previous player was added to team one
                bool AddedToTeamOne = false;

                //Start with a simple for/foreach loop
                foreach(Player player in Players)
                {
                    if(AddedToTeamOne)
                    {
                        TeamTwo.Players.Add(player);
                        AddedToTeamOne = false;
                        continue;
                    }
                    else
                    {
                        TeamOne.Players.Add(player);
                        AddedToTeamOne = true;
                    }
                }
            }
            return ModelList;
        }

        /// <summary>
        /// Operation to check if the provided integer value is Even
        /// </summary>
        /// <param name="value">Integer value to compare</param>
        /// <returns>A Boolean True/False response</returns>
        bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
}