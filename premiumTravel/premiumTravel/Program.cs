using System;

namespace premiumTravel
{
    internal class Program
    {
        private static void Main(string[] args)
        {


            var agent = new LoginAgents();
            agent.LoginAgent();

            var tripStateLoop = new TripStateLoop();
            var trip = tripStateLoop.Execute();



            while (true)
            {
                ShowItinerary(trip);

                
                Console.WriteLine(
                    Environment.NewLine +
                    "Simulate trip reload to correct state? [yes]");

                if ((Console.ReadLine() ?? "").ToLower().Trim() == "yes")
                    tripStateLoop.Execute(trip);
                else
                    break;
            }
        }

        /// <summary>
        ///     Displays itinerary, if possible
        /// </summary>
        /// <param name="trip"></param>
        private static void ShowItinerary(Trip trip)
        {
            if (ItineraryFactory.TripCanProduceItinerary(trip))
            {
                Console.WriteLine("Show itinerary? [yes]");
                if ((Console.ReadLine() ?? "").Trim().ToLower() != "yes") return;

                var itinerary = ItineraryFactory.Get(trip);
                Console.WriteLine(itinerary);
                return;
            }

            Console.WriteLine($"Trip {trip.OrderId} is not complete - cannot produce itinerary yet");
            Console.WriteLine($"Trip {trip.OrderId} state = {trip.TripStateStatus}");
            Console.WriteLine();
        }
    }
}
