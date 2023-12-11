
List<string> lines = File.ReadAllLines("data.txt").ToList();
List<List<int>> original = new List<List<int>>();


initData();
Task1();
Task2();

void initData()
{

    for (int i = 0; i < lines.Count; i++)
    {

        string[] line = lines.ElementAt(i).Split(" ");
        List<int> values = new List<int>();

        for (int j = 0; j < line.Length; j++)
        {
            int v = 0;
            if (int.TryParse(line[j] + "", out v))
            {
                values.Add(v);
            }
        }
        original.Add(values);
    }

}

void Task1()
{
    Console.WriteLine();
    Console.WriteLine("*********************************");
    Console.WriteLine("TASK 1");
    Console.WriteLine("*********************************");
    Console.WriteLine();

    decimal result = 0;

    
    foreach (var o in original)
    {
        List<int> lastDifferences = new List<int>();

        List<int> diff = o;
        bool allZero = true;

        //do while not all differences are 0
        do
        {

            allZero = true;
            List<int> newdiff = new List<int>();

            for (int i = 1; i < diff.Count; i++)
            {
                //Calculate the difference
                int d = diff.ElementAt(i) - diff.ElementAt(i - 1);

                //If one lement != 0
                if (d != 0)
                {
                    allZero = false;
                }

                newdiff.Add(d);

                //if it is the last element - add to list
                if(i == diff.Count-1){
                    lastDifferences.Add(diff.ElementAt(diff.Count - 1));
                }
            }

            diff = newdiff;

        } while (!allZero);

        int add = lastDifferences.ElementAt(lastDifferences.Count-1);

        for(int i = lastDifferences.Count-2; i >= 0; i--){
            add+= lastDifferences.ElementAt(i);
        }

        result += add;

    }

    Console.WriteLine("Result: "+result);
}



void Task2()
{
    Console.WriteLine();
    Console.WriteLine("*********************************");
    Console.WriteLine("TASK 2");
    Console.WriteLine("*********************************");
    Console.WriteLine();

    decimal result = 0;

    
    foreach (var o in original)
    {
        List<int> firstDifferences = new List<int>();

        List<int> diff = o;
        bool allZero = true;

        //do while not all differences are 0
        do
        {

            allZero = true;
            List<int> newdiff = new List<int>();

            firstDifferences.Add(diff.ElementAt(0));
                
            for (int i = 1; i < diff.Count; i++)
            {
                //Calculate the difference
                int d = diff.ElementAt(i) - diff.ElementAt(i - 1);
                
                //If one lement != 0
                if (d != 0)
                {
                    allZero = false;
                }

                newdiff.Add(d);

            }
            diff = newdiff;

        } while (!allZero);

        int add = firstDifferences.ElementAt(firstDifferences.Count-1);
        
        for(int i = firstDifferences.Count-2; i >= 0; i--){
            add = firstDifferences.ElementAt(i) - add;
        }

        result += add;

    }

    Console.WriteLine("Result: "+result);
    Console.WriteLine();
}
