using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name  { get; private set; }
        public int Capacity  { get; private set; }
        public List<Child> Registry { get; set; }

        public int ChildrenCount { get { return Registry.Count;} }

        public bool AddChild(Child child)
        {
            if (Registry.Count == Capacity)
            {
                return false;
            }
            
            Registry.Add(child);
            return true;
        }

        
        public bool RemoveChild(string childFullName)
        {
            string[] currChild = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            string fistName = currChild[0];
            string lastName = currChild[1];

            if (Registry.Any(n => n.FirstName == fistName && n.LastName == lastName))
            {
                var hhh = Registry.First(n => n.FirstName == fistName && n.LastName == lastName);

                Registry.Remove(hhh);
                return true;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] currChild = childFullName.Split(" ");

            string fistName = currChild[0].Trim();
            string lastName = currChild[1].Trim();

            if (Registry.Any(n => n.FirstName == fistName && n.LastName == lastName))
            {
                var hhh = Registry.First(n => n.FirstName == fistName && n.LastName == lastName);

                return hhh;
            }
            
            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {this.Name}:");

            foreach (var item in Registry.OrderByDescending(a => a.Age).ThenBy(n => n.LastName).ThenBy(n => n.FirstName))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
