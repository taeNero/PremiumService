using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    sealed class Packages
    {
        private static readonly object SyncLock = new object();
        private static volatile Packages _package;


        private Packages()
        {   //private constructor 

            var pack1 = new objPack();
            pack1.TravelsTo = "Atlanta";
            pack1.TravelsFrom = "Cali";
            pack1.Price = 500;
            pack1.hourTravel = 14;
            pack1.packIndex = 0;


            var pack2 = new objPack();
            pack2.TravelsTo = "england";
            pack2.TravelsFrom = "atlanta";
            pack2.Price = 1000;
            pack2.hourTravel = 26;
            pack2.packIndex = 1;

            pPackages = new List<objPack>
            {
                pack1, pack2
            };

           

        }

        private IReadOnlyList<objPack> pPackages { get; set; }

        public static IReadOnlyList<decimal> price { get; set; }

        public static IReadOnlyList<objPack> getPackList()
        {
            //double checking lazy load singleton 
            if (_package == null)
            {
                lock (SyncLock)
                {
                    if (_package == null) { _package = new Packages(); }
                }
            }
            return _package.pPackages;
        }

     
    }
}
