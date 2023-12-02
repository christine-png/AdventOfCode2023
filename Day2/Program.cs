
String[] lines = File.ReadAllLines("text.txt");



int sumIds = 0;
int sumPower = 0;

for (int i = 0; i < lines.Length; i++)
{
    

    Game game;
    if (Game.TryParse(lines[i], out game))
    {

        if (!(game.TooMuchGreen || game.TooMuchRed || game.TooMuchBlue))
        {
            sumIds += game.GameId;
            //Console.WriteLine($"{game.GameId}: Red: {game.MinRed} Blue: {game.MinBlue} Green: {game.MinGreen}");
            
        }

        int power = game.MinRed * game.MinGreen * game.MinBlue;
            sumPower += power;

    }

}

Console.WriteLine("Summe der Ids " + sumIds);
Console.WriteLine("Summe der Power " + sumPower);