using IcelandService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcelandService.Services
{
    public interface IProductProccessService
    {
        IList<ProductQuality> GetProducts(string path);
        void proccessProductQualityDecrease(ProductQuality product); 
        void WriteToFile(ProductQuality product, string fileLocation);
    }
}
