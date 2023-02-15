namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new(
                    currCar[0],
                    int.Parse(currCar[1]),
                    int.Parse(currCar[2]),
                    int.Parse(currCar[3]),
                    currCar[4],
                    double.Parse(currCar[5]), int.Parse(currCar[6]),
                    double.Parse(currCar[7]), int.Parse(currCar[8]),
                    double.Parse(currCar[9]), int.Parse(currCar[10]),
                    double.Parse(currCar[11]), int.Parse(currCar[12])
                    );

                cars.Add(car);
                
            }

            string command = Console.ReadLine();

            string[] filtered;

            if (command == "fragile")
            {
                filtered = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToArray();

            }
            else
            {
                filtered = cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToArray();
            }

            Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }
    }
}