using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDist;
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TravelledDist = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDist { get; set; }

        public void Travel(double distance)
        {
            if (distance * FuelConsumptionPerKm > FuelAmount )
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                TravelledDist += distance;
                FuelAmount -= distance * FuelConsumptionPerKm;
            }

        }
    }
}
