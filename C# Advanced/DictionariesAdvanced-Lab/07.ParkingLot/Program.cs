namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;

            HashSet<string> set = new HashSet<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArg = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg[0] == "IN")
                {
                    set.Add(cmdArg[1]);
                }
                else if (cmdArg[0] == "OUT")
                {
                    set.Remove(cmdArg[1]);
                }
            }

            if (set.Count > 0)
            {
                foreach (string s in set) 
                {
                    Console.WriteLine(s);
                } 
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}