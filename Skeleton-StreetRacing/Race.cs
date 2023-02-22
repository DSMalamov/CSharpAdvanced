using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.participants = new List<Car>();
        }

        //•	Name: string
        //•	Type: string
        //•	Laps: int
        //•	Capacity: int - the maximum allowed number of participants in the race
        //•	MaxHorsePower: int - the maximum allowed Horse Power of a Car in the Race

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants { get; set; }

        public int Count { get { return participants.Count; } }

        public void Add(Car car)
        {
            if (!participants.Any(c => c.LicensePlate == car.LicensePlate) 
                && car.HorsePower <= this.MaxHorsePower 
                && this.participants.Count < Capacity)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (participants.Any(c => c.LicensePlate == licensePlate))
            {
                participants.RemoveAll(c => c.LicensePlate == licensePlate);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate) => participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar()
        {
            int currHp = -1;

            if (participants.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in participants)
                {
                    if (item.HorsePower > currHp)
                    {
                        currHp = item.HorsePower;
                    }
                }
                return participants.FirstOrDefault(c => c.HorsePower == currHp);
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in participants)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
