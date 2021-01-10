using CheckoutKata.Controllers;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        private Checkout _checkout;
        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void WhenNullItemIsPassedToScan()
        {
            _checkout.ScanItem(null);
        }

        [Test]
        public void WhenTotalPriceIsCalledToReturnThePrice()
        {
            var result = _checkout.GetTotalPrice();
            Assert.IsInstanceOf(typeof(int),result);
        }
    }
}