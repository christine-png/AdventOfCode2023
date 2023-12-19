
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

String[] lines = File.ReadAllLines("data.txt");

Console.WriteLine();
Task1();
Task2();
Console.WriteLine();


void Task1()
{

    decimal result = 0;

    foreach (String line in lines)
    {
        String[] elements = line.Split(',');

        foreach (String element in elements)
        {
            decimal value = HashAlgorithm(element);
            result += value;
            value = 0;
        }

        Console.WriteLine("Task 1: " + result);

    }

}

void Task2()
{

    // boxes
    Dictionary<int, List<(string, int)>> result = new Dictionary<int, List<(string, int)>>();

    String[] elements = lines[0].Split(',');

    foreach (String element in elements)
    {
        //replace or add lens
        if (element.Contains("="))
        {
            String[] parts = element.Split('=');
            String label = parts[0];
            int focalNumber = int.Parse(parts[1]);

            decimal hash = HashAlgorithm(label);

            //if key is already there
            if (result.ContainsKey((int)hash))
            {
                bool found = false;

                //if the lens is already there
                for (int i = 0; i < result[(int)hash].Count; i++)
                {
                    if (result[(int)hash][i].Item1 == label)
                    {
                        result[(int)hash][i] = (label,focalNumber);
                        found = true;
                    }
                }

                if(!found){
                    result[(int)hash].Add((label, focalNumber));
                }
                
            }
            else
            {
                List<(string, int)> list = new List<(string, int)>();
                list.Add((label, focalNumber));
                result.Add((int)hash, list);
            }


        }

        //go to relevant box and remove the label
        if (element.Contains("-"))
        {
            String[] parts = element.Split('-');
            String label = parts[0];

            decimal hash = HashAlgorithm(label);

            if (result.ContainsKey((int)hash))
            {
                bool found = false;

                for (int i = 0; i < result[(int)hash].Count; i++)
                {
                    if (result[(int)hash][i].Item1 == label)
                    {
                        found = true;
                        result[(int)hash].Remove((label, result[(int)hash][i].Item2));
                        break;
                    }
                    if (found)
                    {

                    }
                }
            }

        }

    }

    decimal ergebnis = 0;

    foreach (var r in result)
    {
        for (int i = 0; i < r.Value.Count; i++)
        {
            ergebnis+=(r.Key+1)*(i+1)*(r.Value[i].Item2);

        }
    }
    Console.WriteLine("Task 2: "+ergebnis);

}





decimal HashAlgorithm(String element)
{

    decimal value = 0;

    foreach (char c in element)
    {
        byte asciiBytes = Encoding.ASCII.GetBytes(c + " ")[0];
        value += asciiBytes;
        value *= 17;
        value = value % 256;
    }

    return value;
}