using System;

namespace BlogR.Core.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public DateTime? LastModifiedUtc { get; set; }

        public BaseEntity()
        {
            CreationTimeUtc = DateTime.UtcNow;
        }
    }
}
