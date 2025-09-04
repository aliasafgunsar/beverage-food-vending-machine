using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Models;

namespace VendingMachine.Core.Interfaces
{
    public interface IVendingMachineService
    {
        List<Product> GetAvailableProducts();
        List<Product> GetFoodProducts();
        List<Product> GetBeverageProducts();
        Order CreateOrder(int productId, int quantity, SugarAmount sugarAmount = SugarAmount.None);
        Receipt ProcessPayment(Order order, PaymentMethod paymentMethod, decimal amountPaid);
        bool CheckProductAvailability(int productId, int quantity);
        string PrepareProduct(Order order);
    }
}
