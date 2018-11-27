using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class ItineraryAppendBookingDetails : ItineraryDecorator
    {
        public ItineraryAppendBookingDetails(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += $"Order # : {Trip.OrderId}" + Environment.NewLine;
            toOutput += $"Booked  : {Trip.BookedOn}" + Environment.NewLine;
            toOutput += $"Payment : {Trip.Payment}" + Environment.NewLine;
            return toOutput;
        }
    }
}
