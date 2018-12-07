using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace GolovinskyAPI.Models.ViewModels.Images
{
    public class NewUploadImageInput
    {
        // id магазина
        public string AppCode { get; set; }
        // наименование картинки
        public string TImageprev { get; set; }
        // сама картинка
        public  IFormFile Img { get; set; }
    }

    public class NewUploadImageInput2
    {
        // id магазина
        public string AppCode { get; set; }
        // наименование картинки
        public string TImageprev { get; set; }
        // сама картинка
        public byte[] Img { get; set; }
    }
}
