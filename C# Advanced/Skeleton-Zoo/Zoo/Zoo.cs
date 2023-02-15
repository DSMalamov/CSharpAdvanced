using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.animals= new List<Animal>();
        }

        public string Name { get;private set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Animal> Animals => this.animals;

        public string AddAnimal(Animal animal)
        {
            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species) => animals.RemoveAll(a => a.Species == species);

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> list = new List<Animal>();

            foreach (Animal animal in Animals.Where(a => a.Diet == diet))
            {
                list.Add(animal);
            }
            return list;
        }


        public Animal GetAnimalByWeight(double weight) => Animals.FirstOrDefault(a => a.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }



    }
}
