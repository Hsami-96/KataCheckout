using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Interfaces
{
    public interface ICheckout
    {
        void ScanItem(IProduct product);

        int GetTotalPrice();
        IList<IProduct> CheckItemsEligibleForDiscount();
    }
}
