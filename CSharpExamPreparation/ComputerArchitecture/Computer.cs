using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);

            }
        }

        public bool Remove(string brand)
        {
            CPU cpuToRemove = Multiprocessor.FirstOrDefault(x => x.Brand == brand);

            if (cpuToRemove != null)
            {
                return Multiprocessor.Remove(cpuToRemove);
            }

            return false;
        }

        public CPU MostPowerful()
        {
            if (Multiprocessor.Count == 0)
            {
                return null;
            }

            CPU mostPowerful = Multiprocessor[0];

            for (int i = 0; i < Multiprocessor.Count; i++)
            {
                if (Multiprocessor[i].Frequency > mostPowerful.Frequency)
                {
                    mostPowerful = Multiprocessor[i];
                }
            }
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder result = new();

            result.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }

            return result.ToString().Trim();
        }


    }
}
