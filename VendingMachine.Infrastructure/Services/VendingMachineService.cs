using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Interfaces;
using VendingMachine.Core.Models;

namespace VendingMachine.Infrastructure.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPaymentService _paymentService;

        public VendingMachineService(IProductRepository productRepository, IPaymentService paymentService)
        {
            _productRepository = productRepository;
            _paymentService = paymentService;
        }

        public List<Product> GetAvailableProducts() => _productRepository.GetAllProducts();
        public List<Product> GetFoodProducts() => _productRepository.GetFoodProducts();
        public List<Product> GetBeverageProducts() => _productRepository.GetBeverageProducts();

        public bool CheckProductAvailability(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            return product != null && product.Stock >= quantity;
        }

        public Order CreateOrder(int productId, int quantity, SugarAmount sugarAmount = SugarAmount.None)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
                throw new ArgumentException("Product not found");

            if (product.Stock < quantity)
                throw new InvalidOperationException("Insufficient stock");

            // Case requirement: Sugar amount only for hot drinks
            if (sugarAmount != SugarAmount.None && !product.IsHotDrink)
                throw new InvalidOperationException("Sugar option only available for hot drinks");

            return new Order(product, quantity, sugarAmount);
        }

        public Receipt ProcessPayment(Order order, PaymentMethod paymentMethod, decimal amountPaid)
        {
            // Process payment
            var paymentResult = _paymentService.ProcessPayment(order.TotalAmount, paymentMethod);

            if (!paymentResult.Success)
                throw new InvalidOperationException($"Payment failed: {paymentResult.Message}");

            // Calculate change
            decimal change = _paymentService.CalculateChange(amountPaid, order.TotalAmount);

            // Update stock
            _productRepository.UpdateProductStock(order.Product.Id, order.Quantity);

            // Create receipt - Case requirement: product name, number, payment method, refund amount
            return new Receipt
            {
                ProductName = order.Product.Name,
                ProductNumber = order.Product.Id,
                Quantity = order.Quantity,
                PaymentMethod = paymentMethod,
                AmountPaid = amountPaid,
                ChangeAmount = change,
                TransactionDate = DateTime.Now
            };
        }

        public string PrepareProduct(Order order)
        {
            if (order.Product.Type == ProductType.Beverage && order.Product.IsHotDrink)
            {
                return $"Hazırlanıyor: {order.Quantity} x {order.Product.Name} " +
                       $"{GetSugarDescription(order.SugarAmount)}";
            }

            return $"Hazırlanıyor: {order.Quantity} x {order.Product.Name}";
        }

        private string GetSugarDescription(SugarAmount sugarAmount)
        {
            return sugarAmount switch
            {
                SugarAmount.None => "(Şekersiz)",
                SugarAmount.Low => "(Az Şekerli)",
                SugarAmount.Medium => "(Orta Şekerli)",
                SugarAmount.High => "(Çok Şekerli)",
                _ => ""
            };
        }

    }
}
