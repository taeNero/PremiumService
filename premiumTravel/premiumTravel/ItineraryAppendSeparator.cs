using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class ItineraryAppendSeparator : ItineraryDecorator
    {
        public ItineraryAppendSeparator(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += Environment.NewLine;
            toOutput += "-------------------------------------------------------" + Environment.NewLine;
            toOutput += Environment.NewLine;
            return toOutput;
        }
    }
}
