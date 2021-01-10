using CheckoutKata.Controllers;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Tests
{
    public class SpecialPriceTests
    {
        private CheckSpecialPrice _checkSpecialPrice;
        private Mock<IProduct> _mockProduct;
        private Mock<ISpecialPrice> _mockSpecialPrice;

        [SetUp]
        public void SetUp()
        {
            _checkSpecialPrice = new CheckSpecialPrice();
            _mockProduct = new Mock<IProduct>();
            _mockSpecialPrice = new Mock<ISpecialPrice>();
            _mockProduct.SetupAllProperties();
            _mockSpecialPrice.SetupAllProperties();

            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 130;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 3;

            _mockProduct.Object.ProdID = 1;
            _mockProduct.Object.ProdName = "A";
            _mockProduct.Object.ProdPrice = 50;
            _mockProduct.Object.SpecialPrice = _mockSpecialPrice.Object;
        }
        [Test]
        public void WhenGetQuantityAndApplyOffersReturnsNewPrice()
        {
            var result = _checkSpecialPrice.GetQuantityAndApplyOffers(5, 3, 130, 50);
            Assert.AreEqual(230, result);
        }

        [Test]
        public void WhenGetTotalOfferPriceIsApplied()
        {
            var result = _checkSpecialPrice.GetTotalOfferPrice(5, _mockProduct.Object);
            Assert.AreEqual(20, result);
        }


    }
}
