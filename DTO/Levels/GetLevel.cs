namespace JavaGameAPI.DTO.Levels
{
    public class GetLevel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        // References
        public int CreatorID { get; set; }

        public string CreatorUserName { get; set; }
    }
}
