using CheckoutKata.Controllers;
using CheckoutKata.Interfaces;
using CheckoutKata.Models;
using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ISpecialPrice> specialPrices = new List<ISpecialPrice>
            {
                new SpecialPrice(2, 2, 45),
                new SpecialPrice(1, 3, 130),

            };
            IList<Product> products = new List<Product>
            {
              new Product(1, "A", 50, specialPrices[1]),
              new Product(2, "B", 30, specialPrices[0]),
              new Product(3, "C", 10, null),
              new Product(4, "D", 20, null),

            };
            ICheckSpecialPrice specialPrice = new CheckSpecialPrice();

            ICheckout checkout = new Checkout(specialPrice);
            checkout.ScanItem(products[1]);
            checkout.ScanItem(products[1]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);

            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[0]);
            checkout.ScanItem(products[1]);
            var total = checkout.GetTotalPrice();






            Console.WriteLine("TOTAL IS: " + total);
        }
    }
}
