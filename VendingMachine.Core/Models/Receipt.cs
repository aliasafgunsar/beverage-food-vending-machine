using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Enums;
using VendingMachine.Core.Extensions; 

namespace VendingMachine.Core.Models
{
    public class Receipt
    {
        public string ProductName { get; set; }
        public int ProductNumber { get; set; }
        public int Quantity { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount { get; set; }
        public DateTime TransactionDate { get; set; }

        public override string ToString()
        {
            return $"Ürün: {ProductName} | No: {ProductNumber} | Adet: {Quantity} | \n"  +
                   $"Ödeme: {PaymentMethod.GetDescription()} | Tutar: {AmountPaid:C} | Para Üstü: {ChangeAmount:C} |\n" + // GETDESCRIPTION() EKLENDİ
                   $"Tarih: {TransactionDate}";
        }
    }
}