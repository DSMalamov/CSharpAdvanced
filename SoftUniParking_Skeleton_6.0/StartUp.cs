namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person person = new Person();

        person.Age = 10;

        System.Console.WriteLine(person.Age);
    }
}
