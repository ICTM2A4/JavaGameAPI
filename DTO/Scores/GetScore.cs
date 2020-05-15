using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaGameAPI.DTO
{
    public class GetScore
    {
        public int ID { get; set; }

        public double ScoreAmount { get; set; }

        public DateTime Timestamp { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public int ScoredOnID { get; set; }

        public string ScoredOnName { get; set; }
    }
}
