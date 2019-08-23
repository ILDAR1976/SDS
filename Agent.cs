using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS
{
    class Agent
    {
        public delegate double FitnessFunc(AgentPoint point);
        public bool active { get; set; }
        public AgentPoint location { get; set; }
        public FitnessFunc fitness { get; set; }
  
    public Agent()
        {
            location = new AgentPoint();
        }

        public Agent(params double[] point)
        {
            location = new AgentPoint(point);
        }
 
    }
}
