using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class calcPrice
    {
        public calcPrice(List<decimal> price)
        {
            for (int opt = 0; opt < Packages.price.Count; opt++)
            {
                decimal total = Packages.price[opt] + Packages.price[opt+1];
            }

        }
    }
}
