using System.Reflection.PortableExecutable;

String[] lines = File.ReadAllLines("data.txt");

initData();


void initData()
{
    decimal solutionTask1 = 0;
    decimal solutionTask2 = 0;
    List<String> pattern = new List<string>();

    foreach (String line in lines)
    {
        if (line == "")
        {
            solutionTask1 += findSymmetricalPattern(pattern);
            solutionTask2 += findSymmetricalPatternTask2(pattern);
            pattern = new List<string>();
        }
        else
        {
            pattern.Add(line);
        }

    }

    if (pattern.Count != 0)
    {
        solutionTask1 += findSymmetricalPattern(pattern);
        solutionTask2 += findSymmetricalPatternTask2(pattern);
    }


    Console.WriteLine("\nTask 1:");
    Console.WriteLine(solutionTask1);
    Console.WriteLine("--------------------");
    Console.WriteLine("Task 2:");
    Console.WriteLine(solutionTask2+"\n");

}



#region  Task1

decimal findSymmetricalPattern(List<String> pattern)
{

    int x = 0;
    int y = 0;
    int numOfSymmetry = 0;

    decimal result = 0;

    if (findHorizontalPattern(pattern, out y, out numOfSymmetry))
    {

        //Console.WriteLine("Horizontal pattern found: " + y);
        //Console.WriteLine("Number of symmetry found: " + numOfSymmetry);
        result += 100 * numOfSymmetry;

    }
    else if (findVerticalPattern(pattern, out x, out numOfSymmetry))
    {
        //Console.WriteLine("Vertical pattern found: " + x);
        //Console.WriteLine("Number of symmetry found: " + numOfSymmetry);
        result += numOfSymmetry;
    }

    return result;

}

//y +1 is the second same pattern as y
bool findHorizontalPattern(List<String> pattern, out int y, out int numOfSymmetry)
{

    y = 0;
    numOfSymmetry = 0;

    for (int i = 1; i < pattern.Count; i++)
    {

        if (pattern[i - 1] == pattern[i])
        {
            y = i - 1;

            if (isSymmetricalHorizontalPattern(out numOfSymmetry, pattern, y))
            {
                return true;
            }
            else
            {
                continue;
            }
        }

    }
    return false;

}

bool isSymmetricalHorizontalPattern(out int numOfSymmetry, List<String> pattern, int y)
{

    //y+1 is symmetric to y

    int pos = y - 1;
    numOfSymmetry = 0;

    //rows
    for (int i = y + 2; i < pattern.Count; i++)
    {

        if (pos >= 0)
        {
            if (pattern[i] != pattern[pos])
            {
                return false;
            }
            pos -= 1;
        }
        else
        {
            break;
        }
    }

    numOfSymmetry = pattern.Count - (pattern.Count - (y + 1));
    return true;

}



bool findVerticalPattern(List<String> pattern, out int x, out int numOfSymmetry)
{

    x = 0;
    numOfSymmetry = 0;

    //column
    for (int i = 1; i < pattern[0].Length; i++)
    {

        bool equal = true;

        //row
        for (int j = 0; j < pattern.Count; j++)
        {
            if (pattern[j][i - 1] != pattern[j][i])
            {
                equal = false;
                break;
            }
        }

        if (equal)
        {
            x = i - 1;

            if (isSymmetricalVerticalPattern(out numOfSymmetry, pattern, x))
            {
                return true;
            }
            else
            {
                continue;
            }

        }

    }

    return false;

}

bool isSymmetricalVerticalPattern(out int numOfSymmetry, List<String> pattern, int x)
{

    //x+1 is symmetric to x

    int pos = x - 1;
    bool equal = true;
    numOfSymmetry = 0;

    //columns in right hand side
    for (int i = x + 2; i < pattern[0].Count(); i++)
    {

        if (pos >= 0)
        {
            //rows
            for (int j = 0; j < pattern.Count(); j++)
            {
                if (pattern[j][i] != pattern[j][pos])
                {
                    return false;
                }
            }
            pos -= 1;

        }
        else
        {
            break;
        }
    }

    if (equal)
    {
        numOfSymmetry = pattern[0].Length - (pattern[0].Length - (x + 1));
        return true;
    }
    return false;

}

#endregion

//exactly one smudge
#region Task2

decimal findSymmetricalPatternTask2(List<String> pattern)
{

    int x = 0;
    int y = 0;
    int numOfSymmetry = 0;

    decimal result = 0;

    if (findHorizontalPatternTask2(pattern, out y, out numOfSymmetry))
    {

        //Console.WriteLine("Horizontal pattern found: " + y);
        //Console.WriteLine("Number of symmetry found: " + numOfSymmetry);
        result += 100 * numOfSymmetry;

    }
    else if (findVerticalPatternTask2(pattern, out x, out numOfSymmetry))
    {
        //Console.WriteLine("Vertical pattern found: " + x);
        //Console.WriteLine("Number of symmetry found: " + numOfSymmetry);
        result += numOfSymmetry;
    }

    return result;

}

bool findHorizontalPatternTask2(List<String> pattern, out int y, out int numOfSymmetry)
{

    y = 0;
    numOfSymmetry = 0;

    //row
    for (int i = 1; i < pattern.Count; i++)
    {
        //if the pattern is completely equal
        //There must be one mistake in the symmetry
        if (pattern[i - 1] == pattern[i])
        {
            y = i - 1;

            if (isSymmetricalHorizontalPatternTask2(out numOfSymmetry, pattern, y))
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        //search for exactly one mistake
        //there should be no mistake in the symmetry
        else
        {

            int numOfDifferentChars = 0;
            //column    
            for (int j = 0; j < pattern[0].Length; j++)
            {

                if (pattern[i - 1][j] != pattern[i][j])
                {
                    numOfDifferentChars += 1;
                }
                //more than 1 different char
                if (numOfDifferentChars > 1)
                {
                    break;
                }
            }

            //if there is exactly one different char
            if (numOfDifferentChars == 1)
            {
                y = i - 1;

                //reuse Method from Task1
                if (isSymmetricalHorizontalPattern(out numOfSymmetry, pattern, y))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

        }

    }
    return false;

}

//checks if in the symmetry is one mistake
bool isSymmetricalHorizontalPatternTask2(out int numOfSymmetry, List<String> pattern, int y)
{

    //y+1 is symmetric to y

    int pos = y - 1;
    numOfSymmetry = 0;

    int numOfDifferentChars = 0;

    //rows
    for (int i = y + 2; i < pattern.Count; i++)
    {

        if (pos >= 0)
        {
            if (pattern[i] != pattern[pos])
            {
                //columns
                for (int j = 0; j < pattern[0].Count(); j++)
                {
                    if (pattern[i][j] != pattern[pos][j])
                    {
                        numOfDifferentChars += 1;
                    }
                    if (numOfDifferentChars > 1)
                    {
                        return false;
                    }
                }

            }

            pos -= 1;
        }
        else
        {
            break;
        }
    }


    if (numOfDifferentChars == 1)
    {
        numOfSymmetry = pattern.Count - (pattern.Count - (y + 1));
        return true;
    }
    return false;


}

bool findVerticalPatternTask2(List<String> pattern, out int x, out int numOfSymmetry)
{

    x = 0;
    numOfSymmetry = 0;



    //column
    for (int i = 1; i < pattern[0].Length; i++)
    {
        int numOfDifferentChars = 0;
        //row
        for (int j = 0; j < pattern.Count; j++)
        {
            if (pattern[j][i - 1] != pattern[j][i])
            {
                numOfDifferentChars += 1;
            }
        }


        //if the pattern is completely equal
        //There must be one mistake in the symmetry
        if (numOfDifferentChars == 0)
        {
            x = i - 1;

            if (x == 0)
            {
                continue;
            }

            if (isSymmetricalVerticalPatternTask2(out numOfSymmetry, pattern, x))
            {
                return true;
            }
            else
            {
                continue;
            }

        }
        if (numOfDifferentChars == 1)
        {

            x = i - 1;

            if (isSymmetricalVerticalPattern(out numOfSymmetry, pattern, x))
            {
                return true;
            }
            else
            {
                continue;
            }

        }

    }

    return false;

}

//checks if in the symmetry is one mistake
bool isSymmetricalVerticalPatternTask2(out int numOfSymmetry, List<String> pattern, int x)
{

    //x+1 is symmetric to x

    int pos = x - 1;
    numOfSymmetry = 0;

    int numOfDifferentChars = 0;

    //columns in right hand side
    for (int i = x + 2; i < pattern[0].Count(); i++)
    {

        if (pos >= 0)
        {
            //rows
            for (int j = 0; j < pattern.Count(); j++)
            {
                if (pattern[j][i] != pattern[j][pos])
                {
                    numOfDifferentChars += 1;
                }

                if (numOfDifferentChars > 1)
                {
                    return false;
                }
            }
            pos -= 1;


        }
        else
        {
            break;
        }
    }

    if (numOfDifferentChars == 1)
    {
        numOfSymmetry = pattern[0].Length - (pattern[0].Length - (x + 1));
        return true;
    }

    return false;

}

#endregion
