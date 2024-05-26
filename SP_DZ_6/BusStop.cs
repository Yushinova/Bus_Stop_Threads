using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_DZ_6
{
    public class BusStop
    {
        public int CountPeople { get; set; }
        public Random random = new Random();
        public Bus bus { get; set; }
        Mutex mutex = new Mutex();
        public void PeopleCame()//приход людей на остановку. Ограничеваем доступ 
        {
            while (bus.CountBusTrips!=0)
            {
                try
                {
                    mutex.WaitOne();
                    if(bus.CountBusTrips > 0) CountPeople += random.Next(1, 15);
                    Console.WriteLine($"-----------На остановке ожидают {CountPeople} человек");
                    Task.Delay(2000);
                }
             finally
                {
                    mutex.ReleaseMutex();
                }
            }
            Console.WriteLine($"День закончен! Количество оставшихся людей на остановке {CountPeople}");
            Console.ReadKey();
        }
        public void GoBus()//движение автобуса по кругу
        {

            do
            {
                try
                {
                    mutex.WaitOne();
                    Task.Delay(2000).Wait();
                    Console.WriteLine($"{bus.BusName} едет.......Всего {bus.FactNumber} человек в автобусе");          
                    Console.WriteLine($"{bus.BusName} подъехал к остановке.....");
                    int happy = bus.HappyPeople(CountPeople);
                    Console.WriteLine($"В автобус {bus.BusName} сели {happy} человек");
                    CountPeople -= happy;//убираем тех кто поместился в автобус
                    Task.Delay(1000).Wait();
                    int goAway = bus.GoAwayPeople();
                    Console.WriteLine($"На следующей остановке из автобуса {bus.BusName} вышли {goAway} человек");
                    bus.CountBusTrips--;
                }
               finally
                {
                    mutex.ReleaseMutex();
                }

            } while (bus.CountBusTrips != 0);
        }
        public void DayStart()
        {
            Thread threadComePeople = new Thread(new ThreadStart(PeopleCame));
            Thread threadGoBus = new Thread(new ThreadStart(GoBus));
            threadComePeople.Start();
            threadGoBus.Start();
        }
    }
}
