using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class ItineraryAppendThanks : ItineraryDecorator
    {
        public ItineraryAppendThanks(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "THANK YOU" + Environment.NewLine;
            toOutput += Environment.NewLine;
            toOutput += Trip.ThankYou + Environment.NewLine;
            return toOutput;
        }
    }
}
