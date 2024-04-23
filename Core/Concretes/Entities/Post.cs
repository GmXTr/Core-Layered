using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Post : BaseEntity
    {
        public required string Content { get; set; }
        public DateTime? PublishDate { get; set; } = null;
        public bool Draft { get; set; } = true;
        public string? FeaturedImage { get; set; }
        public string? Subtitle { get; set; } = null;
        public int ReadCount { get; set; } = 0;
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; } = new HashSet<Tag>();
    }
}
