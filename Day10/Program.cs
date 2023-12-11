
String[] lines = File.ReadAllLines("data.txt");

Dictionary<int, List<int>> pointsOnPath = new Dictionary<int, List<int>>();

initDictionary();

Console.WriteLine();
Task1();
Console.WriteLine();
Task2();

void initDictionary()
{

    for (int i = 0; i < lines.Length; i++)
    {
        pointsOnPath.Add(i, new List<int>());
    }

}

void Task2()
{


    for (int i = 0; i < pointsOnPath.Count; i++)
    {

        for (int j = 0; j < pointsOnPath[i].Count; j++)
        {
            //Console.WriteLine(i+" "+pointsOnPath[i].ElementAt(j));
        }
        //Console.WriteLine("Length of line "+i+" "+pointsOnPath[i].Count);
    }

    //Sort points on path
    for (int i = 0; i < pointsOnPath.Count; i++)
    {
        pointsOnPath[i].Sort();
    }

    int count = 0;
    


    // Find gaps between the path
    for (int i = 0; i < lines.Length; i++)
    {
        bool inBetween = false;
        char previous = '*';

        for (int j = 0; j < lines[i].Length; j++)
        {
            char s = lines[i][j];

            if(s!='.' && s != '-' && pointsOnPath[i].Contains(j)){

                if(s == '|'){
                    inBetween = !inBetween;
                }

                if(s == 'L'){
                    previous = 'L';
                }
                if(s == 'F'){
                    previous = 'F';
                }
                if(s == 'S'){
                    previous = '7';
                }

                if(previous == 'L' && s == '7'){
                    inBetween = !inBetween;
                }
                if(previous == 'F'  && s == 'J'){
                    inBetween = !inBetween;
                }
                
            }
            if(inBetween){
                if(lines[i][j] == '.'){
                    count ++;
                    //Console.WriteLine(i+" "+j);
                }else{
                    if(!pointsOnPath[i].Contains(j)){
                        Console.WriteLine(i+" "+j);
                        count++;
                    }
                }  
            }
        }
    }

    Console.WriteLine();
    Console.WriteLine(count);

}

void Task1()
{
    /*
    Console.WriteLine("Input:");
    Console.WriteLine();
    foreach (var l in lines)
    {
        foreach (var i in l)
        {
            Console.Write(i);
        }
        Console.WriteLine();
    }
    */

    //Find Start
    int startRow = 0;
    int startCol = 0;
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            if (lines[i][j] == 'S')
            {
                startRow = i;
                startCol = j;
                break;
            }
        }
        if (startRow != 0)
        {
            break;
        }
    }

    //Console.WriteLine();
    //Console.WriteLine("Start position: " + startRow + " " + startCol);
    //Console.WriteLine();



    //to save the start points
    int row1 = 0;
    int col1 = 0;
    int row2 = 0;
    int col2 = 0;

    int startR = startRow;
    int startC = startCol;

    //Find start
    getStartPoints(startRow, startCol, out row1, out col1, out row2, out col2);

    //Console.WriteLine("Start 1: " + row1 + " " + col1);
    //Console.WriteLine("Start 2: " + row2 + " " + col2);


    int nextRow = 0;
    int nextCol = 0;

    int steps1 = 1;

    while (true)
    {
        pointsOnPath[row1].Add(col1);

        getNextPosition(startRow, startCol, row1, col1, out nextRow, out nextCol);
        startRow = row1;
        startCol = col1;

        row1 = nextRow;
        col1 = nextCol;

        if (startRow == startR && startCol == startC)
        {
            break;
        }

        steps1++;

    }

    Console.WriteLine("Steps: " + steps1 / 2);


    //Test 1
    /*
    getNextPosition(startRow, startCol, row1, col1, out nextRow, out nextCol);
    getNextPosition(row1, col1, nextRow, nextCol, out row1, out col1);
    getNextPosition(nextRow, nextCol, row1, col1, out nextRow, out nextCol);
    getNextPosition(row1, col1, nextRow, nextCol, out row1, out col1);
    getNextPosition(nextRow, nextCol, row1, col1, out nextRow, out nextCol);
    getNextPosition(row1, col1, nextRow, nextCol, out row1, out col1);
    getNextPosition(nextRow, nextCol, row1, col1, out nextRow, out nextCol);
    */

    //Test2
    /*
    getNextPosition(startRow, startCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    getNextPosition(row2, col2, nextRow, nextCol, out row2, out col2);
    getNextPosition(nextRow, nextCol, row2, col2, out nextRow, out nextCol);
    */
}

void getStartPoints(int row, int col, out int row1, out int col1, out int row2, out int col2)
{
    row1 = 0;
    row2 = 0;
    col1 = 0;
    col2 = 0;

    int minRow = row - 1 >= 0 ? row - 1 : row;
    int maxRow = row + 1 < lines.Length ? row + 1 : row;
    int minCol = col - 1 >= 0 ? col - 1 : col;
    int maxCol = col + 1 < lines[row].Length ? col + 1 : col;

    //Check the possibilities one row before
    if (lines[minRow][col] == '|' || lines[minRow][col] == '7' || lines[minRow][col] == 'F')
    {
        if (row1 == 0 && col1 == 0)
        {
            row1 = minRow;
            col1 = col;
        }
        else
        {
            row2 = minRow;
            col2 = col;
        }
    }

    //Check the possibilities on row after
    if (lines[maxRow][col] == '|' || lines[maxRow][col] == 'L' || lines[maxRow][col] == 'J')
    {
        if (row1 == 0 && col1 == 0)
        {
            row1 = maxRow;
            col1 = col;
        }
        else
        {
            row2 = maxRow;
            col2 = col;
        }
    }

    //Check the possibilities one column before
    if (lines[row][minCol] == '-' || lines[row][minCol] == 'F' || lines[row][minCol] == 'L')
    {
        if (row1 == 0 && col1 == 0)
        {
            row1 = row;
            col1 = minCol;
        }
        else
        {
            row2 = row;
            col2 = minCol;
        }
    }

    //Check the possibilities one column after
    if (lines[row][maxCol] == '-' || lines[row][maxCol] == '7' || lines[row][maxCol] == 'J')
    {
        if (row1 == 0 && col1 == 0)
        {
            row1 = row;
            col1 = maxCol;
        }
        else
        {
            row2 = row;
            col2 = maxCol;
        }
    }
}

void getNextPosition(int rowBefore, int colBefore, int row, int col, out int nextRow, out int nextCol)
{

    int minRow = row - 1 >= 0 ? row - 1 : row;
    int maxRow = row + 1 < lines.Length ? row + 1 : row;
    int minCol = col - 1 >= 0 ? col - 1 : col;
    int maxCol = col + 1 < lines[row].Length ? col + 1 : col;

    nextRow = row;
    nextCol = col;

    //If the element was in the next row
    if (rowBefore > row)
    {
        if (lines[row][col] == '|')
        {
            nextRow--;
        }
        else if (lines[row][col] == '7')
        {
            nextCol--;
        }
        else if (lines[row][col] == 'F')
        {
            nextCol++;
        }
    }

    //If the element was in the previous row
    if (rowBefore < row)
    {
        if (lines[row][col] == '|')
        {
            nextRow++;
        }
        else if (lines[row][col] == 'J')
        {
            nextCol--;
        }
        else if (lines[row][col] == 'L')
        {
            nextCol++;
        }
    }

    //If the element was on the left side of the current
    if (colBefore < col)
    {
        if (lines[row][col] == '-')
        {
            nextCol++;
        }
        else if (lines[row][col] == 'J')
        {
            nextRow--;
        }
        else if (lines[row][col] == '7')
        {
            nextRow++;
        }
    }

    if (colBefore > col)
    {
        if (lines[row][col] == '-')
        {
            nextCol--;
        }
        else if (lines[row][col] == 'F')
        {
            nextRow++;
        }
        else if (lines[row][col] == 'L')
        {
            nextRow--;
        }
    }

    //Console.WriteLine(nextRow+" "+nextCol);

}