String[] lines = File.ReadAllLines("data.txt");

decimal solutionTask1 = 0;
decimal solutionTask2 = 0;
Dictionary<string, decimal> save = new Dictionary<string, decimal>();

initData();
Task1();
Console.WriteLine();
Task2();



void Task1()
{
    Console.WriteLine("**************************************");
    Console.WriteLine("TASK 1");
    Console.WriteLine("**************************************");
    Console.WriteLine();
    Console.WriteLine(solutionTask1);
}

void Task2()
{
    
    Console.WriteLine("**************************************");
    Console.WriteLine("TASK 2");
    Console.WriteLine("**************************************");
    Console.WriteLine();
    Console.WriteLine(solutionTask2);
    Console.WriteLine();
}

initData();

void initData()
{
    foreach (var line in lines.Select(l => l.Split(' ')))
    {
        //read data
        String data = line[0];
        List<int> numbers = line[1].Split(',').Select(int.Parse).ToList();

        solutionTask1 += GetPossibleArrangements(data, numbers);

        //Make 5 copies of itself (unfold the records)
        //Join the 5 copies with ? inbetween (using LINQ)
        data = string.Join('?', Enumerable.Repeat(data, 5));
        //do the same with the numbers 
        numbers = Enumerable.Repeat(numbers, 5).SelectMany(g => g).ToList();

        solutionTask2 += GetPossibleArrangements(data, numbers);
    }
}


decimal GetPossibleArrangements(string data, List<int> groups)
{
    //Save pattern and its length
    String key = $"{data},{string.Join(',', groups)}";

    //Try if key was already saved
    //If saved - there is nothing to do - the result is the same
    if (save.TryGetValue(key, out var value))
    {
        return value;
    }

    //if it was not saved - get arrangments
    value = GetCount(data, groups);
    //save the value (so that you must not estimate it again)
    save[key] = value;

    return value;
}

decimal GetCount(string data, List<int> groups)
{
    while (true)
    {
        if (groups.Count == 0)
        {
            // No groups are left
            //if it still contains a # -> no match
            //if it doesn't contain a # -> match (nothing to check left)
            return data.Contains('#') ? 0 : 1; 
        }

        //if the data ran out but groups are left -> no match
        if (string.IsNullOrEmpty(data))
        {
            return 0; 
        }

        //if data starts with . -> remove . and go on
        if (data.StartsWith('.'))
        {
            data = data.Trim('.'); 
            continue;
        }

        //if data starts with ?  -> Check if there are possible arrangements that could fit
        //check for . and for #
        //1 if . matches ||1 if # matches -> recursive till the data is empty + add all results
        if (data.StartsWith('?'))
        {
            //start with index 1 of the current string
            return GetPossibleArrangements("." + data[1..], groups) + GetPossibleArrangements("#" + data[1..], groups);
        }

        //if data starts with #
        if (data.StartsWith('#')) // Start of a group
        {
            //No groups are left
            //no match because there is still a #
            if (groups.Count == 0)
            {
                return 0; 
            }

            //If the length of the data is smaller than the group
            //no match -> group does not fit
            if (data.Length < groups[0])
            {
                return 0; 
            }

            //check if the data till the length of the group contains .
            //if dots it is no match
            if (data[..groups[0]].Contains('.'))
            {
                return 0; 
            }

            //If the number of groups is higher than 1
            if (groups.Count > 1)
            {
                
                //group cannot be followed by #
                //not enough characters are left
                if (data.Length < groups[0] + 1 || data[groups[0]] == '#')
                {
                    return 0; 
                }

                // Skip the character after the group - it's a placeholder for the next group
                //continue
                data = data[(groups[0] + 1)..]; 
                groups = groups[1..];
                continue;
            }

            //last group is reached
            //it is not necessary to check the character after the group
            data = data[groups[0]..]; 
            groups = groups[1..];
            continue;
        }
    }
}