    using System.ComponentModel;
using System.Text.RegularExpressions;

public class Test{



String[] lines = File.ReadAllLines("data.txt");

public Test(){
    Task1();
}

void Task1()
{

    for (int i = 0; i < 100; i++)
    {
        //North
        slideNorth();
        //West
        rotateNegative90();
        slideNorth();
        //South
        rotateNegative90();
        slideNorth();
        //East
        rotateNegative90();
        slideNorth();

        //original position
        rotateNegative90();

    }

    Console.WriteLine(calculateTotalLoad());

}

void slideNorth()
{
    //columns
    for (decimal i = 0; i < lines[0].Length; i++)
    {
        List<char> moveUp = new List<char>();

        //from bottom to top
        for (decimal j = lines.Length - 1; j > 0; j--)
        {
            //rounded rock found
            if (lines[(int)j][(int)i] == 'O')
            {
                moveUp.Add('O');

                char[] newLine = lines[(int)j].ToCharArray();
                newLine[(int)i] = '.';
                String newString = "";
                foreach (char c in newLine)
                {
                    newString += c;
                }
                lines[(int)j] = newString;
            }

            //cube rock found in the previous line
            if (lines[(int)j - 1][(int)i] == '#')
            {

                if (moveUp.Count > 0)
                {
                    setONorth(j, moveUp, i);
                    moveUp.Clear();

                }
            }

            if (j - 1 == 0)
            {
                if (moveUp.Count > 0)
                {
                    if (lines[(int)j - 1][(int)i] != '.')
                    {
                        setONorth(j, moveUp, i);
                        moveUp.Clear();
                    }
                    else
                    {
                        setONorth(j - 1, moveUp, i);
                        moveUp.Clear();
                    }
                }
            }

        }
    }

}

void rotate90()
{

    List<string> rotated = new List<string>();


    List<string> columns = new List<string>();

    //columns
    for (int i = 0; i < lines[0].Length; i++)
    {

        String col = "";

        //rows
        for (int j = 0; j < lines.Length; j++)
        {
            col += lines[j][i];
        }

        columns.Add(col);

    }

    for (int i = lines.Length - 1; i >= 0; i--)
    {
        lines[i] = columns[lines.Length - 1 - i];
    }
}

void rotateNegative90()
{

    List<string> rotated = new List<string>();


    List<string> columns = new List<string>();

    //columns
    for (int i = lines[0].Length - 1; i >= 0; i--)
    {

        String col = "";

        //rows
        for (int j = 0; j < lines.Length; j++)
        {
            col = lines[j][i] + col;
        }

        columns.Add(col);

    }

    for (int i = lines.Length - 1; i >= 0; i--)
    {
        lines[i] = columns[lines.Length - 1 - i];
    }
}



decimal calculateTotalLoad()
{

    decimal load = 0;
    //column
    for (decimal i = 0; i < lines[0].Length; i++)
    {

        decimal rocksOnPath = 0;

        //rows
        for (decimal j = lines.Length - 1; j >= 0; j--)
        {

            if (lines[(int)j][(int)i] == 'O')
            {
                load += lines.Length - j;
            }

            if (lines[(int)j][(int)i] == '#')
            {
                rocksOnPath++;
            }

        }

    }

    return load;
}

void setONorth(decimal start, List<char> moveUp, decimal column)
{
    //row
    for (decimal k = start; moveUp.Count > 0; k++)
    {
        char[] newLine = lines[(int)k].ToCharArray();
        newLine[(int)column] = 'O';
        String newString = "";
        foreach (char c in newLine)
        {
            newString += c;
        }
        lines[(int)k] = newString;
        moveUp.RemoveAt(moveUp.Count - 1);
    }

}

void setOWest(int start, List<char> moveLeft, int row)
{



}

}