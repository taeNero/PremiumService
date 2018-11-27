using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStatePayCard : TripState
    {
        public TripStatePayCard(TripContext context) :
            base(context, TripState.Status.PayCard)
        {

        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CARD PAYMENT ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later or amount");
            Console.WriteLine();


            decimal totalPrice = 0;
            for (var packs = 0; packs < TripContext.Trip.Packs.Count; packs++)
                totalPrice = TripContext.Trip.Packs[packs].Price;
            
            TripContext.Trip.Payment = new PaymentCharge(totalPrice, 0978);
            Console.WriteLine($"Paid {totalPrice} by card");

            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
