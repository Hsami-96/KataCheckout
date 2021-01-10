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

       [SetUp]
        public void SetUp()
        {
            _checkSpecialPrice = new CheckSpecialPrice();
        }
        [Test]
        public void WhenGetQuantityAndApplyOffersReturnsNewPrice()
        {
            var result = _checkSpecialPrice.GetQuantityAndApplyOffers(5, 3, 130, 50);
            Assert.AreEqual(230, result);
        }
    }
}
