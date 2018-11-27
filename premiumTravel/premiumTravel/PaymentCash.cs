using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class PaymentCash : Payment
    {
        public PaymentCash(decimal amount) : base(amount)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()} cash";
        }
    }
}
