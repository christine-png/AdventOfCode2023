using System.Runtime.InteropServices.Marshalling;
using System.Windows.Markup;

public class Card : IComparable<Card>
{


    public string hand = "";
    public int value = 0;

    public int max = 1;

    //Task1
    //private Type _type;

    //Task2()
    private Type _type;
    public Type type
    {
        //getter and setter for Task2
        set
        {
            if (hand.Contains('J'))
            {
                int numOfJ = 0;
                for (int i = 0; i < hand.Length; i++)
                {
                    if (hand[i] == 'J')
                    {
                        numOfJ++;
                    }
                }
                Console.WriteLine("Contains J: " + hand + " Max: " + max + " NumOfJ: " + numOfJ + " Type: " + value);

                if (value == Type.onePair)
                {
                    if (numOfJ == 1)
                    {
                        _type = Type.threeOfAKind;
                    }
                    if (numOfJ == 2)
                    {
                        _type = Type.threeOfAKind;
                    }
                    

                }
                else if (value == Type.twoPair)
                {
                    if (numOfJ == 1)
                    {
                        _type = Type.fullHouse;
                    }
                    if (numOfJ == 2)
                    {
                        _type = Type.fourOfAKind;
                    }

                }
                else if (value == Type.fullHouse)
                {
                    if (numOfJ == 1)
                    {
                        _type = Type.fourOfAKind;
                    }
                    if (numOfJ == 2)
                    {
                        _type = Type.fiveOfAKind;
                    }

                }
                else if (value == Type.fourOfAKind)
                {
                    _type = Type.fiveOfAKind;

                }
                else if (value == Type.threeOfAKind)
                {
                    if (numOfJ == 1)
                    {
                        _type = Type.fourOfAKind;
                    }
                    if(numOfJ == 3){
                        _type = Type.fourOfAKind;
                    }
                }
                else if (value == Type.highCard)
                {
                    if(numOfJ == 1){
                        _type = Type.onePair;
                    }
                }

            }
            else
            {
                _type = value;
            }

            if(hand.Contains('J')){
                Console.WriteLine(hand+" New Type: "+_type);
            }
            
        }
        get
        {
            return _type;
        }
    }

    Dictionary<char, int> cardValue = new Dictionary<char, int>();


    public Card(string hand, int value)
    {
        this.hand = hand;
        this.value = value;

        //Task1
        /*
        cardValue.Add('A', 0);
        cardValue.Add('K', 1);
        cardValue.Add('Q', 2);
        cardValue.Add('J', 3);
        cardValue.Add('T', 4);
        cardValue.Add('9', 5);
        cardValue.Add('8', 6);
        cardValue.Add('7', 7);
        cardValue.Add('6', 8);
        cardValue.Add('5', 9);
        cardValue.Add('4', 10);
        cardValue.Add('3', 11);
        cardValue.Add('2', 12);
        */

        //Task2
        //J is now a Jocker and can act as any card
        //J is now the lowest individual card
        cardValue.Add('A', 0);
        cardValue.Add('K', 1);
        cardValue.Add('Q', 2);
        cardValue.Add('T', 3);
        cardValue.Add('9', 4);
        cardValue.Add('8', 5);
        cardValue.Add('7', 6);
        cardValue.Add('6', 7);
        cardValue.Add('5', 8);
        cardValue.Add('4', 9);
        cardValue.Add('3', 10);
        cardValue.Add('2', 11);
        cardValue.Add('J', 12);
    }

    /*
       -1 means that the object is less worth than the other
        1 means that the object is more worth than the other
        0 means that the objects hand is equal to the other
    */
    public int CompareTo(Card? other)
    {
        if (this.hand == other.hand)
        {
            return 0;
        }

        if (this.type == other.type)
        {

            for (int i = 0; i < hand.Length; i++)
            {
                // current card has a higher rank
                if (cardValue[hand[i]] < other.cardValue[other.hand[i]])
                {
                    return -1;
                }
                // current card has a lower rank
                else if (cardValue[hand[i]] > other.cardValue[other.hand[i]])
                {
                    return 1;
                }
            }
            return 1;

        }
        else
        {
            if (this.type == Type.onePair && other.type == Type.highCard)
            {
                return -1;
            }
            if (this.type == Type.twoPair && (other.type == Type.highCard || other.type == Type.onePair))
            {
                return -1;
            }
            if (this.type == Type.fullHouse && other.type != Type.fiveOfAKind && other.type != Type.fourOfAKind)
            {
                return -1;
            };
            if (this.type == Type.fiveOfAKind)
            {
                return -1;
            };
            if (this.type == Type.fourOfAKind && other.type != Type.fiveOfAKind)
            {
                return -1;
            };
            if (this.type == Type.threeOfAKind && (other.type == Type.twoPair || other.type == Type.onePair || other.type == Type.highCard))
            {
                return -1;
            };
            return 1;

        }
    }

    public string toString()
    {

        string t = "";
        if (this.type == Type.onePair) { t = "One Pair"; };
        if (this.type == Type.twoPair) { t = "Two Pair"; };
        if (this.type == Type.fullHouse) { t = "Full House"; };
        if (this.type == Type.fiveOfAKind) { t = "Five of a Kind"; };
        if (this.type == Type.fourOfAKind) { t = "Four of a Kind"; };
        if (this.type == Type.threeOfAKind) { t = "three of a Kind"; };
        if (this.type == Type.highCard) { t = "High card"; };

        return $"hand: {hand} value: {value} type: {t}";
    }
}

