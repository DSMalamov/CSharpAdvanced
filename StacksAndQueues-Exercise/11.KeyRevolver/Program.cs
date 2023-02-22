namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
                //•	On the first line of input, you will receive the price of each bullet – an integer in the range[0 - 100]
                //•	On the second line, you will receive the size of the gun barrel – an integer in the range[1 - 5000]
                //•	On the third line, you will receive the bullets – a space-separated integer sequence with[1 - 100] integers
                //•	On the fourth line, you will receive the locks – a space-separated integer sequence with[1 - 100] integers
                //•	On the fifth line, you will receive the value of the intelligence – an integer in the range[1 - 100000]

            int pricePerBullet = int.Parse(Console.ReadLine());

            int gunBarrel = int.Parse(Console.ReadLine());

            int[] inputBullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputLocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int inteligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new(inputLocks);
            Stack<int> bullets = new(inputBullets);
            int barelStatus = gunBarrel;

            while (bullets.Any())
            {
                int curBullet = bullets.Pop();
                barelStatus--;
                inteligence -= pricePerBullet;
                int curLock = locks.Peek();
                

                if (curLock >= curBullet)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    
                }
                else if (curLock < curBullet)
                {
                    Console.WriteLine("Ping!");
                }

                

                if (barelStatus == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");

                    if (gunBarrel > bullets.Count)
                    {
                        barelStatus = bullets.Count;
                    }
                    else
                    {
                        barelStatus = gunBarrel;
                    }
                }

                if (locks.Count <= 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligence}");
                    return;
                }

            }
            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            

        }
    }
}