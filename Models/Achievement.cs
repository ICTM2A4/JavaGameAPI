using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JavaGameAPI.Models
{
    public class Achievement
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}
