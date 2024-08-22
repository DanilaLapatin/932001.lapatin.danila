using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSimmod14
{
    internal class Factory
    {
        double NextRobot;
        double NextStation;
        double Time = 0;
        double T;
        int k;
        int N;
        double Lambda;
        double Mu;
        double Rho;
        int StationsNumber;
        double StatDist;
        Dictionary<int, double> Freq = new Dictionary<int, double>();
        Dictionary<int, double> Stat;

        public void BeginWork(double l, double m, int n, double t, int StNum)
        {
            Lambda = l;
            Mu = m;
            Rho = l / m;
            N = n;
            T = t;
            k = 0;
            StationsNumber = StNum;
            StatDist = StationaryDistribution(StNum);


        }
        public AgentQueueRobot InitialAQR()
        {
            AgentQueueRobot AQR = new AgentQueueRobot(Lambda);
            return AQR;
        }
        public AgentStation InitialAS()
        {
            AgentStation AS = new AgentStation(Mu, StationsNumber);
            return AS;
        }

        public Dictionary<int, double> Statistics()
        {
            Stat = Freq;
            foreach (int i in Stat.Keys.ToList())
            {
                if (i < StationsNumber)
                {
                    Stat[i] = (Math.Pow(Rho, i) / Fact(i)) * StatDist;
                }
                else
                {
                    Stat[i] = (Math.Pow(Rho, i) / (Fact(i) * Math.Pow(StationsNumber, i - StationsNumber))) * StatDist;
                }
            }
            return Stat;
        }

        public Dictionary<int, double> DistributionAndEmpiricalProbability(AgentStation AgStat, AgentQueueRobot AgQuRob)
        {
            while (k < N)
            {
                while (Time < T)
                {
                    NextStation = AgStat.GetNextEvent();
                    NextRobot = AgQuRob.GetNextEvent();
                    if (NextRobot < NextStation)
                    {
                        AgQuRob.ProcessEvent(AgStat);
                        Time += NextRobot;
                    }
                    else
                    {
                        AgStat.ProcessEvent(AgQuRob);
                        Time += NextStation;
                    }
                }
                k++;
                Time = 0;
                try
                {
                    Freq.Add(AgStat.BusyStations + AgQuRob.NumberOfRobots, 0);
                }
                catch
                {
                    Console.WriteLine("Элемент уже существует");
                }
                finally
                {
                    Console.WriteLine("Исключение обработано");
                }
                Freq[AgStat.BusyStations + AgQuRob.NumberOfRobots]++;

            }
            foreach (int i in Freq.Keys.ToList())
            {
                Freq[i] /= N;
            }
            return Freq;
        }


        private double StationaryDistribution(int StatNum)
        {
            double temp = 0;
            for (int i = 0; i < StatNum; i++)
            {
                temp += Math.Pow(Rho, i) / Fact(i);
            }
            double temp1 = Math.Pow(Rho, (StatNum + 1)) / Fact(StatNum) * (StatNum - Rho);
            double sd = Math.Pow((temp + temp1), -1);
            return sd;
        }
        private int Fact(int i)
        {
            int temp = 1;
            for (int j = 1; j <= i; j++)
            {
                temp *= j;
            }
            return temp;
        }
    }
}
