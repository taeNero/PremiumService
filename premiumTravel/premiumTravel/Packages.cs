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
            pack1.TravelsTo = "Fiji";
            pack1.TravelsFrom = "Casa Pickles";
            pack1.Price = 74000;
            pack1.hourTravel = 14;
            pack1.packIndex = 0;

            var pack2 = new objPack();
            pack2.TravelsTo = "LA Airport";
            pack2.TravelsFrom = "Casa Pickles";
            pack2.Price = 4000;
            pack2.hourTravel = 1;
            pack2.packIndex = 1;

            var pack3 = new objPack();
            pack3.TravelsTo = "Fiji airport";
            pack3.TravelsFrom = "LA airport";
            pack3.Price = 17000;
            pack3.hourTravel = 10;
            pack3.packIndex = 2;
        
            var pack4 = new objPack();
            pack4.TravelsTo = "Fiji Marina";
            pack4.TravelsFrom = "Fiji Airport";
            pack4.Price = 500;
            pack4.hourTravel = 14;
            pack4.packIndex = 3;

            var pack5 = new objPack();
            pack5.TravelsTo = "Paradise Pickles Private Island";
            pack5.TravelsFrom = "Fiji Matina";
            pack5.Price = 12000;
            pack5.hourTravel = 10;
            pack5.packIndex = 4;

            var pack6 = new objPack();
            pack6.TravelsTo = "Fiji Matina";
            pack6.TravelsFrom = "Paradise Pickles Private Island";
            pack6.Price = 12000;
            pack6.hourTravel = 10;
            pack6.packIndex = 5;

            var pack7 = new objPack();
            pack7.TravelsTo = "Fiji airport";
            pack7.TravelsFrom = "Fiji Matina";
            pack7.Price = 500;
            pack7.hourTravel = 1;
            pack7.packIndex = 6;

            var pack8 = new objPack();
            pack8.TravelsTo = "San Diego AirPort";
            pack8.TravelsFrom = "Fiji Airport";
            pack8.Price = 23000;
            pack8.hourTravel = 1;
            pack8.packIndex = 7;
            
            var pack9 = new objPack();
            pack9.TravelsTo = "Palace Pickles";
            pack9.TravelsFrom = "San Diego Airport";
            pack9.Price = 5000;
            pack9.hourTravel = 1;
            pack9.packIndex = 8;
            
            var pack10 = new objPack();
            pack10.TravelsTo = "england";
            pack10.TravelsFrom = "atlanta";
            pack10.Price = 1000;
            pack10.hourTravel = 26;
            pack10.packIndex = 9;

            pPackages = new List<objPack>
            {
                pack1, pack2, pack3, pack4, pack5, pack6, pack7, pack8, pack9, pack10
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
