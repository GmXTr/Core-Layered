using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

namespace UI.Web
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public required string Address { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{Address}");
            output.Content.SetContent(Address);
        }
    }

    [HtmlTargetElement("tel")]
    public class TelTagHelper : TagHelper
    {
        public required string Number { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string n = Regex.Replace(Number, @"[^\d\+]", "");
            output.Attributes.SetAttribute("href", $"tel:{n}");
            output.Content.SetContent(Number);
        }
    }

    [HtmlTargetElement("card")]
    public class CardTagHelper : TagHelper
    {
        public string Header { get; set; }
        public string Caption { get; set; }
        public string Footer { get; set; }
        public string ImgSrc { get; set; }
        public bool Bordered { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("card", null);
            if (!Bordered) output.AddClass("border-0", null);
        }
    }
}
