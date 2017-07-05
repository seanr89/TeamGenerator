
using System;
using System.Collections.Generic;

namespace APIGenerator.Models
{
    public class Team
    {
        public int ID { get; set; }

        public List<Player> Players { get; set; }
    }
}