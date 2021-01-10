using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Controllers
{
    public class Checkout : ICheckout
    {
        private readonly IList<string> _products = new List<string>();

        public int GetTotalPrice()
        {
            if (_products.Count <= 0)
                throw new ArgumentException("No Items in basket");

            return 0;
        }

        public void ScanItem(string item)
        {
            if (item == null)
                throw new ArgumentException("Item not valid", nameof(item));

            _products.Add(item);
        }
    }
}
