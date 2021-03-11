using System;
using System.Collections.Generic;
using Assignment5Webpage.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assignment5Webpage.Infrastructure
{
    //Attribute
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        //Constructor
        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        //Attributes
        [ViewContext]
        [HtmlAttributeNotBound]
        //Property (with Attributes attached)
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; } //creating a new instance and making it an attribute of the class
        public string PageAction { get; set; } // this refers to Index

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]//Saves anything that has the page-url prefix to the dictionary
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //Overloading Methods = when method has exact same name but different options for number of parameters
        //Override a Method = replace in order to implement the methods.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); //.Action(PageAction, new { page = i})

            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++) //i is equal to page number
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            //display the finished product of the above HTML, builds page numbers;
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}