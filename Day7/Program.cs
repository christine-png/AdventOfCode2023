
String[] lines = File.ReadAllLines("data.txt");
List<Card> cards = new List<Card>();

Task1();

void Task1(){

    for (int i = 0; i < lines.Length; i++)
    {

        string hand = lines[i].Split(" ")[0];
        int value = int.Parse(lines[i].Split(" ")[1]);
        cards.Add(new Card(hand, value));

        Dictionary<char, int> numOfSameElements = new Dictionary<char, int>();


        int max = 1;
        //List of cards and their appearance
        foreach (char c in cards.ElementAt(i).hand.ToCharArray())
        {

            if (numOfSameElements.ContainsKey(c))
            {
                numOfSameElements[c] = numOfSameElements[c] + 1;
                if (numOfSameElements[c] > max)
                {
                    max = numOfSameElements[c];
                }

            }
            else
            {
                numOfSameElements.Add(c, 1);
            }
        }

        cards.ElementAt(i).max = max;

        if (max == 5)
        {
            cards.ElementAt(i).type = Type.fiveOfAKind;
        }
        else if (max == 4)
        {
            cards.ElementAt(i).type = Type.fourOfAKind;
        }
        else if (max == 3 && numOfSameElements.Count == 2)
        {
            cards.ElementAt(i).type = Type.fullHouse;
        }
        else if (max == 3)
        {
            cards.ElementAt(i).type = Type.threeOfAKind;
        }
        else if (max == 1)
        {
            cards.ElementAt(i).type = Type.highCard;
        }
        else if (max == 2 && numOfSameElements.Count == 4)
        {
            cards.ElementAt(i).type = Type.onePair;
        }
        else if (max == 2 && numOfSameElements.Count == 3)
        {
            cards.ElementAt(i).type = Type.twoPair;
        }

    }

    //cards[2].CompareTo(cards[3]);

    cards.Sort();

    decimal result = 0;

    for(int i = cards.Count-1; i >=0; i--){

        //Console.WriteLine((cards.Count-i)+" "+cards.ElementAt(i).toString());
        result+= (cards.Count-i)*cards.ElementAt(i).value;

    }

    Console.WriteLine($"Result: {result}");

}