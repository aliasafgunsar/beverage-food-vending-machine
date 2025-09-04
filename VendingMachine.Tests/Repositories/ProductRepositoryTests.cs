using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Infrastructure.Repositories;

namespace VendingMachine.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetAllProducts_Returns30Products()
        {
            // Arrange
            var repository = new ProductRepository();

            // Act
            var products = repository.GetAllProducts();

            // Assert
            Assert.Equal(30, products.Count);
        }

        [Fact]
        public void GetFoodProducts_Returns20FoodProducts()
        {
            // Arrange
            var repository = new ProductRepository();

            // Act
            var foodProducts = repository.GetFoodProducts();

            // Assert
            Assert.Equal(20, foodProducts.Count);
            Assert.All(foodProducts, p => Assert.Equal(ProductType.Food, p.Type));
        }

        [Fact]
        public void GetBeverageProducts_Returns10BeverageProducts()
        {
            // Arrange
            var repository = new ProductRepository();

            // Act
            var beverageProducts = repository.GetBeverageProducts();

            // Assert
            Assert.Equal(10, beverageProducts.Count);
            Assert.All(beverageProducts, p => Assert.Equal(ProductType.Beverage, p.Type));
        }

        [Fact]
        public void UpdateProductStock_DecreasesStockCorrectly()
        {
            // Arrange
            var repository = new ProductRepository();
            var initialStock = repository.GetProductById(1).Stock;

            // Act
            repository.UpdateProductStock(1, 5);
            var updatedProduct = repository.GetProductById(1);

            // Assert
            Assert.Equal(initialStock - 5, updatedProduct.Stock);
        }
    }
}
