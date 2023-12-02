

using System.Numerics;

String[] lines = File.ReadAllLines("data.txt");

Dictionary<String, int> dictionary = new Dictionary<String, int>();
dictionary.Add("one", 1);
dictionary.Add("two", 2);
dictionary.Add("three", 3);
dictionary.Add("four", 4);
dictionary.Add("five", 5);
dictionary.Add("six", 6);
dictionary.Add("seven", 7);
dictionary.Add("eight", 8);
dictionary.Add("nine", 9);

int sum = 0;

for (int i = 0; i < lines.Length; i++)
{
    bool firstFound = false;
    string foundNumber = "";
    int lastNumber = 0;

    for (int j = 0; j < lines[i].Length; j++)
    {

        int num;

        if (int.TryParse(lines[i][j] + "", out num))
        {

            if (firstFound == false)
            {
                foundNumber = lines[i][j] + "";
                firstFound = true;
            }
            lastNumber = int.Parse(lines[i][j] + "");

        }
        else
        {
            foreach (var eintrag in dictionary)
            {

                if (j + eintrag.Key.Length <= lines[i].Length)
                {

                    if (lines[i].Substring(j, eintrag.Key.Length) == eintrag.Key)
                    {
                        if (firstFound == false)
                        {
                            foundNumber = eintrag.Value + "";
                            firstFound = true;
                        }
                        lastNumber = int.Parse(eintrag.Value + "");
                    }

                }

            }
        }

        


    }


    foundNumber = foundNumber + lastNumber;
    sum += int.Parse(foundNumber);

    

}

Console.WriteLine(sum);