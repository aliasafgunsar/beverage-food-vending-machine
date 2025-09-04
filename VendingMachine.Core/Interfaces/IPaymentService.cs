using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;

namespace VendingMachine.Core.Interfaces
{
    public interface IPaymentService
    {
        PaymentResult ProcessPayment(decimal amount, PaymentMethod method);
        decimal CalculateChange(decimal paidAmount, decimal totalAmount);
    }

    public class PaymentResult
    {
        public bool Success { get; set; }
        public decimal ChangeAmount { get; set; }
        public string Message { get; set; }
    }
}
