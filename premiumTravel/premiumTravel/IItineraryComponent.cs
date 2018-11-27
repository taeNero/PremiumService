using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public interface IItineraryComponent
    {    
        Trip Trip { get; }
        string Output();
    }
}
