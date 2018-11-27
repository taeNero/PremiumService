using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    sealed class Travelers
    {
        private static readonly object SyncLock = new object();
        private static volatile Travelers _travelers;

        private Travelers()
        {   //private constructor 
            pTravelers = new List<string>
            {
                "Po Pickles", "Barack Obama", "Beyonce", "Lil Wayne", "Donald Trump", "That Other RichGuy", "Money Guy"
            };
        }

        private IReadOnlyList<string> pTravelers { get; set; }

        public static IReadOnlyList<string> getPeople()
        {
            //double checking lazy load singleton 
            if (_travelers == null)
            {
                lock (SyncLock)
                {
                    if (_travelers == null) { _travelers = new Travelers(); }
                }
            }
            return _travelers.pTravelers;
        }
    }
}
