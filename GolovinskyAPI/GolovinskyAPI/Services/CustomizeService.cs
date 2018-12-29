using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Linq;

namespace GolovinskyAPI.Services
{
    public class CustomizeService
    {
        public string date = DateTime.Now.ToString("dd.MM.yyyy");
        public string GetMainImage()
        {

          var directoryFiles = Directory.GetFiles("wwwroot/Images");

            /*
            string image = Array.Find(directoryFiles, s => s.StartsWith(date));
              
            var result = image;
               */


            var random = new Random();
            int index = random.Next(directoryFiles.Length - 1);
            string image = directoryFiles[index];
            var result = image.Substring(image.LastIndexOf('\\') + 1);


            return result;






          }

          public string GetMainImageUserAccount()
          {
              var directoryFiles = Directory.GetFiles("wwwroot/AccountImages");
            /*
               string image = Array.Find(directoryFiles, s => s.StartsWith(date));
              
              var result = image;
              */
            var random = new Random();
               int index = random.Next(directoryFiles.Length - 1);
               string image = directoryFiles[index];
               var result = image.Substring(image.LastIndexOf('\\') + 1);
              
            return result;
            
        } 
    }
}