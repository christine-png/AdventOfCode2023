
Race race = new Race();
//initDataTask1();
initDataTask2();
//Task1();
Task2();

void initDataTask1()
{
    String[] lines = File.ReadAllLines("data.txt");
    String[] times = lines[0].Split(" ");
    String[] distance = lines[1].Split(" ");

    for (int i = 0; i < times.Length; i++)
    {
        int time = 0;
        if (int.TryParse(times[i], out time))
        {
            race.times.Add(time);
            //Console.WriteLine("Time: " + time);
        }
    }

    for (int i = 0; i < distance.Length; i++)
    {
        int dist = 0;
        if (int.TryParse(distance[i], out dist))
        {
            race.distance.Add(dist);
            //Console.WriteLine("Distance: " + distance[i]);
        }
    }
}

void initDataTask2()
{
    String[] lines = File.ReadAllLines("data.txt");
    String times = lines[0].Split(":")[1].Replace(" ","");
    String distance = lines[1].Split(":")[1].Replace(" ","");

    decimal time = 0;
    if(decimal.TryParse(times, out time)){
        race.time = time;
    }

    decimal dist = 0;
    if(decimal.TryParse(distance, out dist)){
        race.dist = dist;
    }

}


void Task1()
{
    Console.WriteLine(race.times.ElementAt(0));
    Console.WriteLine(race.distance.ElementAt(0));

    int result = 1;
    

    for (int i = 0; i < race.times.Count; i++)
    {
        int first = 0;
        int last = 0;

        int count = 0;

        if (race.distance.ElementAt(i) != 0)
        {

            for (int j = 1; j < race.times.ElementAt(i); j++)
            {

                int timeLeft = race.times.ElementAt(i) - j;
                int distanceTraveled = timeLeft * (race.times.ElementAt(i) - timeLeft);
                int mod = distanceTraveled % race.distance.ElementAt(i);

                if (mod != 0)
                {
                    int diff = distanceTraveled - mod;

                    if (diff == race.distance.ElementAt(i))
                    {
                        count++;
                        if(first == 0){
                            first = j;
                        }
                        last = j;
                    }
                }


            }

        }

        Console.WriteLine(last-first+1);

        //result Task2
        result*=count;

    }

    //restult Task1
    Console.WriteLine(result);

}


void Task2()
{
        decimal first = 0;
        decimal last = 0;

        if (race.dist != 0)
        {

            int u = 1;
            for (decimal j = 1; j < race.time; j+=1*u)
            {
                

                decimal timeLeft = race.time - j;
                decimal distanceTraveled = timeLeft * (race.time - timeLeft);
                decimal mod = distanceTraveled % race.dist;

                    decimal diff = distanceTraveled - mod;

                    if (diff == race.dist)
                    {
                        if(first == 0){
                            first = j;
                            u = -1;
                            j = race.time-1;
                        }
                        if(last == 0){
                            last = j;
                            break;
                        }
                    }
            }
        }
         Console.WriteLine("Last: "+(last-first+1));
         Console.WriteLine("First: "+first);
         Console.WriteLine("Result: "+((last-2*first+2*1)));

}

