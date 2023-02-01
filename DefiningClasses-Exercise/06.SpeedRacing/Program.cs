namespace _06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsByName = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new(currCar[0], double.Parse(currCar[1]), double.Parse(currCar[2]));

                carsByName.Add(car.Model, car);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = cmdArg[1];
                double distanceInKm = double.Parse(cmdArg[2]);

                Car car = carsByName[model];
                
                car.Travel(distanceInKm);
            }

            foreach (var item in carsByName)
            {
                Console.WriteLine($"{item.Value.Model} {item.Value.FuelAmount:f2} {item.Value.TravelledDist}");
            }
        }
    }
}