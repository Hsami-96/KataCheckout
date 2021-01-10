using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Interfaces
{
    public interface ISpecialPrice
    {
        int SpecialPriceID { get; set; }
        int SpecialPriceQuantity { get; set; }
        int SpecialPriceOffer { get; set; }
    }
}
