﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStateLoop
    {
        /// <summary>
        ///     Used when creating a NEW trip.
        ///     Returns trip instance. Note returned trip instance may not be complete.
        /// </summary>
        /// <returns></returns>
        public Trip Execute()
        {
            return Execute(null);
        }

        /// <summary>
        ///     Execute(trip) if you have an existing Trip instance
        ///     to re-insert and continue looping in the state machine.
        /// </summary>
        /// <returns></returns>
        public Trip Execute(Trip trip)
        {
            var tripContext = trip == null
                ? new TripContext()
                : new TripContext(trip);

            while (tripContext.Execute() == Status.Continue)
            {
                //keep looping while the states are saying continue
            }

            Debug.WriteLine(
                Environment.NewLine +
                "*** TripStateLoop.Status.Stopped ***" +
                Environment.NewLine);

            return tripContext.Trip;
        }

        public enum Status
        {
            Continue,
            Stop
        }
    }
}
