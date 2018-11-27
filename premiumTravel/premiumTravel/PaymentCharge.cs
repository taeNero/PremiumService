using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class PaymentCharge : Payment
    {
        public PaymentCharge(decimal amount, int cardNumber) : base(amount)
        {
            CardNumber = cardNumber;
        }

        public int CardNumber { get; }

        public override string Describe()
        {
            return base.Describe() + $", card number Endind in {CardNumber}";
        }
    }
}
