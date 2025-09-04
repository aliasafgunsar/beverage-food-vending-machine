using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Interfaces;
using VendingMachine.Core.Models;

namespace VendingMachine.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();

            // 20 food products - Yiyecekler
            for (int i = 1; i <= 20; i++)
            {
                _products.Add(new Product(i, $"Yiyecek {i}", 10.00m + i, 100, ProductType.Food));
            }

            // 10 beverage products - İçecekler
            for (int i = 21; i <= 30; i++)
            {
                // İstediğiniz içecekleri sıcak yapabilirsiniz
                bool isHotDrink = IsHotDrink(i - 20); // İçecek numarasına göre
                _products.Add(new Product(i, $"İçecek {i - 20}", 5.00m + (i - 20), 50, ProductType.Beverage, isHotDrink));
            }
        }

        // Hangi içeceklerin sıcak olacağını burada kontrol ediyoruz
        private bool IsHotDrink(int beverageNumber)
        {
      
            //  Belirli numaralı içecekler sıcak olsun
            int[] hotDrinkNumbers = { 2, 4, 6, 8, 10 }; // 5 içecek şekerli
            return hotDrinkNumbers.Contains(beverageNumber);

        }

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public List<Product> GetAllProducts() => _products;

        public List<Product> GetFoodProducts() =>
            _products.Where(p => p.Type == ProductType.Food).ToList();

        public List<Product> GetBeverageProducts() =>
            _products.Where(p => p.Type == ProductType.Beverage).ToList();

        public void UpdateProductStock(int productId, int quantity)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                product.Stock -= quantity;
            }
        }
    }
}