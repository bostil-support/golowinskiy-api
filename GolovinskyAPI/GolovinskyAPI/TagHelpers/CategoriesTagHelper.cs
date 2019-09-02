using GolovinskyAPI.Models.ViewModels.Categories;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace GolovinskyAPI.TagHelpers
{
    public class MenuCategoriesTagHelper : TagHelper
    {
        public List<SearchAvitoPictureOutput> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
                        
            AddCategory(Items, output);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private void AddCategory(List<SearchAvitoPictureOutput> Items, TagHelperOutput output)
        {
            if (Items.Count == 0)
            {
                return;
            }

            output.Content.AppendHtml($@"<ul class='sub-menu'>");
            foreach (var item in Items)
            {
                if (item.ListInnerCat.Count != 0)
                {
                    output.Content.AppendHtml($@"<li class='menu-item menu-item-has-children dropdown'><a href='#'>{item.txt}</a>");
                    AddCategory(item.ListInnerCat, output);
                }
                else
                {
                    output.Content.AppendHtml($@"<li class='menu-item'><a href='products/{item.cust_id}/{item.id}'>{item.txt}</a>");
                }
                
                output.Content.AppendHtml($@"</li>");
            }
            output.Content.AppendHtml($@"</ul>");
        }
    }
}
