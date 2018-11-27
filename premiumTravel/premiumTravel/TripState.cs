using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public abstract class TripState
    {
        protected TripState(TripContext context, Status tripStateStatus)
        {
            TripContext = context;

            if (TripContext.Trip != null) TripContext.Trip.TripStateStatus = tripStateStatus;
        }

        protected TripContext TripContext { get; set; }

        public abstract TripStateLoop.Status Execute();

        /// <summary>
        ///     Return later helper... used in a few places,
        ///     so moved to base class to eliminate redundant code
        /// </summary>
        /// <returns></returns>
        protected bool ReturnLater(string answer)
        {
            var returnLater = answer.ToLower() == "later";
            if (returnLater)
            {
                Console.WriteLine();
                Console.WriteLine("*** RETURN LATER TO FINISH ***");
            }

            return returnLater;
        }

       
        public enum Status
        {
            Create,
            AddTravelers,
            AddPackage,
            ChoosePersonPaying,
            ChoosePaymentType,
            PayCash,
            PayCheck,
            PayCard,
            AddThankYou,
            Complete
        }

       
    }
}
