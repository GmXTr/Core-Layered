using Core.Abstracts.IServices;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UI.Web.Pages.Dashboard
{
    public class EditModel : PageModel
    {
        public class InputModel
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

            public string? FeaturedImagePath { get; set; }

            [Display(Name = "Post Subtitle", Prompt = "Post Subtitle")]
            public string? Subtitle { get; set; } = null;

            [Display(Name = "Post Category", Prompt = "Post Category")]
            public int CategoryId { get; set; }

            [Display(Name = "Tags", Prompt = "Tags")]
            public string? Tags { get; set; }
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public SelectList? Categories { get; set; }

        private readonly IPostService service;

        public EditModel(IPostService service)
        {
            this.service = service;
        }

        public async Task OnGetAsync(int id)
        {
            var post = await service.GetPostAsync(id);
            Input = new InputModel
            {
                Title = post.Title,
                Content = post.Content,
                PublishDate = post.PublishDate,
                CategoryId = post.CategoryId,
                Draft = false,
                FeaturedImagePath = post.FeaturedImage,
                Subtitle = post.Subtitle,
                Tags = string.Join(",", post.Tags)
            };

            Categories = new SelectList(await service.GetCategoriesAsync(), "Id", "Name", post.CategoryId);
        }
    }
}
