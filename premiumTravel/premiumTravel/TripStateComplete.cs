using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStateComplete : TripState
    {
        public TripStateComplete(TripContext context) :
            base(context, TripState.Status.Complete)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "***COMPLETE - ITINERARY AVAILABLE ***");
            Console.WriteLine();

            //this is the end, so stop looping
            return TripStateLoop.Status.Stop;
        }
    }
}
