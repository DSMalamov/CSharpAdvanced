using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }
        public IReadOnlyCollection<Renovator> Renovators => this.renovators;

        public int Count { get { return renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Any(r => r.Name == name))
            {
                foreach (var item in renovators)
                {
                    if (item.Name == name)
                    {
                        renovators.Remove(item);
                        return true;
                    }
                }
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type) => renovators.RemoveAll(r => r.Type == type);

        public Renovator HireRenovator(string name)
        {
            var currRenovator = this.Renovators.FirstOrDefault(r => r.Name == name);

            if (currRenovator == null)
            {
                return null;
            }

            this.Renovators.FirstOrDefault(r => r.Name == name).Hired = true;

            return currRenovator;

        }
        
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> list = new List<Renovator>();

            foreach (var renovator in renovators)
            {
                if (renovator.Days >= days)
                {
                    list.Add(renovator);
                }
            }

            return list;
        }

        public string Report()
        {
            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in renovators.Where(x => x.Hired == false).Where(x => x.Paid == false))
            {
                sbb.AppendLine(renovator.ToString());
            }
            return sbb.ToString().Trim();
        }



    }
}
