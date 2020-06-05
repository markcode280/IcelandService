using IcelandService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IcelandService.Services
{
    public class ProductProccessService: IProductProccessService
    {
        private readonly IFileService _fileService;
        public ProductProccessService(IFileService fileService)
        {
            _fileService = fileService;
        }
        public IList<ProductQuality> GetProducts(string path)
        {
             return _fileService.upload<ProductQuality>(path, " ");
        }
        public void proccessProductQualityDecrease(ProductQuality product)
        {
            var qualityIncrese = new List<string>{ "Aged Brie", "Christmas Crackers" };
            var noQualityChange = new List<string>{ "Soap" };

                if (DateTime.Now.Hour>= 16 && !noQualityChange.Contains(product.ProductName))
                {
                    product.SellInValue = product.SellInValue - 1;

                if (product.QualityValue >= 0 && product.QualityValue<=50 )
                    {

                    if (product.ProductName.Contains("Christmas Crackers") )
                    {
                        if (product.SellInValue <=10 && product.SellInValue >5)
                        {
                            product.QualityValue = product.QualityValue + 2;
                        }
                        else if(product.SellInValue<=5 &&product.SellInValue>0) // assuming the sellin value is started during christmas period
                        {
                            product.QualityValue = product.QualityValue + 3;
                        }
                        else
                        {
                            product.QualityValue = 0;
                        }
                    }else if(product.ProductName.Contains("Aged Brie"))
                    {
                        product.QualityValue = product.QualityValue + 1;
                    }else if(product.ProductName.Contains("Frozen Item") || product.ProductName.Contains("Fresh Item"))
                    {
                        if (product.ProductName.ToLower().Contains("Frozen Item".ToLower()))
                        {
                            product.QualityValue = product.QualityValue - 1;
                        }
                        if (product.ProductName.ToLower().Contains("Fresh Item".ToLower()))
                        {
                            product.QualityValue = product.SellInValue<0? product.QualityValue + (product.SellInValue * 2): product.QualityValue - (product.SellInValue * 2);  // if this value changes then will have to re-write adding constants to product obeject
                        }
                    }
                    else 
                    {
                      
                        if (product.SellInValue < 0)
                        {
                            product.QualityValue = product.QualityValue < 0 ? 0: product.QualityValue - (product.SellInValue * 2);
                        }
                        else
                        {
                            product.QualityValue = product.QualityValue - 1;

                        }
                    }
  
                }
                else if(product.QualityValue > 50)
                {
                    product.QualityValue = 50;
                }

                if(product.ProductName.ToUpper().Contains("INVALID ITEM"))
                {
                    product.ProductName = "NO SUCH ITEM";
                    product.QualityValue = 0;
                    product.SellInValue = 0;
                }
            }
        }
        public void WriteToFile(ProductQuality product,string fileLocation)
        {
            _fileService.save(product, fileLocation);
        }
    }
}
