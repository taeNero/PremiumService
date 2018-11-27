using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStateCreate : TripState
    {
        public TripStateCreate(TripContext context) :
            base(context, TripState.Status.Create)
        {
            TripContext.Trip = new Trip
            {
                BookedOn = DateTime.Now,
                OrderId = DateTime.Now.Ticks,
                TripStateStatus = TripState.Status.Create
            };
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine();
            Console.WriteLine("*** NEW TRIP CREATED ***");
            TripContext.ChangeState(new TripStateAddTravelers(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
