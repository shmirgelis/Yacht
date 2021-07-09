using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        switch (category)
        {
            case YachtCategory.Ones:
                return GetNumbersScore(dice, 1);
            //case YachtCategory.Twos:
            //    break;
            //case YachtCategory.Threes:
            //    break;
            //case YachtCategory.Fours:
            //    break;
            //case YachtCategory.Fives:
            //    break;
            //case YachtCategory.Sixes:
            //    break;
            //case YachtCategory.FullHouse:
            //    break;
            //case YachtCategory.FourOfAKind:
            //    break;
            //case YachtCategory.LittleStraight:
            //    break;
            //case YachtCategory.BigStraight:
            //    break;
            //case YachtCategory.Choice:
            //    break;
            case YachtCategory.Yacht:
                return GetYachtScore(dice);
            default:
                throw new ArgumentException();
        }
    }

    private static int GetNumbersScore(int[] dice, int diceNumber)
    {
        var orderedDice = dice.Count(x => x == diceNumber);
        return orderedDice * diceNumber;
    }

    private static int GetYachtScore(int[] dice)
    {
        var orderedDice = dice.OrderBy(x => x).ToArray();
        return orderedDice[0] == orderedDice[^1] ? 50 : 0;
    }
}

