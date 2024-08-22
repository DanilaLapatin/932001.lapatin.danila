using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSimmod14
{
    internal class AgentStation
    {
        double Mu;
        int BusyStat;
        int StationsNumber;
        Random rnd = new Random();

        public AgentStation(double m, int StatNum)
        {
            Mu = m;
            StationsNumber = StatNum;
        }

        public int BusyStations { get => BusyStat; set => BusyStat = value; }
        public int NumberOfStations { get => StationsNumber; }

        public double GetNextEvent()
        {
            if (BusyStat > 0)
            {
                double A = rnd.NextDouble();
                double temp = A * BusyStat;
                return (-Math.Log(temp) / Mu);
            }
            else { return Double.PositiveInfinity; }
        }

        public void ProcessEvent(AgentQueueRobot aqr)
        {
            if (aqr.NumberOfRobots == 0)
            {
                BusyStat--;
            }
            else
            {
                aqr.NumberOfRobots--;
            }
        }
    }
}
