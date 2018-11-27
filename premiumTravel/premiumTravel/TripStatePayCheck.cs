using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStatePayCheck : TripState
    {
        public TripStatePayCheck(TripContext context) :
            base(context, TripState.Status.PayCheck)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CHECK PAYMENT ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later or amount");
            Console.WriteLine();

            decimal totalPrice = 0;
            for (var packs = 0; packs < TripContext.Trip.Packs.Count; packs++)
                totalPrice = TripContext.Trip.Packs[packs].Price;

            TripContext.Trip.Payment = new PaymentCheck(totalPrice, 1050);
            Console.WriteLine($"Paid {totalPrice} by check");

            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
