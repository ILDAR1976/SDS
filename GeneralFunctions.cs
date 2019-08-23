using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS
{
    class GeneralFunctions
    {
        public static Random rand = new Random();

        public static int getRandomIndex(int min, int max, int current)
        {
            int o = 0;

            if (max == 1)
            {
                if (current == 0) return 1; else return 0;
            }

            do
            {
                o = rand.Next(min,max);
            } while (o == current);

            return o;
        }

        public static void printAgentInfo(Agent a)
        {
            Console.WriteLine("Satus: {0}", a.active);

            Console.WriteLine("Position: ");

            int c = 1;

            foreach (var p in a.location.point)
            {
                Console.Write(" a{0} = {1}",c++,p);
            }
            Console.WriteLine();
        
            Console.WriteLine("The function value: {0}", a.fitness(a.location));

            Console.WriteLine();
        }
    }
}
