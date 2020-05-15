using System;
using System.ComponentModel.DataAnnotations;

namespace JavaGameAPI.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }

        public double ScoreAmount { get; set; }

        public DateTime Timestamp { get; set; }


        // References
        [Required]
        public User User { get; set; }

        [Required]
        public Level ScoredOn { get; set; }
    }
}
