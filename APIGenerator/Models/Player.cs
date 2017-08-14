
using System.Collections.Generic;

namespace APIGenerator.Models
{
    public class Player
    {
        public int ID { get; set; }

        /// <summary>
        /// Name of the player - as a string
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Style> Styles { get; set; }

        /// <summary>
        /// double value denoting the default rating for a player
        /// (out of 10)?
        /// </summary>
        /// <returns></returns>
        public double Rating { get; set; }
    }
}