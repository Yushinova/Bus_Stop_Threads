using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_DZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusStop stop = new BusStop { CountPeople = 10, bus = new Bus { BusName = "Автобус №175", CountBusTrips = 5, FactNumber = 0, MaxNumber = 25 } };
            stop.DayStart();
        }
    }
}
