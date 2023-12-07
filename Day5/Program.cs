using System.Security.AccessControl;
using System;
using System.Diagnostics;
using System.Threading;

String[] lines = File.ReadAllLines("data.txt");
Garden g = new Garden();
List<Seed> seeds = new List<Seed>();

initLists();
Task1();
//DO NOT RUN THIS CODE IT WILL RUN FOREVER!!!!!!!!!
//Task2();


void initLists()
{
    int list = 0;
    //init Garden with Data
    for (int i = 0; i < lines.Length; i++)
    {

        if (lines[i] != "")
        {
            decimal num = 0;
            string[] numbers = lines[i].Split(" ");

            foreach (string number in numbers)
            {

                if (decimal.TryParse(number.Replace(" ", ""), out num))
                {
                    if (list == 0)
                    {
                        g.seeds.Add(num);

                    }
                    if (list == 1)
                    {
                        g.seedToSoil.Add(num);
                    }
                    if (list == 2)
                    {
                        g.soilToFertilizer.Add(num);
                    }
                    if (list == 3)
                    {
                        g.fertilizerToWater.Add(num);
                    }
                    if (list == 4)
                    {
                        g.waterToLights.Add(num);
                    }
                    if (list == 5)
                    {
                        g.lightToTemperatures.Add(num);
                    }
                    if (list == 6)
                    {
                        g.temperatureToHumidity.Add(num);
                    }
                    if (list == 7)
                    {
                        g.humidityToLocationMap.Add(num);
                    }
                }
            }
        }
        else
        {
            list++;
        }

    }

}

void Task1()
{


    for (int i = 0; i < g.seeds.Count; i++)
    {

        decimal soilNr = g.seeds[i];
        decimal fertilizerNr = g.seeds[i];
        decimal waterNr = g.seeds[i];
        decimal lightNr = g.seeds[i];
        decimal temperatureNr = g.seeds[i];
        decimal humidityNr = g.seeds[i];
        decimal locationNr = g.seeds[i];

        //Set number of the soil
        for (int j = 0; j < g.seedToSoil.Count; j += 3)
        {
            if (soilNr >= g.seedToSoil[j + 1] && soilNr < (g.seedToSoil[j + 1] + g.seedToSoil[j + 2]))
            {
                soilNr = (g.seedToSoil[j] + (soilNr - g.seedToSoil[j + 1]));
                break;
            }
        }

        fertilizerNr = soilNr;
        //Set number of the fertilizer
        for (int j = 2; j < g.soilToFertilizer.Count; j += 3)
        {

            if (fertilizerNr < g.soilToFertilizer[j - 1] + g.soilToFertilizer[j]
                && fertilizerNr >= g.soilToFertilizer[j - 1])
            {
                fertilizerNr = (g.soilToFertilizer[j - 2] + (fertilizerNr - g.soilToFertilizer[j - 1]));
                break;
            }
        }

        waterNr = fertilizerNr;

        //Set number of the water
        for (int j = 2; j < g.fertilizerToWater.Count; j += 3)
        {

            if (waterNr < g.fertilizerToWater[j - 1] + g.fertilizerToWater[j]
                && waterNr >= g.fertilizerToWater[j - 1])
            {
                waterNr = (g.fertilizerToWater[j - 2] + (waterNr - g.fertilizerToWater[j - 1]));
                break;
            }
        }

        lightNr = waterNr;

        //Set number of the light
        for (int j = 2; j < g.waterToLights.Count; j += 3)
        {

            if (lightNr < g.waterToLights[j - 1] + g.waterToLights[j]
                && lightNr >= g.waterToLights[j - 1])
            {
                lightNr = (g.waterToLights[j - 2] + (lightNr - g.waterToLights[j - 1]));
                break;
            }
        }

        temperatureNr = lightNr;

        //Set number of the temperature
        for (int j = 2; j < g.lightToTemperatures.Count; j += 3)
        {

            if (temperatureNr < g.lightToTemperatures[j - 1] + g.lightToTemperatures[j]
                && temperatureNr >= g.lightToTemperatures[j - 1])
            {
                temperatureNr = (g.lightToTemperatures[j - 2] + (temperatureNr - g.lightToTemperatures[j - 1]));
                break;
            }
        }

        humidityNr = temperatureNr;

        //Set number of the humidity
        for (int j = 2; j < g.temperatureToHumidity.Count; j += 3)
        {

            if (humidityNr < g.temperatureToHumidity[j - 1] + g.temperatureToHumidity[j]
                && humidityNr >= g.temperatureToHumidity[j - 1])
            {
                humidityNr = (g.temperatureToHumidity[j - 2] + (humidityNr - g.temperatureToHumidity[j - 1]));
                break;
            }
        }

        locationNr = humidityNr;

        //Set number of the location
        for (int j = 2; j < g.humidityToLocationMap.Count; j += 3)
        {

            if (locationNr < g.humidityToLocationMap[j - 1] + g.humidityToLocationMap[j]
                && locationNr >= g.humidityToLocationMap[j - 1])
            {
                locationNr = (g.humidityToLocationMap[j - 2] + (locationNr - g.humidityToLocationMap[j - 1]));
                break;
            }
        }

        Seed s = new Seed(g.seeds[i], soilNr, fertilizerNr, waterNr, lightNr, temperatureNr, humidityNr, locationNr);
        seeds.Add(s);

    }


    decimal min = seeds.First().location;
    foreach (var s in seeds)
    {
        s.toString();
        if (s.location < min) min = s.location;
    }

    Console.WriteLine(min);
}































//DANGER kann kill your computer (hahahaha!)
void Task2()
{

    for (int i = 1; i < g.seeds.Count; i += 2)
    {

        for (decimal u = g.seeds[i - 1]; u < g.seeds[i-1] + g.seeds[i]; u++)
        {

            decimal soilNr = u;
            decimal fertilizerNr = u;
            decimal waterNr = u;
            decimal lightNr = u;
            decimal temperatureNr = u;
            decimal humidityNr = u;
            decimal locationNr = u;

            
            Console.WriteLine(u);


            //Set number of the soil
            for (int j = 0; j < g.seedToSoil.Count; j += 3)
            {
                if (soilNr >= g.seedToSoil[j + 1] && soilNr < (g.seedToSoil[j + 1] + g.seedToSoil[j + 2]))
                {
                    soilNr = (g.seedToSoil[j] + (soilNr - g.seedToSoil[j + 1]));
                    break;
                }
            }

            fertilizerNr = soilNr;
            //Set number of the fertilizer
            for (int j = 2; j < g.soilToFertilizer.Count; j += 3)
            {

                if (fertilizerNr < g.soilToFertilizer[j - 1] + g.soilToFertilizer[j]
                    && fertilizerNr >= g.soilToFertilizer[j - 1])
                {
                    fertilizerNr = (g.soilToFertilizer[j - 2] + (fertilizerNr - g.soilToFertilizer[j - 1]));
                    break;
                }
            }

            waterNr = fertilizerNr;

            //Set number of the water
            for (int j = 2; j < g.fertilizerToWater.Count; j += 3)
            {

                if (waterNr < g.fertilizerToWater[j - 1] + g.fertilizerToWater[j]
                    && waterNr >= g.fertilizerToWater[j - 1])
                {
                    waterNr = (g.fertilizerToWater[j - 2] + (waterNr - g.fertilizerToWater[j - 1]));
                    break;
                }
            }

            lightNr = waterNr;

            //Set number of the light
            for (int j = 2; j < g.waterToLights.Count; j += 3)
            {

                if (lightNr < g.waterToLights[j - 1] + g.waterToLights[j]
                    && lightNr >= g.waterToLights[j - 1])
                {
                    lightNr = (g.waterToLights[j - 2] + (lightNr - g.waterToLights[j - 1]));
                    break;
                }
            }

            temperatureNr = lightNr;

            //Set number of the temperature
            for (int j = 2; j < g.lightToTemperatures.Count; j += 3)
            {

                if (temperatureNr < g.lightToTemperatures[j - 1] + g.lightToTemperatures[j]
                    && temperatureNr >= g.lightToTemperatures[j - 1])
                {
                    temperatureNr = (g.lightToTemperatures[j - 2] + (temperatureNr - g.lightToTemperatures[j - 1]));
                    break;
                }
            }

            humidityNr = temperatureNr;

            //Set number of the humidity
            for (int j = 2; j < g.temperatureToHumidity.Count; j += 3)
            {

                if (humidityNr < g.temperatureToHumidity[j - 1] + g.temperatureToHumidity[j]
                    && humidityNr >= g.temperatureToHumidity[j - 1])
                {
                    humidityNr = (g.temperatureToHumidity[j - 2] + (humidityNr - g.temperatureToHumidity[j - 1]));
                    break;
                }
            }

            locationNr = humidityNr;

            //Set number of the location
            for (int j = 2; j < g.humidityToLocationMap.Count; j += 3)
            {

                if (locationNr < g.humidityToLocationMap[j - 1] + g.humidityToLocationMap[j]
                    && locationNr >= g.humidityToLocationMap[j - 1])
                {
                    locationNr = (g.humidityToLocationMap[j - 2] + (locationNr - g.humidityToLocationMap[j - 1]));
                    break;
                }
            }

            Seed s = new Seed(g.seeds[i], soilNr, fertilizerNr, waterNr, lightNr, temperatureNr, humidityNr, locationNr);
            seeds.Add(s);

        }



    }

    Console.WriteLine(seeds.Count);
    decimal min = seeds[0].location;

    foreach(var s in seeds){
        if(s.location<min){
            min = s.location;
        }
    }

    Console.WriteLine(min);


}

