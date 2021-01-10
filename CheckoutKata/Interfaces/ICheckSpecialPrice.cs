using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Interfaces
{
    public interface ICheckSpecialPrice
    {
        int GetTotalOfferPrice(int numberOfProductsInBasket, IProduct product);

        int GetQuantityAndApplyOffers(int numberOfProductsInBasket, int quantityOfProduct, int specialPriceOfProduct, int originalPriceOfProduct);
    }
}
