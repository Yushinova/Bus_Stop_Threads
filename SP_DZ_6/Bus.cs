using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_DZ_6
{
   public class Bus
    {
        public string BusName {  get; set; }
        public int FactNumber { get; set; }//фактическое количество пассажиров
        public int MaxNumber { get; set; }//максимальное количество пасссажиров
        public int CountBusTrips { get; set; }//количество рейсов в день
        //public int Period { get; set; }
        public Random random=new Random();
     
        public int HappyPeople(int val)//люди которым хватило места в автобусе
        {
            int FreePlases = MaxNumber - FactNumber;
            if(val<=FreePlases)
            {
               FactNumber += val;
                return val;
            }
            else
            {
                FactNumber += FreePlases;
                return FreePlases;
            }
        }
        public int GoAwayPeople()//люди которые вышли на следующей остановке
        {
            int GoAwayPeople = random.Next(0, FactNumber);
            FactNumber -= GoAwayPeople;
            return GoAwayPeople;
        }
    }
}
