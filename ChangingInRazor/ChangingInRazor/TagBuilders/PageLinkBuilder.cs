using ChangingInRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ChangingInRazor.TagBuilders
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkBuilder : TagHelper
    {

        public string PageAction { get; set; }
        public PageInfoModel PageModel { get; set; }



        IUrlHelperFactory urlHelperFactory;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageLinkBuilder(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }



        /*
         * <div aria-label="...">
  <ul class="pagination">
   
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item active" aria-current="page">
      <a class="page-link" href="#">2</a>
    </li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
  
  </ul>
</div>
         */

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            TagBuilder ul = new TagBuilder("ul");

            ul.AddCssClass("pagination");
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (i == PageModel.ActivePage)
                {
                    li.AddCssClass("active");
                }

                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                a.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });

                a.InnerHtml.AppendHtml(i.ToString());
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);


            }

            div.InnerHtml.AppendHtml(ul);

            output.Content.AppendHtml(div);


        }
    }
}
