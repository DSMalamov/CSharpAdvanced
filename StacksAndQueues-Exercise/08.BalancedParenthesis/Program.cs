

string input = Console.ReadLine();
Stack<char> brackets = new();
int c1 = 0;
int c2 = 0;
int c3 = 0;
int c4 = 0;
int c5 = 0;
int c6 = 0;

foreach (var ch in input)
{
    char currCh = ch;

    if (currCh == '(' || currCh == ')' || currCh == '[' || currCh == ']' || currCh == '{' || currCh == '}')
    {
        brackets.Push(currCh);
    }
    else
    {
        Console.WriteLine("NO");
        return;
    }
}

int n = brackets.Count;

for (int i = 0; i < n; i++)
{
    char currCh = brackets.Pop();

    switch (currCh)
    {
        case '(':
            c1++;
            break;
        case ')':
            c2++;
            break;
        case '[':
            c3++;
            break;
        case ']':
            c4++;
            break;
        case '{':
            c5++;
            break;
        case '}':
            c6++;
            break;
    }
}

if (c1 == c2 && c3 == c4 && c5 == c6)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}

