using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata.Interfaces
{
    public interface IProduct
    {
        int ProdID { get; set; }
        string ProdName { get; set; }
        int ProdPrice { get; set; }
        ISpecialPrice? SpecialPrice { get; set; }
    }
}
