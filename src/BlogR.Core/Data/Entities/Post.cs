namespace BlogR.Core.Data.Entities
{
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public int ViewCount { get; set; }
        public virtual User Author { get; set; }
    }
}
