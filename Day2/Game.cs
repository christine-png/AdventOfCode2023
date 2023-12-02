public class Game
{

    private int _gameId;
    public int GameId
    {
        get { return _gameId; }
        set { _gameId = value; }
    }

    private int _minRed = 0;
    public int MinRed
    {
        get { return _minRed; }
        set { _minRed = value; }
    }

    private int _minGreen = 0;
    public int MinGreen
    {
        get { return _minGreen; }
        set { _minGreen = value; }
    }
    private int _minBlue = 0;
    public int MinBlue
    {
        get { return _minBlue; }
        set { _minBlue = value; }
    }

    private bool _tooMuchRed;
    public bool TooMuchRed
    {
        get { return _tooMuchRed; }
        set { _tooMuchRed = value; }
    }

    private bool _tooMuchGreen;
    public bool TooMuchGreen
    {
        get { return _tooMuchGreen; }
        set { _tooMuchGreen = value; }
    }

    private bool _tooMuchBlue;
    public bool TooMuchBlue
    {
        get { return _tooMuchBlue; }
        set { _tooMuchBlue = value; }
    }

    public Game()
    {

    }

    public static bool TryParse(string line, out Game game)
    {

        game = new Game();



        String[] gameId = line.Split(':');
        String[] id = gameId[0].Split(" ");
        int idGame;


        if (int.TryParse(id[1], out idGame))
        {
            game.GameId = idGame;
            String[] bags = gameId[1].Split(';');

            for (int i = 0; i < bags.Length; i++)
            {

                String[] cubes = bags[i].Split(',');

                for (int j = 0; j < cubes.Length; j++)
                {

                    String[] pair = cubes[j].Split(' ');
                    int num;
                    if (int.TryParse(pair[1], out num))
                    {
                        if (pair[2] == "red")
                        {
                            if(num > 12){
                                game.TooMuchRed = true;
                            }
                            if(game.MinRed<num){
                                game.MinRed = num;
                            }

                        }
                        if (pair[2] == "blue")
                        {
                            if(num > 14){
                                game.TooMuchBlue = true;
                            }
                            if(game.MinBlue<num){
                                game.MinBlue = num;
                            }
                        }
                        if (pair[2] == "green")
                        {
                            if(num > 13){
                                game.TooMuchGreen = true;
                            }
                            if(game.MinGreen<num){
                                game.MinGreen = num;
                            }
                        }
                    }

                }

            }
        }

        return true;


    }

}