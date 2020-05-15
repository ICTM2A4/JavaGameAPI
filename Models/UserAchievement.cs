using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
