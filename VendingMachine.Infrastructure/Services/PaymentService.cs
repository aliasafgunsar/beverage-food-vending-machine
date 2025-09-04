using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Interfaces;

namespace VendingMachine.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentResult ProcessPayment(decimal amount, PaymentMethod method)
        {
            // Case requirement: No real payment processing needed
            // Just simulate payment based on method
            return new PaymentResult
            {
                Success = true,
                ChangeAmount = 0,
                Message = $"Payment processed via {method}"
            };
        }

        public decimal CalculateChange(decimal paidAmount, decimal totalAmount)
        {
            return paidAmount >= totalAmount ? paidAmount - totalAmount : 0;
        }
    }
}
