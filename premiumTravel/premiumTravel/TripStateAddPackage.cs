using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace premiumTravel
{
    public class TripStateAddPackage : TripState
    {

        public TripStateAddPackage(TripContext context) :
            base(context, TripState.Status.AddPackage)
        {

        }


        public override TripStateLoop.Status Execute()
        {
            /*
            Destinations openDestinations = new Destinations();
            openDestinations.ShowDialog();                       
            */

            for (int opt = 0; opt < Packages.getPackList().Count; opt++)
            {
                
                Console.WriteLine(Packages.getPackList()[opt].TravelsTo);
                Console.WriteLine(Packages.getPackList()[opt].TravelsFrom);
                Console.WriteLine("Pack Id " + Packages.getPackList()[opt].packIndex);                
                Console.WriteLine("--------------------------------------");

            }
            Console.WriteLine(
                "- Select Package enter Pack Id");
            int index =Convert.ToInt32(Console.ReadLine());
            objPack newPack = Packages.getPackList()[index];
            TripContext.Trip.Packs.Add(newPack);

            TripContext.ChangeState(new TripStateChoosePersonPaying(TripContext));
            return TripStateLoop.Status.Continue;








            
            
                
        }







        }
    }
