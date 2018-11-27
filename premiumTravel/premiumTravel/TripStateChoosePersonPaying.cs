using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    class TripStateChoosePersonPaying : TripState
    {
        public TripStateChoosePersonPaying(TripContext context) :
            base(context, TripState.Status.ChoosePersonPaying)
        {

        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** Who Making The Payment***");
            for (int opt = 0; opt < Travelers.getPeople().Count; opt++)
            {
                Console.WriteLine(Travelers.getPeople()[opt]);
            }

            Console.WriteLine("Who's covering the bill? enter 'later' if you want to come back" );
            string det = Console.ReadLine();

            if(det == "later")
            {
                return TripStateLoop.Status.Stop;
            }
            else
            {
                TripContext.Trip.benifactor = det;
                Console.WriteLine($"- Added benifactor [{det}]");
            }

            TripContext.ChangeState(new TripStateChoosePaymentType(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
