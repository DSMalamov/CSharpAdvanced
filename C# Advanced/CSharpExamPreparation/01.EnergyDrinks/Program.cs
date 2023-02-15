
Stack<int> caffein = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> drinks= new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int totalCaffein = 0;

while (caffein.Count > 0 && drinks.Count > 0)
{
    int currCaff = caffein.Pop();
    int drink = drinks.Dequeue();
    int result = currCaff * drink;

    if (result + totalCaffein > 300)
    {
        drinks.Enqueue(drink);
        totalCaffein -= 30;
        if (totalCaffein < 0)
        {
            totalCaffein = 0;
        }
    }
    else
    {
        totalCaffein+= result;
    }

}

if (drinks.Count > 0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {totalCaffein} mg caffeine.");