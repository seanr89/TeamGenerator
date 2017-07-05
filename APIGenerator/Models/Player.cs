
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

        public bool Paid { get; set; }
    }
}