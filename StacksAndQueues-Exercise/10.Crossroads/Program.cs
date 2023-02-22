using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialGreenLight = int.Parse(Console.ReadLine());
            int initialFreeWindow = int.Parse(Console.ReadLine());
            string command;
            Queue<string> cars = new();
            int carsPassed = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currGL = initialGreenLight;
                    int currFreeWindow = initialFreeWindow;

                    while (currGL > 0 && cars.Any())
                    {
                        string curCar = cars.Dequeue();

                        currGL -= curCar.Length;

                        if (currGL + currFreeWindow < 0)
                        {

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{curCar} was hit at {curCar[curCar.Length - Math.Abs(currGL + currFreeWindow)]}.");
                            return;
                        }
                        carsPassed++;
                    }


                }
                else
                {
                    cars.Enqueue(command);
                }

                    
            }

            
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}