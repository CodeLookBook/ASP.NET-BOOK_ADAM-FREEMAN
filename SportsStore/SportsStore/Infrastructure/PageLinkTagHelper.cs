using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext   { get; set; }
        public PagingInfo  PageModel     { get; set; }
        public string      PageAction    { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();


        public bool   PageClassesEnabled { get; set; } = false;
        public string PageClass          { get; set; }
        public string PageClassNormal    { get; set; }
        public string PageClassSelected  { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.UrlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = this.UrlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result    = new TagBuilder("div");

            for (int i = 1; i <= this.PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                tag.Attributes["href"] = urlHelper.Action(PageAction, new { Page = i });

                this.PageUrlValues["page"] = i;

                tag.Attributes["href"] = urlHelper.Action(this.PageAction, this.PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == this.PageModel.CurrentPage ? this.PageClassSelected : this.PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
