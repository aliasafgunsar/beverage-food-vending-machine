using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Models;

namespace VendingMachine.Core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        List<Product> GetFoodProducts();
        List<Product> GetBeverageProducts();
        void UpdateProductStock(int productId, int quantity);
    }
}
