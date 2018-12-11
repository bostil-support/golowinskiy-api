using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace GolovinskyAPI.Services
{
    public class CustomizeService
    {
        public string GetMainImage(){
            var directoryFiles = Directory.GetFiles("wwwroot/Images");
            var random = new Random();
            int index = random.Next(directoryFiles.Length - 1);
            string image = directoryFiles[index];
            var result = image.Substring(image.LastIndexOf('\\') + 1); 

            return result;           
        } 
    }
}