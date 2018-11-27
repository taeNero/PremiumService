using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class ItineraryAppendDestinations : ItineraryDecorator
    {
        public ItineraryAppendDestinations(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "Packages" + Environment.NewLine;
            toOutput += Environment.NewLine;
            for (var packs = 0; packs < Trip.Packs.Count; packs++)
                toOutput += $"{packs + 1,2}. {Trip.Packs[packs].TravelsFrom} to {Trip.Packs[packs].TravelsTo} " + Environment.NewLine;
            return toOutput;
        }
    }
}
