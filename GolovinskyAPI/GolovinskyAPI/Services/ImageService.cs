using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Services
{
    public class ImageService : IImageService
    {
        private IRepository _repository;
        public ImageService(IRepository rep)
        {
            _repository = rep;
        }

        public byte[] GetImageByName(string storeId, string name)
        {
            return _repository.GetImageMobile(storeId, name);
        }
    }
}
