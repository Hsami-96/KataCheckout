using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CheckoutKata.Models
{
    public class SpecialPrice : ISpecialPrice
    {
        [Required]
        public int SpecialPriceID { get; set; }
        public int SpecialPriceQuantity { get; set; }
        public int SpecialPriceOffer { get; set; }

        public SpecialPrice(int specialPriceID, int specialPriceQuantity, int specialPriceOffer)
        {
            if (specialPriceID <= 0)
                throw new ArgumentException("specialPrice ID cannot be 0 or less", nameof(specialPriceID));

            if (specialPriceQuantity <= 0)
                throw new ArgumentException("specialPrice quantity must be greater than zero", nameof(specialPriceQuantity));

            if (specialPriceOffer <= 0)
                throw new ArgumentException("specialPrice Offer must be greater than zero", nameof(specialPriceOffer));

            SpecialPriceID = specialPriceID;
            SpecialPriceQuantity = specialPriceQuantity;
            SpecialPriceOffer = specialPriceOffer;
        }
        
    }
}
