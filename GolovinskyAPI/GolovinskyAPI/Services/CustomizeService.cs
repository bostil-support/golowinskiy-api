using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Linq;

namespace GolovinskyAPI.Services
{
    public class CustomizeService
    {
        
        public string GetMainImage()
        {
            string prefix = "wwwroot/Images\\";
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string searchresult = prefix + date;
            var directoryFiles = Directory.GetFiles("wwwroot/Images");
            var image = Array.Find(directoryFiles, s => s.StartsWith(searchresult));
            if(directoryFiles.Contains(image))
            {
                var result = image.Substring(image.LastIndexOf('\\') + 1); ;
                return result;
            }
            else
            {
                var random = new Random();
                int index = random.Next(directoryFiles.Length - 1);
                image = directoryFiles[index];
                var result = image.Substring(image.LastIndexOf('\\') + 1);


                return result;

            }
            
        }

        public string GetMainImageUserAccount()
        {

            string prefix = "wwwroot/AccountImages\\";
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string searchresult = prefix + date;
            var directoryFiles = Directory.GetFiles("wwwroot/AccountImages");
            string image = Array.Find(directoryFiles, s => s.StartsWith(searchresult));
            if(directoryFiles.Contains(image))
            {
                var result = image.Substring(image.LastIndexOf('\\') + 1); 
                return result;
            }
            else
            {
                var random = new Random();
                int index = random.Next(directoryFiles.Length - 1);
                image = directoryFiles[index];
                var result = image.Substring(image.LastIndexOf('\\') + 1);

                return result;
            }
           
               
            
        } 
    }
}