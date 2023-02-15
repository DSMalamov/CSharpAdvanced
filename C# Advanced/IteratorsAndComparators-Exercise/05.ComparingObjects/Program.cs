using ComparingObjects;
using System.Security.Cryptography;

string command;

List<Person> persons = new();

while ((command = Console.ReadLine()) != "END")
{
    string[] cmdArg = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Person peroson = new Person()
    {
        Name = cmdArg[0],
        Age = int.Parse(cmdArg[1]),
        Town = cmdArg[2]
    };

    persons.Add(peroson);
}

int index = int.Parse(Console.ReadLine()) - 1;

Person personToCompare = persons[index];

int equal = 0;
int diff = 0;

foreach (Person person in persons)
{
    if (person.CompareTo(personToCompare) == 0)
    {
        equal++;
    }
    else
    {
        diff++;
    }
}

if (equal == 1)
{
    Console.WriteLine("No matches");
}
else
{
    Console.WriteLine($"{equal} {diff} {persons.Count}");
}
