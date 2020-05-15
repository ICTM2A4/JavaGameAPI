namespace JavaGameAPI.DTO.Levels
{
    public class PostLevel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        // References
        public int CreatorID { get; set; }
    }
}
