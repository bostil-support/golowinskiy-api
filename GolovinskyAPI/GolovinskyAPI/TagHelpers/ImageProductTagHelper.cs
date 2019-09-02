using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;


namespace GolovinskyAPI.TagHelpers
{
    public class ImageProductTagHelper : TagHelper
    {
        private readonly IOptions<AppSettings> _appSettings;

        public ImageProductTagHelper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string url;
            if (Name == "noimage.png")
                url = "/images/access/1.jpg";
            else
                url = $"{_appSettings.Value.ApiUrl}/Img?AppCode=19139&ImgFileName={Name}";

            output.TagName = "img";
            output.Attributes.Add("src", url);

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
