
using System;

namespace APIGenerator.Models
{
    public class Day
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public Team TeamOne {get; set;}

        public Team TeamTwo { get; set; }
    }
}