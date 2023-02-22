namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;

            var info = new Dictionary<string, Dictionary<string, double>>();

            while ((command=Console.ReadLine()) != "Revision")
            {
                string[] cmdArg = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string sMarket = cmdArg[0];
                string product = cmdArg[1];
                double price = double.Parse(cmdArg[2]);

                if (!info.ContainsKey(sMarket))
                {
                    info.Add(sMarket, new Dictionary<string, double>());
                }

                info[sMarket].Add(product, price);


            }
            info = info.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
           
        }
    }
}