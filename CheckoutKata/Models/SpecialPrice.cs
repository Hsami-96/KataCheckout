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
    }
}
