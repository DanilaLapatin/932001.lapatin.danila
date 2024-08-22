using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSimmod14
{
    internal class AgentQueueRobot
    {
        double Lambda;
        int RobotsNumber;
        Random rnd = new Random();

        public AgentQueueRobot(double l)
        {
            Lambda = l;
            RobotsNumber = 0;
        }

        public int NumberOfRobots { get => RobotsNumber; set => RobotsNumber = value; }

        public double GetNextEvent()
        {
            double A = rnd.NextDouble();
            return (-Math.Log(A) / Lambda);
        }

        public void ProcessEvent(AgentStation AgStat)
        {
            if (AgStat.BusyStations < AgStat.NumberOfStations)
            {
                AgStat.BusyStations++;
            }
            else
            {
                RobotsNumber++;
            }
        }

    }
}
