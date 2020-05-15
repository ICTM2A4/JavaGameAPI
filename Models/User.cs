using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JavaGameAPI.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        // References
        public List<Level> Levels { get; set; } = new List<Level>();

        public List<Score> Scores { get; set; } = new List<Score>();

        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    }
}
