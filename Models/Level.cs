using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JavaGameAPI.Models
{
    public class Level
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        // References
        public User Creator { get; set; }

        public List<Score> Scores { get; set; } = new List<Score>();
    }
}
