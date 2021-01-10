using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CheckoutKata.Models
{
    public class Product : IProduct
    {
        [Required]
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public int ProdPrice { get; set; }
        public ISpecialPrice? SpecialPrice { get; set; }

        public Product(int prodID, string prodName, int prodPrice, ISpecialPrice? specialPrice)
        {
            if (prodID <= 0)
                throw new ArgumentException("product ID cannot be 0 or less", nameof(prodID));

            if (prodPrice <= 0)
                throw new ArgumentException("product price must be greater than zero", nameof(prodPrice));

            if (prodName == null || prodName == "")
                throw new ArgumentException("product name cannot be empty or null", nameof(prodName));

            ProdID = prodID;
            ProdName = prodName;
            ProdPrice = prodPrice;
            SpecialPrice = specialPrice;

        }
    }
}
