using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UI.MVC.Models
{
    public class CreatePostViewModel
    {
        [Required]
        [Display(Name = "Post Title", Prompt = "Post Title")]
        public required string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Post HTML Content", Prompt = "Post HTML Content")]
        public required string Content { get; set; }

        [Display(Name = "Publish Date", Prompt = "Publish Date")]
        public DateTime? PublishDate { get; set; } = DateTime.Now;

        [Display(Name = "Is Draft?")]
        public bool Draft { get; set; } = true;

        [Display(Name = "Featured Image")]
        [DataType(DataType.Upload)]
        public IFormFile? FeaturedImage { get; set; }

        [Display(Name = "Post Subtitle", Prompt = "Post Subtitle")]
        public string? Subtitle { get; set; } = null;

        [Display(Name = "Post Category", Prompt = "Post Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Tags", Prompt = "Tags")]
        public string? Tags { get; set; }
    }

    public class EditPostViewModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Post Title", Prompt = "Post Title")]
        public required string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Post HTML Content", Prompt = "Post HTML Content")]
        public required string Content { get; set; }

        [Display(Name = "Publish Date", Prompt = "Publish Date")]
        public DateTime? PublishDate { get; set; } = DateTime.Now;

        [Display(Name = "Is Draft?")]
        public bool Draft { get; set; } = true;

        [Display(Name = "Featured Image")]
        [DataType(DataType.Upload)]
        public IFormFile? FeaturedImage { get; set; }

        [HiddenInput]
        public string? FeaturedImagePath { get; set; }

        [Display(Name = "Post Subtitle", Prompt = "Post Subtitle")]
        public string? Subtitle { get; set; } = null;

        [Display(Name = "Post Category", Prompt = "Post Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Tags", Prompt = "Tags")]
        public string? Tags { get; set; }
    }
}
