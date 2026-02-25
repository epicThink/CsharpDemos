using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTraining
{
    public class Car : Vehicle
    {
        int refuel = 100;
        int breaktime = 10;

        protected override int CalculateDistance(int[,] distances)
        {
            return distances[(int)Start, (int)End];
        }

        public override TimeOnly CalculateTravelTime(int[,] distances)
        {
            int distanceToTravel = CalculateDistance(distances);


            double timp = (double)distanceToTravel / (double)Speed * 60;
            timp += timp / (double)refuel * (double)breaktime;


            TimeOnly timePassed = new TimeOnly(0, 0, 0);


            return timePassed.AddMinutes(timp);
        }
    }
}
