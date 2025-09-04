using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;

namespace VendingMachine.Core.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public SugarAmount SugarAmount { get; set; }
        public decimal TotalAmount => Product.Price * Quantity;

        public Order(Product product, int quantity, SugarAmount sugarAmount = SugarAmount.None)
        {
            Product = product;
            Quantity = quantity;
            SugarAmount = sugarAmount;
        }
    }
}
