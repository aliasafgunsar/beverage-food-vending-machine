using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Interfaces;
using VendingMachine.Core.Models;
using VendingMachine.Infrastructure.Services;

namespace VendingMachine.Tests.Services
{
    public class VendingMachineServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly VendingMachineService _vendingMachineService;

        public VendingMachineServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _vendingMachineService = new VendingMachineService(
                _productRepositoryMock.Object,
                _paymentServiceMock.Object
            );
        }

        [Fact]
        public void CreateOrder_WithValidProductAndQuantity_ReturnsOrder()
        {
            // Arrange
            var product = new Product(1, "Test Food", 10.0m, 100, ProductType.Food);
            _productRepositoryMock.Setup(repo => repo.GetProductById(1)).Returns(product);

            // Act
            var order = _vendingMachineService.CreateOrder(1, 2);

            // Assert
            Assert.NotNull(order);
            Assert.Equal(2, order.Quantity);
            Assert.Equal(20.0m, order.TotalAmount);
            Assert.Equal("Test Food", order.Product.Name);
        }

        [Fact]
        public void CreateOrder_WithInsufficientStock_ThrowsException()
        {
            // Arrange
            var product = new Product(1, "Test Food", 10.0m, 1, ProductType.Food);
            _productRepositoryMock.Setup(repo => repo.GetProductById(1)).Returns(product);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _vendingMachineService.CreateOrder(1, 2));
        }

        [Fact]
        public void CreateOrder_WithSugarForNonHotDrink_ThrowsException()
        {
            // Arrange
            var product = new Product(1, "Cold Drink", 5.0m, 10, ProductType.Beverage, false);
            _productRepositoryMock.Setup(repo => repo.GetProductById(1)).Returns(product);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _vendingMachineService.CreateOrder(1, 1, SugarAmount.Medium));
        }

        [Fact]
        public void ProcessPayment_WithValidPayment_ReturnsReceipt()
        {
            // Arrange
            var product = new Product(1, "Test Food", 10.0m, 100, ProductType.Food);
            var order = new Order(product, 2);

            _paymentServiceMock.Setup(p => p.ProcessPayment(20.0m, PaymentMethod.CashCoin))
                .Returns(new Core.Interfaces.PaymentResult
                {
                    Success = true,
                    Message = "Success"
                });

            _productRepositoryMock.Setup(repo => repo.GetProductById(1)).Returns(product);

            // Act
            var receipt = _vendingMachineService.ProcessPayment(order, PaymentMethod.CashCoin, 25.0m);

            // Assert
            Assert.NotNull(receipt);
            Assert.Equal("Test Food", receipt.ProductName);
            Assert.Equal(1, receipt.ProductNumber);
            Assert.Equal(2, receipt.Quantity);
            Assert.Equal(PaymentMethod.CashCoin, receipt.PaymentMethod);
            Assert.Equal(25.0m, receipt.AmountPaid);
        }
    }
}
