using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class PostListItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ShortContent { get; set; }
        public string? FeaturedImage { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
    }

    public class PostDetail
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? FeaturedImage { get; set; }
        public string? Subtitle { get; set; } = null;
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
        public int ReadCount { get; set; } = 0;
        public bool Draft { get; set; }
    }
}
