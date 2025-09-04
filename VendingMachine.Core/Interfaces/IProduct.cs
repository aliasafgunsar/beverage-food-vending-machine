using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;

namespace VendingMachine.Core.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }
        ProductType Type { get; set; }
        bool IsHotDrink { get; set; }
    }
}
