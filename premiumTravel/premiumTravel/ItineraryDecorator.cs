using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public abstract class ItineraryDecorator : IItineraryComponent
    {
        private readonly IItineraryComponent _componentToDecorate;

        protected ItineraryDecorator(IItineraryComponent componentToDecorate)
        {
            _componentToDecorate = componentToDecorate;
        }

        public Trip Trip => _componentToDecorate.Trip;

        public virtual string Output()
        {
            return _componentToDecorate.Output();
        }
    }
}
