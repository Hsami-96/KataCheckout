using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// get total for all items
        /// </summary>
        public int GetTotalPrice()
        {
            if (_products.Count <= 0)
                throw new ArgumentException("No Items in basket");

            var TotalForItems = _products.Sum(x => x.ProdPrice);
            var CheckForEligibleItems = CheckItemsEligibleForDiscount();
            return TotalForItems;
        }

        /// <summary>
        /// check items eligible for discount
        /// </summary>
        ///  /// <param name="products">The products in basket</param>
        public bool CheckItemsEligibleForDiscount()
        {
            if (_products == null)
                throw new ArgumentException("products not valid", nameof(_products));

            var ItemsEligibleForDiscount = _products.Where(x => x.SpecialPrice != null).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).Distinct();

            var AnyItemsEligibleForDiscount = ItemsEligibleForDiscount.Count() > 0 ? true : false;

            return AnyItemsEligibleForDiscount;
        }

    }
}
