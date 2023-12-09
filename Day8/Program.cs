
using System.Drawing;

String[] lines = File.ReadAllLines("data.txt");
String path = lines[0];

List<Location> locations = new List<Location>();

initLocations();
Task1();
Task2();

void initLocations()
{
    for (int i = 2; i < lines.Length; i++)
    {

        String currentLocation = lines[i].Split(" ")[0];
        String left = lines[i].Split(" ")[2].Replace("(", "").Replace(")", "").Replace(",", "");
        String right = lines[i].Split(" ")[3].Replace("(", "").Replace(")", "").Replace(",", "");

        Location l = new Location(currentLocation, left, right);
        locations.Add(l);
    }
}

void Task1()
{

    Console.WriteLine("\n********************************");
    Console.WriteLine("TASK 1");
    Console.WriteLine("\n********************************");
    

    string searchText = "AAA";
    int steps = 0;

    bool found = false;

    do
    {
        for (int i = 0; i < path.Length; i++)
        {

            for (int j = 0; j < locations.Count; j++)
            {
                //Console.WriteLine(searchText);
                if (locations[j].currentLocation == searchText)
                {

                    if (path[i] == 'L')
                    {
                        //Console.WriteLine(path[i] + " " + searchText + " " + locations[j].leftLocation);
                        searchText = locations[j].leftLocation;
                    }
                    else if (path[i] == 'R')
                    {
                        //Console.WriteLine(path[i] + " " + searchText + " " + locations[j].rightLocation);
                        searchText = locations[j].rightLocation;
                    }
                    steps++;

                    if (searchText == "ZZZ")
                    {
                        found = true;
                        break;
                    }
                    break;
                }


            }
            if (searchText == "ZZZ")
            {
                break;
            }
        }

        //Console.WriteLine("Steps: "+steps);

    } while (!found);


    Console.WriteLine("Result: " + steps);
}


void Task2()
{
    

    Console.WriteLine("\n\n********************************");
    Console.WriteLine("TASK 2");
    Console.WriteLine("\n********************************");
    

    //Points where an A is the last letter
    List<Destination> points = new List<Destination>();

    Console.WriteLine("\nStart Points: ");
    int count = 0;
    foreach (var l in locations)
    {
        if (l.currentLocation[2] == 'A')
        {
            Destination d = new Destination(l.currentLocation, 0, l.currentLocation, 0);
            points.Add(d);
            Console.WriteLine(d);
            count++;
        }
    }
    Console.WriteLine();


    Console.WriteLine("********************************");
    

    List<decimal> numbers = new List<decimal>();

    Console.WriteLine("\nEnd Points: ");
    for (int i = 0; i < points.Count; i++)
    {

            string nextLocation;
            int nextPosition;
            decimal steps =
                getSteps(
                    points.ElementAt(i).nextPosition,
                    out nextLocation, points.ElementAt(i).position, out nextPosition);
            points.ElementAt(i).nextPosition = nextLocation;
            points.ElementAt(i).steps += steps;
            points.ElementAt(i).position = nextPosition;
            Console.WriteLine(nextLocation+" "+ steps);
            numbers.Add(steps);
    }

    Console.WriteLine("\n********************************");
    

    Console.WriteLine();
    decimal result = CalculateLCM(numbers.ToArray());
    Console.WriteLine("Result: "+result);
    Console.WriteLine();
}


decimal getSteps(string startLocation, out string nextLocation, int startPos, out int nextPosition)
{

    nextLocation = "";
    nextPosition = 0;
    int steps = 0;
    bool zFound = false;

    for (int i = startPos; i < path.Length; i++)
    {
        for (int j = 0; j < locations.Count; j++)
        {

            if (startLocation == locations[j].currentLocation)
            {
                //Change the Point
                if (path[i] == 'L')
                {
                    startLocation = locations[j].leftLocation;
                }
                else
                {
                    startLocation = locations[j].rightLocation;
                }
                steps++;

                //Check if the new location has a Z on the last position
                if (startLocation[2] == 'Z')
                {
                    zFound = true;
                    nextLocation = startLocation;
                }

                break;
            }
        }

        if (zFound)
        {
            nextPosition = (i + 1) % (path.Length);
            break;
        }



        if (i == path.Length - 1)
        {
            i = -1;
        }

    }

    return steps;
}

   static decimal CalculateLCM(decimal[] numbers)
    {
        decimal lcm = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            lcm = FindLCM(lcm, numbers[i]);
        }
        return lcm;
    }

    static decimal FindLCM(decimal a, decimal b)
    {
        decimal gcd = FindGCD(a, b);
        return (a * b) / gcd;
    }

    static decimal FindGCD(decimal a, decimal b)
    {
        while (b != 0)
        {
            decimal temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
