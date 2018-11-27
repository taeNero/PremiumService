using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace premiumTravel
{
    public class TripStateAddTravelers: TripState
    {
        public TripStateAddTravelers(TripContext context) :
            base(context, TripState.Status.AddTravelers)
        {

        }

        private bool ContinueEnteringTravelers(string newTraveler)
        {
            var done = newTraveler.ToLower() == "done";
            if (done && TripContext.Trip.pTravelers.Any())
            {
                Console.WriteLine();
                Console.WriteLine("*** Traveler Finished: " +
                           $"{TripContext.Trip.pTravelers.Count} entered ***");
            }

            return !done;
        }

        private bool IsTravelerListValid()
        {
            if (TripContext.Trip.pTravelers.Any()) return true;
            Console.WriteLine("Error: At least ONE traveler is required");
            return false;
        }

        private bool IsTravelerValid(string newTraveler)
        {
            if (string.IsNullOrWhiteSpace(newTraveler))
            {
                Console.WriteLine("Error: Blank travelers are prohibited!");
                return false;
            }

            var isDuplicate = TripContext.Trip.pTravelers.Contains(newTraveler);
            if (isDuplicate) Console.WriteLine("Error: Unique travelers only!");
            return !isDuplicate;
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** Add Travelers ***");
            Console.WriteLine("Travelers List:");

            for (int opt = 0; opt < Travelers.getPeople().Count; opt++)
            {
                Console.WriteLine(Travelers.getPeople()[opt]);
            }
            Console.WriteLine();
            Console.WriteLine("Who All Is Trveling?  [enter 'done' when finished enter 'later' if you need to come back]");
            //  string actAgent = Console.ReadLine();

            var getTravelers = true;
            while (getTravelers)
            {
                var newTraveler = (Console.ReadLine() ?? "").Trim();

                if (ReturnLater(newTraveler)) return TripStateLoop.Status.Stop;

                if (ContinueEnteringTravelers(newTraveler))
                {
                    if (IsTravelerValid(newTraveler))
                    {
                        TripContext.Trip.pTravelers.Add(newTraveler);
                        Console.WriteLine($"- Added Traveler to trip [{newTraveler}]");
                    }
                }
                else
                {
                    getTravelers = !IsTravelerListValid();
                }
            }


            TripContext.ChangeState(new TripStateAddPackage(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
