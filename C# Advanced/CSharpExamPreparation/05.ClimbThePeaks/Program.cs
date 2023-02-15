Stack<int> portions = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> stamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

List<Peak> peaks = new();
peaks.Add(new Peak("Vihren", 80, 1));
peaks.Add(new Peak("Kutelo", 90, 2));
peaks.Add(new Peak("Banski Suhodol", 100, 3));
peaks.Add(new Peak("Polezhan", 60, 4));
peaks.Add(new Peak("Kamenitza", 70, 5));

int counter = 1;

while (stamina.Any() && portions.Any() && peaks.Any(p => !p.IsConquared))
{
    int currPortion = portions.Pop();
    int currstamina = stamina.Dequeue();
    int result = currPortion + currstamina;

    Peak currPeak = peaks.First(p => p.Id == counter);

    if (currPeak.Diff <= result)
    {
        currPeak.IsConquared = true;
        counter++;
    }
}

if (peaks.Any(p => !p.IsConquared))
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}

if (peaks.Any(p => p.IsConquared))
{
    Console.WriteLine("Conquered peaks:");
    foreach (Peak peak in peaks)
    {
        
        if (peak.IsConquared)
        {
            Console.WriteLine(peak.Name);
        }
    }
}


public class Peak
{
    public Peak(string name, int diff, int id)
    {
        Name = name;
        Diff = diff;
        Id = id;
    }

    public string Name { get; set; }
    public int Diff { get; set; }
    public bool IsConquared { get; set; }
    public int Id { get; set; }
}