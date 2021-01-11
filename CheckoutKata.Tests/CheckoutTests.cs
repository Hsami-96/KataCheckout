using CheckoutKata.Controllers;
using CheckoutKata.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        private Checkout _checkout;
        private Mock<IProduct> _mockProduct;
        private Mock<ISpecialPrice> _mockSpecialPrice;
        private Mock<ICheckSpecialPrice> _mockCheckSpecialPrice;


        [SetUp]
        public void Setup()
        {
            _mockCheckSpecialPrice = new Mock<ICheckSpecialPrice>();
            _mockProduct = new Mock<IProduct>();
            _mockSpecialPrice = new Mock<ISpecialPrice>();
            

            _mockProduct.SetupAllProperties();
            _mockSpecialPrice.SetupAllProperties();
            _mockCheckSpecialPrice.SetupAllProperties();

            _mockSpecialPrice.Object.SpecialPriceID = 1;
            _mockSpecialPrice.Object.SpecialPriceOffer = 130;
            _mockSpecialPrice.Object.SpecialPriceQuantity = 3;

            _mockProduct.Object.ProdID = 1;
            _mockProduct.Object.ProdName = "A";
            _mockProduct.Object.ProdPrice = 50;
            _mockProduct.Object.SpecialPrice = _mockSpecialPrice.Object;

            _mockCheckSpecialPrice.Setup(x => x.GetTotalOfferPrice(3, _mockProduct.Object)).Returns(20);
            _checkout = new Checkout(_mockCheckSpecialPrice.Object);
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
        
            _checkout.ScanItem(_mockProduct.Object);
            var result = _checkout.GetTotalPrice();
            Assert.IsInstanceOf(typeof(int),result);
        }

        [Test]
        public void WhenGetTotalPriceReturnsTheCorrectPriceForOneItem()
        {
            _checkout.ScanItem(_mockProduct.Object);
            var result = _checkout.GetTotalPrice();

            Assert.AreEqual(50, result);
        }

        [Test]
        public void WhenGetTotalPriceReturnsTheCorrectPriceForMultipleItem()
        {
            var itemTwo = new Mock<IProduct>();
            var itemThree = new Mock<IProduct>();

            itemTwo.SetupAllProperties();
            itemThree.SetupAllProperties();

            itemTwo.Object.ProdID = 2;
            itemTwo.Object.ProdName = "B";
            itemTwo.Object.ProdPrice = 30;
            itemTwo.Object.SpecialPrice = null;

            itemThree.Object.ProdID = 3;
            itemThree.Object.ProdName = "C";
            itemThree.Object.ProdPrice = 20;
            itemThree.Object.SpecialPrice = null;

            _checkout.ScanItem(_mockProduct.Object);
            _checkout.ScanItem(itemTwo.Object);
            _checkout.ScanItem(itemThree.Object);
            var result = _checkout.GetTotalPrice();

            Assert.AreEqual(100, result);
        }

        [Test]
        public void WhenEligibleItemsReturnsFalseForSpecialOfferProductsForOneItem()
        {
            _checkout.ScanItem(_mockProduct.Object);
            _checkout.GetTotalPrice();
            var itemsEligibleForDiscount = _checkout.CheckItemsEligibleForDiscount().Count();
            Assert.AreEqual(0, itemsEligibleForDiscount);

            
        }

        [Test]
        public void WhenEligibleItemsReturnsTrueForSpecialOfferProductsForMultipleItems()
        {
            _checkout.ScanItem(_mockProduct.Object);
            _checkout.ScanItem(_mockProduct.Object);
            _checkout.GetTotalPrice();

            var itemsEligibleForDiscount = _checkout.CheckItemsEligibleForDiscount().Count();

            Assert.AreEqual(1, itemsEligibleForDiscount);


        }

        [Test]
        public void WhenGetTotalPriceReturnsPriceWithDeductions()
        {

            _checkout.ScanItem(_mockProduct.Object);
            _checkout.ScanItem(_mockProduct.Object);
            _checkout.ScanItem(_mockProduct.Object);

           
            var result = _checkout.GetTotalPrice();

            Assert.AreEqual(130, result);

        }
    }
}