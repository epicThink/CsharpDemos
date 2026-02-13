using System;
using System.Collections.Generic;

namespace CSharpExercises
{
    public enum Orase :int  { Bucuresti, Ploiesti, Pitesti, Brasov, Timisoara, Iasi }

    public abstract class Vehicle
    {

        public int speed;
        public Orase start;
        public Orase end;

        protected abstract int CalculateDistance(int[,] distances);
        public abstract TimeOnly CalculateTravelTime(int[,] distances);


    }
    public class Car : Vehicle 
    {
        int refuel = 100;
        int breaktime = 10;
        public Car() { }
        protected override int CalculateDistance(int[,] distances)
        {
            return distances[(int)start,(int)end];
        }
        public override TimeOnly CalculateTravelTime(int[,] distances)
        {
            int distanceToTravel = CalculateDistance(distances);


            int timp = distanceToTravel / speed * 60;
            timp += timp / refuel * breaktime;


            TimeOnly timePassed = new TimeOnly(0, 0, 0);
            

            return timePassed.AddMinutes(timp);
        }
    }
    public class Motorcycle : Vehicle
    {
        int refuel = 80;
        int breaktime = 10;
        public Motorcycle() { }
        protected override int CalculateDistance(int[,] distances)
        {
            return distances[(int)start, (int)end];
        }
        public override TimeOnly CalculateTravelTime(int[,] distances)
        {
            int distanceToTravel = CalculateDistance(distances);


            int timp = distanceToTravel / speed*60;
            timp += timp / refuel * breaktime;


            TimeOnly timePassed = new TimeOnly(0, 0, 0);
            

            return timePassed.AddMinutes(timp);
        }
    }
    public class Bike : Vehicle
    {
        int rest = 60;
        int breaktime = 20;
        public Bike() { }
        protected override int CalculateDistance(int[,] distances)
        {
            return distances[(int)start, (int)end];
        }
        public override TimeOnly CalculateTravelTime(int[,] distances)
        {
            int distanceToTravel = CalculateDistance(distances);
            

            int timp=distanceToTravel/speed*60;
            timp += (timp / rest) * breaktime;
            
           
            TimeOnly timePassed = new TimeOnly(0, 0, 0);
            

            return timePassed.AddMinutes(timp);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] distances =
            {
                {0,    53,   120,  160,  545,  388},
                {53,   0,    123,  106,  513,  345},
                {120,  123,  0,    140,  429,  506},
                {160,  106,  140,  0,    411,  306},
                {545,  513,  429,  411,  0,    634},
                {388,  345,  506,  306,  634,  0}

            };


            Console.WriteLine("Bine ai venit la HaiLa, un program care te ajuta sa aflii cat iti ia sa mergi dintr-un oras in altul!");

            //intreaba vehicul
            Console.WriteLine("Pentru inceput, alegeti vehiculul:");
            Console.WriteLine("1 - Masina\n2 - Motocicleta\n3 - Bicicleta");
            Vehicle vehicul;
            try 
            { 
                vehicul = AskVehicleType();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return; }

            //intreaba viteza
            Console.WriteLine("Acum te rog sa introduci viteza medie (aproximativa) pentru acest drum.");
            string viteza = Console.ReadLine();
            if(viteza != null)
            {
                int temp = int.Parse(viteza);
                vehicul.speed = temp;
            }
            Console.WriteLine();

            //intreaba start
            Console.WriteLine("Alegeti orasul de unde pleci:");
            for(int i = 0;i<6;i++) 
            {
                Console.WriteLine( i+ "-"+ (Orase)i);
            }
            string start = Console.ReadLine();
            if (start != null)
            {
                var temp = (Orase)int.Parse(start);
                if((int)temp >-1 && (int)temp <6)
                    vehicul.start = temp;
                else
                {
                    Console.WriteLine("Aceasta optiune nu exista :(");
                    return;
                }
            }
            Console.WriteLine();


            //intreaba end
            Console.WriteLine("Alegeti orasul unde vrei sa ajungi:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(i + "-" + (Orase)i);
            }
            string end = Console.ReadLine();
            if (end != null)
            {
                var temp = (Orase)int.Parse(end);
                if ((int)temp > -1 && (int)temp < 6)
                    vehicul.end = temp;
                else
                {
                    Console.WriteLine("Aceasta optiune nu exista :(");
                    return;
                }
            }
            Console.WriteLine();

            //calculeaza 
            Console.WriteLine("Drumul de la "+vehicul.start +" pana la "+vehicul.end+" va dura: "+vehicul.CalculateTravelTime(distances).ToTimeSpan());

            return;
        }
        static Vehicle AskVehicleType() 
        {
            string vehicul = Console.ReadLine();
            int numar = int.Parse(vehicul);

            switch (numar)
            {
                case 1:
                    Console.WriteLine("Vehicul ales = Masina");
                    return new Car();
                    
                case 2:
                    Console.WriteLine("Vehicul ales = Motocicleta");
                    return new Motorcycle();
                case 3:
                    Console.WriteLine("Vehicul ales = Bicicleta");
                    return new Bike();
                default:
                    throw new InvalidDataException("Optiunea aceasta nu exista");
            }
            
        
        }

        
    }
}
