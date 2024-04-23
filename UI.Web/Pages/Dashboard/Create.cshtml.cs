using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UI.Web.Pages.Dashboard
{
    public class CreateModel : PageModel
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

        public CreateModel(IPostService service, IMapper mapper)
        {
            this.service = service;
            Categories = new SelectList(service.GetCategoriesAsync().Result, "Id", "Name");
        }

        public async Task OnGetAsync()
        {

        }

        public async Task OnPostAsync()
        {
            await service.CreatePostAsync(new Post
            {
                Title = Input.Title,
                Subtitle = Input.Subtitle,
                Content = Input.Content,
                CategoryId = Input.CategoryId,
                Draft = Input.Draft,
                FeaturedImage = Input.FeaturedImage == null ? "https://placeholder.co/800x450" : "",
                PublishDate = Input.PublishDate
            }, Input.Tags?.Split(','));

            RedirectToPage("index");
        }
    }
}
