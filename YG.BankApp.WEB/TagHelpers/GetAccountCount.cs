using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using YG.BankApp.WEB.Data.Context;

namespace YG.BankApp.WEB.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;

        public GetAccountCount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId == ApplicationUserId);
            string html;
            if (accountCount>0)
            {
                html = $"<span class='badge bg-success'>{accountCount}</span> ";
            }
            else
            {
                html = $"<span class='badge bg-danger'>{accountCount}</span> ";
            }
            
            output.Content.SetHtmlContent(html);
        }
    }
}
