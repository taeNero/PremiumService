using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public abstract class Payment
    {
        protected Payment(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; }

        public virtual string Describe()
        {
            return $"Collected ${Amount}";
        }

        public override string ToString()
        {
            return Describe();
        }
    }
}
