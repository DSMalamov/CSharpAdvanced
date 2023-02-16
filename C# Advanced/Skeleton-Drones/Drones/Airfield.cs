using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; private set; }

        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Name == string.Empty)
            {
                return "Invalid drone.";
            }
            else if (drone.Brand == null || drone.Brand == string.Empty)
            {
                return "Invalid drone.";
            }
            else if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (this.Capacity == Drones.Count)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";

        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(n => n.Name == name))
            {
                Drones.RemoveAll(n => n.Name == name);
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand) => Drones.RemoveAll(n => n.Brand == brand);

        public Drone FlyDrone(string name)
        {
            foreach (var item in Drones)
            {
                if (item.Name == name)
                {
                    item.Available = false;
                    return item;
                }
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var list = new List<Drone>();

            foreach (var item in Drones.Where(r => r.Range >= range))
            {
                list.Add(item);
                item.Available = false;
            }

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var item in Drones.Where(d => d.Available == true)) 
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }


    }
}
