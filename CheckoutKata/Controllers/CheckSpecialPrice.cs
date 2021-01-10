using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Controllers
{
    public class CheckSpecialPrice : ICheckSpecialPrice
    {
        private int _totalPriceOfProducts;

        /// <summary>
        /// Total offer price which will be deducted from original price
        /// </summary>        
        /// <param name="numberOfProductsInBasket">number Of The item in basket</param>
        /// <param name="product">The item</param>
        public int GetTotalOfferPrice(int numberOfProductsInBasket, IProduct product)
        {
            if (numberOfProductsInBasket == 0 || product == null)
                throw new ArgumentException("No items in the basket", nameof(numberOfProductsInBasket));

            if (product.SpecialPrice == null)
                throw new ArgumentException("No Special price available on item", nameof(product.SpecialPrice));

            return 0;
        }

        /// <summary>
        /// works out the quantity of offers to be used and also deduct the reamining items which are not part of the offer i.e if quantity is
        /// 5 and offer is 3 for A, then reamning 2 will be appended with normal price
        /// </summary>        
        /// <param name="numberOfProductsInBasket">number Of The item in basket</param>
        /// <param name="specialPriceQuantity">special price quantity</param>
        /// <param name="specialPriceOffer">special price offer price</param>
        /// <param name="originalPriceOfProduct">orginal price</param>
        public int GetQuantityAndApplyOffers(int numberOfProductsInBasket, int specialPriceQuantity, int specialPriceOffer, int originalPriceOfProduct)
        {
            throw new NotImplementedException();
        }

       
    }
}
