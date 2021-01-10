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

            Assert.Throws<ArgumentException>(() => new Product(1, "", 5, _mockSpecialPrice.Object));
        }
        [Test]
        public void WhenIdOfProductIsLessThanOne()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;


            Assert.Throws<ArgumentException>(() => new Product(0, "A", 5, _mockSpecialPrice.Object));
        }

        [Test]
        public void WhenPriceOfProductIsLessThanOne()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;

            Assert.Throws<ArgumentException>(() => new Product(1, "A", 0, _mockSpecialPrice.Object));

        }

        [Test]
        public void WhenAllConditionsAreMetToCreateProduct()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;

            var result = new Product(1, "A", 5, _mockSpecialPrice.Object);

            Assert.IsInstanceOf(typeof(Product), result);
        }

        [Test]
        public void WhenSpecialPriceIdIsEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() => new SpecialPrice(0, 1, 15));
        }
        [Test]
        public void WhenSpecialPriceQuantityIsZero()
        {
            Assert.Throws<ArgumentException>(() => new SpecialPrice(1, 0, 15));
        }
        [Test]
        public void WhenSpecialPriceOfferIsZero()
        {
            Assert.Throws<ArgumentException>(() => new SpecialPrice(1, 5, 0));
        }


    }
}
