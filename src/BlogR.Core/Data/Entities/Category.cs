using System.Collections.Generic;

namespace BlogR.Core.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<PostCategorization> PostCategorization { get; set; }
    }
}
