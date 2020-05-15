using System;

namespace JavaGameAPI.DTO
{
    public class PostScore
    {
        public int ID { get; set; }

        public double ScoreAmount { get; set; }

        public DateTime Timestamp { get; set; }

        public int UserID { get; set; }

        public int ScoredOnID { get; set; }
    }
}
