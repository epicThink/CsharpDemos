using System;
using System.Collections.Generic;

namespace CSharpTraining
{
    public enum Orase : int { Bucuresti, Ploiesti, Pitesti, Brasov, Timisoara, Iasi };
    public enum Vehicule : int { Masina, Motocicleta, Bicicleta };

    class Program
    {
        static void Main(string[] args)
        {
            int NrVehicule = 3;
            int NrOrase = 6;
            int userInput;

            int[,] distances =
             {
                {0,    53,   120,  160,  545,  388},
                {53,   0,    123,  106,  513,  345},
                {120,  123,  0,    140,  429,  506},
                {160,  106,  140,  0,    411,  306},
                {545,  513,  429,  411,  0,    634},
                {388,  345,  506,  306,  634,  0}
            };

            Console.WriteLine("\n" + Text.welcome);
            Console.WriteLine("\n" + Text.alegeVehicul);
                        
            userInput = GetUserInput(NrVehicule, Text.erroareVehicul,Vehicule.Masina);
            Vehicle vehicul = Vehicle.AskVehicleType(userInput);

            Console.WriteLine("\n" + Text.alegeViteza);

            userInput = GetUserInput(10000, Text.eroareViteza);
            vehicul.Speed = userInput;
             
            Console.WriteLine("\n" + Text.alegeStart);

            userInput = GetUserInput(NrOrase, Text.eroareStart, Orase.Ploiesti);
            vehicul.Start = (Orase)(userInput - 1);
             
            Console.WriteLine("\n" + Text.alegeEnd);

            userInput = GetUserInput(NrOrase, Text.eroareEnd, Orase.Bucuresti);
            vehicul.End = (Orase)(userInput - 1);

            var calc = vehicul.CalculateTravelTime(distances).ToTimeSpan();

            Console.WriteLine("\n" + "Drumul de la " + vehicul.Start + " pana la " + vehicul.End + " va dura: " + calc);
        }

        static int GetUserInput(int max, string errMsg, Enum? enumValue = null)
        {
            if(enumValue != null) PrintOptions(enumValue);

            int outInt = 0;
            bool testValue;
            do
            {
                string input = Console.ReadLine();
                testValue = input is null || !int.TryParse(input, out outInt) || outInt < 1 || outInt > max;

                if (testValue)
                    Console.WriteLine(errMsg);

            } while (testValue);

            return outInt;
        }

        static void PrintOptions( Enum list)
        {
            Type t = list.GetType();
            int idx = 1;

            foreach (string elem in Enum.GetNames(t))
            {
                Console.WriteLine(idx++ + "-" + elem);                
            }
        }
    }
}



//TODO muta toate clasele in fisierele lor ---- DONE
//todo GET/SET                             ---- DONE
//todo no hardcoding              
//todo tryparse in loc de parse            ---- DONE
//todo askvehicletype in vehicle class     ---- DONE