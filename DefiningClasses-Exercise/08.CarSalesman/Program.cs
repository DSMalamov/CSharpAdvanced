namespace _08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(engArg);

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCar(carArg, engines);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        static Engine CreateEngine(string[] engineProp)
        {
            Engine engine = new(engineProp[0], int.Parse(engineProp[1]));

            if (engineProp.Length > 2)
            {
                int displacement;

                bool isDigit = int.TryParse(engineProp[2], out displacement);

                if (isDigit) 
                { 
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineProp[2];
                }

                if (engineProp.Length > 3)
                {
                    engine.Efficiency = engineProp[3];
                }
            }

            return engine;
        }
        static Car CreateCar(string[] carProp, List<Engine> engines)
        {
            Engine engine = engines.Find(x => x.Model == carProp[1]);
            Car car = new(carProp[0], engine);

            if (carProp.Length > 2)
            {
                int weight;

                bool isDigit = int.TryParse(carProp[2], out weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carProp[2];
                }
                if (carProp.Length > 3)
                {
                    car.Color = carProp[3];
                }
            }

            return car;
        }
    }
}