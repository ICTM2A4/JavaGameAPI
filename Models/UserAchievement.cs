using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaGameAPI.Models
{
    public class UserAchievement
    {
        public int UserID { get; set; }

        public User User { get; set; }

        public int AchievementID { get; set; }

        public Achievement Achievement { get; set; }
    }
}
