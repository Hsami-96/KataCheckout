using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Controllers
{
    public class Checkout : ICheckout
    {
        private readonly IList<IProduct> _products = new List<IProduct>();

        /// <summary>
        /// Scan item and add it to the shopping list
        /// </summary>
        /// <param name="product">The item to add to the list</param>
        public void ScanItem(IProduct product)
        {
            if (product == null)
                throw new ArgumentException("Item not valid", nameof(product));

            _products.Add(product);
        }
        public int GetTotalPrice()
        {
            if (_products.Count <= 0)
                throw new ArgumentException("No Items in basket");

            return 0;
        }

     
    }
}
