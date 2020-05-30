namespace BlogR.Core.Data.Entities
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User Author { get; set; }
    }
}