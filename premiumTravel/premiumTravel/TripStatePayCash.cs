using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStatePayCash : TripState
    {
        public TripStatePayCash(TripContext context) :
           base(context, TripState.Status.PayCash)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CASH PAYMENT ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later or amount");
            Console.WriteLine();

            //fake
            decimal totalPrice= 0;
            for (var packs = 0; packs < TripContext.Trip.Packs.Count; packs++)
                  totalPrice = TripContext.Trip.Packs[packs].Price;

            TripContext.Trip.Payment = new PaymentCash(totalPrice);
            Console.WriteLine($"Paid {totalPrice} cash");

            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
