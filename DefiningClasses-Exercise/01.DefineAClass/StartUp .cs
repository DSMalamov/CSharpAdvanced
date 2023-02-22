namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> family= new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person= new Person(command[0], int.Parse(command[1]));
                
                if (person.Age > 30)
                {
                    family.Add(person);
                }
                
            }


            foreach (var item in family.OrderBy(m =>m.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}