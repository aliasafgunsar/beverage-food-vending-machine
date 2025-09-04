using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VendingMachine.Core.Enums
{
    public enum PaymentMethod
    {
        [Description("Temaslı Kredi Kartı")]
        CreditCardContactless,

        [Description("Temassız Kredi Kart")]
        CreditCardContact,

        [Description("Nakit Kağıt Para")]
        CashPaper,

        [Description("Nakit Madeni Para")]
        CashCoin
    }
}