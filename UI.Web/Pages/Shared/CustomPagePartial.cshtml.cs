using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Web.Pages.Shared
{
    public class CustomPagePartialModel : PageModel
    {
        public string Header { get; set; }
        public void OnGet()
        {
            Header = "Custom Razor Page";
        }
    }
}
