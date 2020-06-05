using IcelandService.Extensions;
using IcelandService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IcelandService.Services
{
    public class TextFileService : IFileService
    {
       
      
        public void save(object text, string fileLocation)
        {
            var items = text.ConvertPropertyToStringObj();
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation);
            }
            using (StreamWriter writer = File.CreateText(fileLocation))
            {
                foreach (var item in items)
                {

                    writer.WriteLine(item);

                }

            }
        }
        // instead of explicitly defining the model could specifiy a rule to determine the model. this is beyond the scope of this project.
        public List<ProductQuality> upload<ProductQuality>(string path, string splitCharacter) where ProductQuality: new()
        {
            var productQuality = new List<ProductQuality>();
           
            var items=File.ReadAllLines(path).ToList();
            foreach(var line in items)
            { 
                var productQualityItem = new Models.ProductQuality();

                var objItems = line.Split(splitCharacter).ToList();
                int numberValue = 0;

                for (int i = objItems.Count; i >= 0; i--)
                {
                    if (int.TryParse(objItems[i], out numberValue))
                    {
                        if (i == objItems.Count)
                        {
                            productQualityItem.SellInValue = numberValue;
                        }else if(i== objItems.Count - 1)
                        {
                            productQualityItem.QualityValue = numberValue;
                        }
                    }
                    else
                    {
                        productQualityItem.ProductName = objItems[i] + " ";
                    } 
                }
            }
            return productQuality;
        }
    }
}
