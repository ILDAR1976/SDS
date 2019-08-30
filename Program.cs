using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = true;

            do  {
                
                //Initializition

                Console.WriteLine("Enter the quantity of dimestions:");
                AgentPoint.dimention = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter lengths of bounds:");
                AgentPoint.setBounds(Console.ReadLine().Split(','));
                Console.WriteLine("Enter the quantity of agents:");
                int quantityAgents = int.Parse(Console.ReadLine());
                List<Agent> agents = new List<Agent>();
                for (int i = 0; i < quantityAgents; i++)
                {
                    Agent a = new Agent();
                    a.location = AgentPoint.generateLocation(a.location);
                    a.fitness = f1; 
                    agents.Add(a);
                }

                int m = 0;
                bool flag = true;
                int count = 0;
           
                while (true)
                {


                    //Testing

                    int activeCount = 0;

                    for (int i = 0; i < quantityAgents; i++)
                    {
                        int index = GeneralFunctions.getRandomIndex(0, quantityAgents - 1, i);

                        if (agents[i].fitness(agents[i].location) <= agents[index].fitness(agents[index].location))
                        {
                            agents[i].active = true;
                            activeCount++;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine("\r\n \r\n BEFORE \r\n");

                        foreach (var item in agents)
                        {
                            Console.WriteLine("Agent {0}: ", ++m);
                            GeneralFunctions.printAgentInfo(item);
                            Console.WriteLine();
                        }

                        flag = false;
                    }


                    Console.Write("*", ++count);


                    if (activeCount == quantityAgents)
                    {
                        int i = 0;

                        Console.WriteLine();
                        Console.WriteLine("\r\n \r\n AFTER \r\n");

                        foreach (var item in agents)
                        {
                            Console.WriteLine("Agent {0}: ", ++i);
                            GeneralFunctions.printAgentInfo(item);
                            Console.WriteLine();
                        }

                        Console.WriteLine("Iteration {0}", count);
                        break;
                    }



                    //Deffusion
                    for (int i = 0; i < quantityAgents; i++)
                    {
                        int index = GeneralFunctions.getRandomIndex(0, quantityAgents - 1, i);

                        if (!agents[i].active)
                        {
                            if (agents[index].active)
                            {
                                agents[i].location = AgentPoint.getHypothesis(agents[index].location);
                            }
                        }
                        else
                        {
                            List<List<double>> lines = new List<List<double>>();
                            double[,] bounds = new double[AgentPoint.dimention, 2];
                            for (int d = 0; d < AgentPoint.dimention; d++)
                            {
                                lines.Add(new List<double>());
                                for (int a = 0; a < quantityAgents; a++)
                                {
                                    if (!(a == i)) lines.ElementAt(d).Add(agents.ElementAt(a).location.point[d]);
                                }
                                lines.ElementAt(d).Sort();
                                bounds[d, 0] = lines.ElementAt(d).ElementAt(0);
                                bounds[d, 1] = lines.ElementAt(d).ElementAt(lines.ElementAt(d).Count() - 1);
                            }
                            agents[i].location = AgentPoint.getNewLocation(AgentPoint.dimention, bounds);
                        }
                    }



                }
                Console.WriteLine("Are you wish to exit this application (1-yes,0-no?");
                quit = ((int.Parse(Console.ReadLine().ToString()) == 0)?true:false);
            } while (quit);
            
        }


        static double f1(AgentPoint a)
        {
            switch (AgentPoint.dimention) {
                case 1: return (a.point[0] + Math.Pow(a.point[0], 2) + 2);
                case 2: return (a.point[0] + Math.Pow(a.point[0], 2) + Math.Sin(a.point[1]));
                case 3: return (a.point[0] + Math.Pow(a.point[0], 2) + Math.Sin(a.point[1]) + Math.Cos(a.point[2]));
            }

            return 0;
        }
    }
}
