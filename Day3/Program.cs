

using System.Collections;
using System.Diagnostics.CodeAnalysis;

String[] lines = File.ReadAllLines("data.txt");


#region task1
String[] symbols = new string[10];
symbols[0] = "*";
symbols[1] = "#";
symbols[2] = "+";
symbols[3] = "$";
symbols[4] = "&";
symbols[5] = "=";
symbols[6] = "@";
symbols[7] = "-";
symbols[8] = "%";
symbols[9] = "/";

int sum = 0;

for (int row = 0; row < lines.Length; row++)
{

    bool hasSymbol = false;
    string numberChain = "";
    for (int column = 0; column < lines[row].Length; column++)
    {
        int number = 0;
        if (int.TryParse(lines[row][column] + "", out number))
        {
            //prevent OutOfRangeException
            int minRow = row - 1 > 0 ? row - 1 : 0;
            int maxRow = row + 1 < lines.Length ? row + 1 : lines.Length - 1;
            int minColumn = column - 1 > 0 ? column - 1 : 0;
            int maxColumn = column + 1 < lines[row].Length ? column + 1 : lines[row].Length - 1;


            foreach (var symbol in symbols)
            {
                //look for surrounding symbols
                if (
                    lines[minRow][minColumn] + "" == symbol
                    || lines[minRow][column] + "" == symbol
                    || lines[minRow][maxColumn] + "" == symbol
                    || lines[row][minColumn] + "" == symbol
                    || lines[row][maxColumn] + "" == symbol
                    || lines[maxRow][minColumn] + "" == symbol
                    || lines[maxRow][column] + "" == symbol
                    || lines[maxRow][maxColumn] + "" == symbol
                )
                {
                    hasSymbol = true; 
                    break;  
                }
            }


            numberChain = numberChain + number;

            if (column == lines[row].Length - 1 && hasSymbol)
            {
                sum += int.Parse(numberChain);
            }
        }
        else
        {
            if (numberChain != "" && hasSymbol)
            {
                sum += int.Parse(numberChain);
                hasSymbol = false;
            }
            numberChain = "";
        }

    }
}

Console.WriteLine(sum);

#endregion

#region task2

sum = 0;

for (int row = 0; row < lines.Length; row++)
{

    for (int column = 0; column < lines[row].Length; column++)
    {

        if (lines[row][column] == '*')
        {
                List<int> foundNumbers = new List<int>();


                int minRow = row - 1 > 0 ? row - 1 : 0;
                int maxRow = row + 1 < lines.Length ? row + 1 : lines.Length - 1;
                int minColumn = column - 1 > 0 ? column - 1 : 0;
                int maxColumn = column + 1 < lines[row].Length ? column + 1 : lines[row].Length - 1;

                int foundNumber = 0;

                if (isNumber(minRow, column, out foundNumber))
                {
                    foundNumbers.Add(foundNumber);
                }
                else
                {
                    if (isNumber(minRow, minColumn, out foundNumber))
                    {
                        foundNumbers.Add(foundNumber);
                    }

                    if (isNumber(minRow, maxColumn, out foundNumber))
                    {
                        foundNumbers.Add(foundNumber);
                    }
                }


                if (isNumber(row, minColumn, out foundNumber))
                {
                    foundNumbers.Add(foundNumber);
                }
                if (isNumber(row, maxColumn, out foundNumber))
                {
                    foundNumbers.Add(foundNumber);
                }

                if (isNumber(maxRow, column, out foundNumber))
                {
                    foundNumbers.Add(foundNumber);
                }
                else
                {
                    if (isNumber(maxRow, minColumn, out foundNumber))
                    {
                        foundNumbers.Add(foundNumber);
                    }

                    if (isNumber(maxRow, maxColumn, out foundNumber))
                    {
                        foundNumbers.Add(foundNumber);
                    }
                }


                if (foundNumbers.Count == 2)
                {
                    sum += foundNumbers.First()*foundNumbers.ElementAt(1);
                }
        }

    }

}

Console.WriteLine(sum);

bool isNumber(int row, int column, out int number)
{

    number = 0;
    String numberChain = "";

    int num = 0;
    if (int.TryParse(lines[row][column] + "", out num))
    {
        numberChain = num + "";
        //Console.WriteLine(numberChain);
        if (column - 1 > 0)
        {
            if (int.TryParse(lines[row][column - 1] + "", out num))
            {
                numberChain = num + numberChain;
                //Console.WriteLine(numberChain);
                if (column - 2 >= 0)
                {
                    if (int.TryParse(lines[row][column - 2] + "", out num))
                    {
                        numberChain = num + numberChain;
                        //Console.WriteLine(numberChain);
                    }
                }
            }

        }
        if (column + 1 < lines[row].Length)
        {
            if (int.TryParse(lines[row][column + 1] + "", out num))
            {
                numberChain = numberChain + num;
                if (column + 2 < lines[row].Length)
                {
                    if (int.TryParse(lines[row][column + 2] + "", out num))
                    {
                        numberChain = numberChain + num;
                    }
                }
            }

        }

        number = int.Parse(numberChain);

        return true;
    }
    else
    {
        return false;
    }

}



#endregion


