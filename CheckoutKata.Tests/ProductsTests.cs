using CheckoutKata.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CheckoutKata.Models;

namespace CheckoutKata.Tests
{
    public class ProductsTests
    {
        private Mock<ISpecialPrice> _mockSpecialPrice;

        [SetUp]
        public void Setup()
        {
            _mockSpecialPrice = new Mock<ISpecialPrice>();
            
        }
        [Test]
        public void WhenNameOfProductIsEmptyOrNull()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;


            var _mockProduct = new Product(1, "", 5, _mockSpecialPrice.Object);

            Assert.IsInstanceOf(typeof(Product), _mockProduct);
        }
        [Test]
        public void WhenIdOfProductIsLessThanOne()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;


            var _mockProduct = new Product(0, "A", 5, _mockSpecialPrice.Object);

            Assert.IsInstanceOf(typeof(Product), _mockProduct);
        }

        [Test]
        public void WhenPriceOfProductIsLessThanOne()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;


            var _mockProduct = new Product(1, "A", 0, _mockSpecialPrice.Object);

            Assert.IsInstanceOf(typeof(Product), _mockProduct);
        }


    }
}
