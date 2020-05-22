using System.ComponentModel.DataAnnotations;

namespace JavaGameAPI.Models
{
    public class UserAchievement
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int AchievementID { get; set; }

        [Required]
        public Achievement Achievement { get; set; }
    }
}
