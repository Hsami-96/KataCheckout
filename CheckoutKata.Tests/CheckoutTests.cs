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
        private Mock<IProduct> _mockProduct;
        private Mock<ISpecialPrice> _mockSpecialPrice;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
            _mockProduct = new Mock<IProduct>();
            _mockSpecialPrice = new Mock<ISpecialPrice>();

        }

        [Test]
        public void WhenNullItemIsPassedToScan()
        {
            var ex = Assert.Throws<ArgumentException>(() => _checkout.ScanItem(null));
            Assert.That(ex.Message, Is.EqualTo("Item not valid (Parameter 'product')"));
        }

        [Test]
        public void WhenTotalPriceIsCalledToReturnThePrice()
        {
            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 45;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 2;

            _mockProduct.Object.ProdID = 1;
            _mockProduct.Object.ProdName = "A";
            _mockProduct.Object.ProdPrice = 50;
            _mockProduct.Object.SpecialPrice = _mockSpecialPrice.Object;


            _checkout.ScanItem(_mockProduct.Object);
            var result = _checkout.GetTotalPrice();
            Assert.IsInstanceOf(typeof(int),result);
        }
    }
}