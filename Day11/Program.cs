
List<string> data = File.ReadAllLines("data.txt").ToList();
List<List<char>> lines = new List<List<char>>();

List<(int, int)> positionsOfGalaxies = new List<(int, int)>();

List<(int, int)> positionsOfEmpty = new List<(int, int)>();

//initData();
initDataTask2();

Console.WriteLine();
Console.WriteLine("*****************************");
Console.WriteLine("TASK 1");
Console.WriteLine("*****************************");
Console.WriteLine();

getPositionOfGalaxies();
//Console.WriteLine();
calculateShortestPathsOfGalaxies();
Console.WriteLine();



Console.WriteLine("*****************************");
Console.WriteLine("TASK 2");
Console.WriteLine("*****************************");

//Expand galaxies
void initData()
{

    //Add row if a row has no galaxy
    for (int i = 0; i < data.Count; i++)
    {
        lines.Add(data.ElementAt(i).ToList<char>());
        if (!data.ElementAt(i).Contains('#'))
        {
            lines.Add(data.ElementAt(i).ToList<char>());
        }
    }

    //Add column if a column has no galaxy
    for (int i = 0; i < lines.ElementAt(0).Count; i++)
    {

        bool onlyDotsInColumn = true;

        for (int j = 0; j < lines.Count; j++)
        {
            if (lines.ElementAt(j).ElementAt(i) != '.')
            {
                onlyDotsInColumn = false;
            }
        }

        if (onlyDotsInColumn)
        {
            for (int j = 0; j < lines.Count; j++)
            {
                lines.ElementAt(j).Insert(i, '.');
            }
            i++;
        }


    }

    //Show new data
    /*
    foreach (List<char> l in lines)
    {
        foreach(char c in l){
            Console.Write(c);
        }
        Console.WriteLine();
    }
    */
}

void initDataTask2()
{

    //Add row if a row has no galaxy
    for (int i = 0; i < data.Count; i++)
    {
        //Console.WriteLine(i);
        lines.Add(data.ElementAt(i).ToList<char>());
        if (!data.ElementAt(i).Contains('#'))
        {
            for (int k = 0; k < lines.ElementAt(i).Count; k++)
            {
                positionsOfEmpty.Add((i, k));
            }
        }
    }

    //Add column if a column has no galaxy
    for (int i = 0; i < lines.ElementAt(0).Count; i++)
    {

        //Console.WriteLine(i);
        bool onlyDotsInColumn = true;

        for (int j = 0; j < lines.Count; j++)
        {
            if (lines.ElementAt(j).ElementAt(i) != '.')
            {
                onlyDotsInColumn = false;
            }
        }

        if (onlyDotsInColumn)
        {
            for (int j = 0; j < lines.Count; j++)
            {
                positionsOfEmpty.Add((j, i));
            }
        }


        //Console.WriteLine("Empty Position: ");
        foreach ((int, int) pos in positionsOfEmpty)
        {
            //Console.WriteLine(pos);
        }
    }
}

void getPositionOfGalaxies()
{

    //Get the positions of the Galaxies
    for (int i = 0; i < lines.Count; i++)
    {

        if (lines.ElementAt(i).Contains('#'))
        {

            for (int j = 0; j < lines.ElementAt(i).Count; j++)
            {
                if (lines.ElementAt(i).ElementAt(j) == '#')
                {
                    positionsOfGalaxies.Add((i, j));
                }
            }
        }
    }

    /*
    foreach((int,int) point in positionsOfGalaxies){
        Console.WriteLine(point.Item1+" "+point.Item2);
    }
    */

}

void calculateShortestPathsOfGalaxies()
{

    decimal sum = 0;

    for (int i = 0; i < positionsOfGalaxies.Count; i++)
    {

        for (int j = i + 1; j < positionsOfGalaxies.Count; j++)
        {
            Console.WriteLine(i + " " + j);
            //Console.WriteLine("Start: "+positionsOfGalaxies.ElementAt(i).Item1+" "+positionsOfGalaxies.ElementAt(i).Item2);
            //Console.WriteLine("End: "+positionsOfGalaxies.ElementAt(j).Item1+" "+positionsOfGalaxies.ElementAt(j).Item2);
            //Console.WriteLine(getShortestPath(positionsOfGalaxies.ElementAt(i),positionsOfGalaxies.ElementAt(j)));
            //sum+= getShortestPath(positionsOfGalaxies.ElementAt(i),positionsOfGalaxies.ElementAt(j));
            sum += getShortestPathTask2(positionsOfGalaxies.ElementAt(i), positionsOfGalaxies.ElementAt(j));
        }
        //Console.WriteLine();

    }

    Console.WriteLine("Summe: " + sum);

}

int getShortestPath((int, int) start, (int, int) end)
{


    int horizontal = Math.Abs(start.Item2 - end.Item2);
    int vertical = Math.Abs(start.Item1 - end.Item1);

    return horizontal + vertical;

}

decimal getShortestPathTask2((int, int) start, (int, int) end)
{


    int horizontal = end.Item2 - start.Item2;
    int vertical = end.Item1 - start.Item1;

    decimal addMillions = 0;

    //Console.WriteLine(horizontal + " "+ vertical);

    //Check empties of left side (columns)
    if (horizontal < 0)
    {

        for (int i = end.Item2; i < start.Item2; i++)
        {

            foreach ((int, int) e in positionsOfEmpty)
            {
                if (e.Item2 == i && e.Item1 == start.Item1)
                {
                    addMillions += 999999;
                    break;
                }
            }
        }

    }
    //Check empties of right side (columns)
    if (horizontal > 0)
    {
        for (int i = start.Item2; i < end.Item2; i++)
        {

            foreach ((int, int) e in positionsOfEmpty)
            {
                if (e.Item2 == i && e.Item1 == start.Item1)
                {
                    addMillions += 999999;
                    break;
                }
            }
        }
    }
    //Check bottom (rows)
    if (vertical > 1)
    {
        for (int i = start.Item1 + 1; i < end.Item1; i++)
        {
            int count = 0;
            foreach ((int, int) e in positionsOfEmpty)
            {
                if (e.Item1 == i)
                {
                    count++;
                }
            }
            if (count >= lines.ElementAt(0).Count)
            {
                addMillions += 999999;
            }

        }
    }

    // Console.WriteLine("Path: "+(Math.Abs(horizontal) + Math.Abs(vertical)));
    // Console.WriteLine("Shortest Path: "+(Math.Abs(horizontal) + Math.Abs(vertical) + addMillions));
    return Math.Abs(horizontal) + Math.Abs(vertical) + addMillions;

}
