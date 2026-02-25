using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTraining
{
    public abstract class Vehicle
    {
        private int speed;
        public int Speed { get { return speed; } set { speed = value; } }

        private Orase start;
        public Orase Start { get { return start; } set { start = value; } }

        private Orase end;
        public Orase End { get { return end; } set { end = value; } }


        protected abstract int CalculateDistance(int[,] distances);

        public abstract TimeOnly CalculateTravelTime(int[,] distances);

        public static Vehicle AskVehicleType(int idx)
        {
            
            switch (idx)
            {
                case 1:
                    Console.WriteLine("Vehicul ales = Masina");
                    return new Car();

                case 2:
                    Console.WriteLine("Vehicul ales = Motocicleta");
                    return new Motorcycle();
                default:
                    Console.WriteLine("Vehicul ales = Bicicleta");
                    return new Bike();
            }

        }

    }
}
