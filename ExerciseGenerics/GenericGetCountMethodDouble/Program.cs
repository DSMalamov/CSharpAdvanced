using GenericGetCountMethodDouble;

Box<double> box= new Box<double>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    double num = double.Parse(Console.ReadLine());
    box.Add(num);
}

double numToCompare = double.Parse(Console.ReadLine());

Console.WriteLine(box.Count(numToCompare));
