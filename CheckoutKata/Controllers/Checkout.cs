using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Controllers
{
    public class Checkout : ICheckout
    {
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void ScanItem(string item)
        {
            if (item == null)
                throw new ArgumentException("Item not valid", nameof(item));
        }
    }
}
