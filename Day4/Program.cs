

using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Principal;

String[] lines = File.ReadAllLines("data.txt");

//pos and copies

Task2();

void Task1()
{
    int sumWorth = 0;

    for (int i = 0; i < lines.Length; i++)
    {

        String[] numbers = lines[i].Split(':');
        String[] winning = numbers[1].Split('|')[0].Split(" ");
        String[] otherNumbers = numbers[1].Split('|')[1].Split(" ");

        int worth = 0;

        foreach (String number in otherNumbers)
        {
            foreach (String win in winning)
            {
                int num = 0;
                int w = 0;
                if (int.TryParse(number, out num))
                {
                    if (int.TryParse(win, out w))
                    {
                        if (num == w)
                        {
                            if (worth == 0)
                            {
                                worth = 1;
                            }
                            else
                            {
                                worth *= 2;
                            }
                        }

                    }
                }
            }
        }

        Console.WriteLine("Worth: " + worth);

        sumWorth += worth;
    }

    Console.WriteLine(sumWorth);

}

void Task2()
{
    Dictionary<int, int> copies = new Dictionary<int, int>();

    for (int i = 0; i < lines.Length; i++)
    {
        copies.Add(i, 1);
    }

    for (int i = 0; i < lines.Length; i++)
    {

        String[] numbers = lines[i].Split(':');
        String[] winning = numbers[1].Split('|')[0].Split(" ");
        String[] otherNumbers = numbers[1].Split('|')[1].Split(" ");

        int pos = 1;
        foreach (var num in otherNumbers)
        {
            foreach (var win in winning)
            {
                int w = 0;
                int n = 0;
                if (int.TryParse(win, out w))
                {
                    if (int.TryParse(num, out n))
                    {
                        if(w == n){
                            copies[i+pos] += copies.ElementAt(i).Value;
                            pos++;
                        }
                    }
                }
            }

        }


    }

    int sum = 0;
    foreach(var c in copies){
        Console.WriteLine("Key "+c.Key+" Value: "+c.Value);
        sum += c.Value;
    }
    Console.WriteLine(sum);

}