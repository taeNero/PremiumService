using System;
using System.Collections.Generic;
using System.Text;

namespace premiumTravel
{
    public class LoginAgents
    {
        public tAgent LoginAgent()
        {
            Console.WriteLine("Avalible Agents:");
            for (int opt = 0; opt < TravelAgents.getAgents().Count; opt++)
            {
                Console.WriteLine(TravelAgents.getAgents()[opt].name);
            }

            Console.WriteLine("");

            Console.WriteLine("Which Agent Are You:");
            string actAgent = Console.ReadLine();

            while (true)
            {
                int index = 0;
                if (actAgent == TravelAgents.getAgents()[index].name)
                {
                    tAgent ActiveAgen = TravelAgents.getAgents()[index];
                    return ActiveAgen;
                }
                else
                    index++;
            }
        }
    }
}
