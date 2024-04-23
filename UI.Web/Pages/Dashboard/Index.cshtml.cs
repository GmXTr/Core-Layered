using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Web.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IPostService service;

        public IndexModel(IPostService service)
        {
            this.service = service;
        }

        public IEnumerable<PostListItem> Posts { get; private set; }


        public async Task OnGetAsync()
        {
            Posts = await service.GetPostsAsync();
        }
    }
}
