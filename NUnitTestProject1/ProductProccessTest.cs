using IcelandService.Models;
using IcelandService.Services;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestProject1
{
    public class ProductProccessTest
    {
        private IFileService _fileServiceTest;
        private  IProductProccessService _productProccessTest;
        private  IList<ProductQuality> _productQualityItems;
        private  IList<ProductQuality> _productQualityItemsExcpected;

        //public ProductProccessTest(IProductProccessService productProccessService, IFileService fileServiceTest)
        // {
        // _productProccessTest = productProccessService;
        // _fileServiceTest = fileServiceTest;
        //}

        [SetUp]
        public void Setup()
        {
            _fileServiceTest = new TextFileService();
            _productProccessTest = new ProductProccessService(_fileServiceTest);
            _productQualityItems = new List<ProductQuality>()
            {
                new ProductQuality
                {
                     ProductName="Aged Brie",
                      QualityValue=1,
                       SellInValue=1
                },

                 new ProductQuality
                {
                     ProductName="Christmas Crackers",
                      QualityValue=2,
                       SellInValue=-1
                },
                  new ProductQuality
                {
                     ProductName="Christmas Crackers",
                      QualityValue=2,
                       SellInValue=9
                },
                   new ProductQuality
                {
                     ProductName="Soap",
                      QualityValue=2,
                       SellInValue=2
                },
                    new ProductQuality
                {
                     ProductName="Frozen Item",
                      QualityValue=55,
                       SellInValue=-1
                },
                     new ProductQuality
                {
                     ProductName="Frozen Item",
                      QualityValue=2,
                       SellInValue=2
                },
                      new ProductQuality
                {
                     ProductName="INVALID ITEM",
                      QualityValue=2,
                       SellInValue=2
                },
                       new ProductQuality
                {
                     ProductName="Fresh Item",
                      QualityValue=2,
                       SellInValue=2
                },
                        new ProductQuality
                {
                     ProductName="Fresh Item",
                      QualityValue=5,
                       SellInValue=-1
                },
            };


            _productQualityItemsExcpected= new List<ProductQuality>()
            {
                new ProductQuality
                {
                     ProductName="Aged Brie",
                      QualityValue=2,
                       SellInValue=0
                },

                 new ProductQuality
                {
                     ProductName="Christmas Crackers",
                      QualityValue=0,
                       SellInValue=-2
                },
                  new ProductQuality
                {
                     ProductName="Christmas Crackers",
                      QualityValue=4,
                       SellInValue=8
                },
                   new ProductQuality
                {
                     ProductName="Soap",
                      QualityValue=2,
                       SellInValue=2
                },
                    new ProductQuality
                {
                     ProductName="Frozen Item",
                      QualityValue=50,
                       SellInValue=-2
                },
                     new ProductQuality
                {
                     ProductName="Frozen Item",
                      QualityValue=1,
                       SellInValue=1
                },
                      new ProductQuality
                {
                     ProductName="NO SUCH ITEM",
                      QualityValue=0,
                       SellInValue=0
                },
                       new ProductQuality
                {
                     ProductName="Fresh Item",
                      QualityValue=0,
                       SellInValue=1
                },
                        new ProductQuality
                {
                     ProductName="Fresh Item",
                      QualityValue=1,
                       SellInValue=-2
                },
            };
        }

        [Test]
        [TestCase("C:\test.txt")]
        [Ignore("Not Needed")]
        public void GetProductsFromFileTest(string path)
        {
            var products = _productProccessTest.GetProducts(path);
            Assert.AreEqual(products, _productQualityItems);
        }

        [Test]
        
        public void ProcessProducts()
        {
            foreach( var product in _productQualityItems)
            {
                _productProccessTest.proccessProductQualityDecrease(product);
            }

            Assert.AreEqual(_productQualityItemsExcpected, _productQualityItems);
        }
    }
}