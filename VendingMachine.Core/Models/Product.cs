using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Interfaces;

namespace VendingMachine.Core.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ProductType Type { get; set; }
        public bool IsHotDrink { get; set; }

        public Product(int id, string name, decimal price, int stock, ProductType type, bool isHotDrink = false)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Type = type;
            IsHotDrink = isHotDrink;
        }
    }
}
