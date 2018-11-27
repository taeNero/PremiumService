using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class TripStateChoosePaymentType : TripState
    {
        public TripStateChoosePaymentType(TripContext context) :
            base(context, TripState.Status.ChoosePaymentType)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** CHOOSE PAYMENT TYPE ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later, [cash], [card], [check]");

            while (true)
            {
                var paymentType = (Console.ReadLine() ?? "").Trim();
                if (ReturnLater(paymentType)) return TripStateLoop.Status.Stop; //exit loop and method

                //empty entry does nothing
                if (string.IsNullOrWhiteSpace(paymentType)) continue;

                if (paymentType == "cash")
                {
                    TripContext.ChangeState(new TripStatePayCash(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                if (paymentType == "check")
                {
                    TripContext.ChangeState(new TripStatePayCheck(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                if (paymentType == "card")
                {
                    TripContext.ChangeState(new TripStatePayCard(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                Console.WriteLine("- ERROR: [later], [cash], [card] or [check]");
            }
        }
    }
}
