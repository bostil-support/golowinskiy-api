using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Services.Interfaces
{
    public interface IImageService
    {
        byte[] GetImageByName(string storeId, string name);
    }
}
