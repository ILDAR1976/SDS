using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS
{
    class AgentPoint
    {
        private const double DELTAPLUS = 0.012;
        private const double DELTAMINUS = -0.014;
        const double B = 0.1;

        private static Random rand = new Random();
        public static int dimention { get; set; }
        public static double[] bounds { get; set; }
 
        public double[] point { get; set; }
 
        public AgentPoint() {}

        public AgentPoint(params double[] point)
        {
            this.point = point;
        }
       
        public static AgentPoint generateLocation(AgentPoint a)
        {
            AgentPoint o = null;

            o = new AgentPoint();

            o.point = new double[AgentPoint.dimention];
  
            for (int i = 0; i < AgentPoint.dimention; i++)
            {
                o.point[i] = rand.NextDouble() * (bounds[2 * i + 1] - bounds[2 * i]) + bounds[2 * i];
            }

            return o;
        }

        public static void setBounds(params string[] bounds)
        {
            int count = 0;

            AgentPoint.bounds = new double[AgentPoint.dimention * 2];

            foreach (var str in bounds)
            {
                AgentPoint.bounds[count++] = Double.Parse(str); 
            }
        }

        public static AgentPoint getHypothesis(AgentPoint p)
        {
            AgentPoint o = new AgentPoint(new double[AgentPoint.dimention]);
            
            for (int i = 0; i < AgentPoint.dimention; i++)
            {
                double xl = Math.Min(p.point[i] - 0.5 * B * ((p.point[i] + DELTAPLUS) - (p.point[i] - DELTAMINUS)), p.point[i]);
                double xu = Math.Max(p.point[i] + 0.5 * B * ((p.point[i] + DELTAPLUS) - (p.point[i] - DELTAMINUS)), p.point[i]);
                o.point[i] = rand.NextDouble() * (xu - xl) + xu;
            }
            return o;
        }

        public static AgentPoint getNewLocation(int dim, double[,] bounds)
        {

            AgentPoint o = new AgentPoint(new double[AgentPoint.dimention]);

            for (int i = 0; i < dim;i++) { 
                o.point[i] = bounds[i,0] + 0.5 * (bounds[i, 1] - bounds[i, 0]);
            }

            return o;
        }
    }
}