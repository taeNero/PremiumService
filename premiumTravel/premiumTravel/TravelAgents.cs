using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    sealed class TravelAgents
    {
        private static volatile TravelAgents _initialInstance;
        private static readonly object _lock = new object();

        private TravelAgents()
        {
            var DamonteBowie = new tAgent();
            DamonteBowie.name = "Damonte Bowie";

            var BoobieFromTheBlock = new tAgent();
            BoobieFromTheBlock.name = "Boobie From The Block";

            var AlfredOfGotham = new tAgent();
            AlfredOfGotham.name = "Alfred";
            Agents = new List<tAgent>
            {
                DamonteBowie, BoobieFromTheBlock, AlfredOfGotham
            };
        }

        private IReadOnlyList<tAgent> Agents { get; set; }

        public static IReadOnlyList<tAgent> getAgents()
        {
            if (_initialInstance == null)
            {
                lock (_lock)
                {
                    if (_initialInstance == null)
                    {
                        _initialInstance = new TravelAgents();
                    }
                }
            }
            return _initialInstance.Agents;
        }
    }
}
