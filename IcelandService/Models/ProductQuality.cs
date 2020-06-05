using System;
using System.Collections.Generic;
using System.Text;

namespace IcelandService.Models
{
    public class ProductQuality
    {
        public int SellInValue { get; set; }
        public int QualityValue { get; set; }
        public string ProductName { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ProductQuality p = (ProductQuality)obj;
                return (SellInValue == p.SellInValue) && (QualityValue == p.QualityValue) && (ProductName==p.ProductName);
            }
        }
    }
}
