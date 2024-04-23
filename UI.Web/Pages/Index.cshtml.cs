using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPostService service;
        public IndexModel(ILogger<IndexModel> logger, IPostService service)
        {
            _logger = logger;
            this.service = service;
        }

        public IEnumerable<PostListItem> Posts { get; set; } = new HashSet<PostListItem>();

        public async Task OnGetAsync()
        {
            Posts = await service.GetPostsAsync();
        }
    }
}