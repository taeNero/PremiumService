using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class Trip
    {
        public Trip()
        {
            TripStateStatus = TripState.Status.Create;
            Packs = new List<objPack>();
            pTravelers = new List<string>();
          

        }

        /// <summary>
        ///     Holds status of Trip instance.
        ///     Do not arbitrarily change.
        ///     Must be managed by TripState machine.
        /// </summary>
        public TripState.Status TripStateStatus { get; set; }

        public long OrderId { get; set; }
        public DateTime BookedOn { get; set; }
        public List<objPack> Packs { get; set; }
        public List<string> pTravelers { get; set; }
        public string benifactor { get; set; }
        public decimal totalPrice { get; set; } 
        public string ThankYou { get; set; }
        public Payment Payment { get; set; }
    }
}
