using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripContextStateFactory
    {
        public static TripState Get(TripContext context)
        {
            Debug.Assert(context != null);
            Debug.Assert(context.Trip != null);

            var tripStateStatus = context.Trip.TripStateStatus;

            switch (tripStateStatus)
            {
                case TripState.Status.Create:
                    return new TripStateCreate(context);

                case TripState.Status.AddTravelers:
                    return new TripStateAddTravelers(context);

                case TripState.Status.AddPackage:
                    return new TripStateAddPackage(context);

                case TripState.Status.ChoosePersonPaying:
                    return new TripStateChoosePersonPaying(context);

                case TripState.Status.ChoosePaymentType:
                    return new TripStateChoosePaymentType(context);

                case TripState.Status.AddThankYou:
                    return new TripStateAddThankYou(context);

                case TripState.Status.Complete:
                    return new TripStateComplete(context);

                default:
                    throw new NotSupportedException($"{tripStateStatus} is an invalid state");
            }
        }
    }
}
