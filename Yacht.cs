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
            case YachtCategory.Twos:
                return GetNumbersScore(dice, 2);
            case YachtCategory.Threes:
                return GetNumbersScore(dice, 3);
            case YachtCategory.Fours:
                return GetNumbersScore(dice, 4);
            case YachtCategory.Fives:
                return GetNumbersScore(dice, 5);
            case YachtCategory.Sixes:
                return GetNumbersScore(dice, 6);
            case YachtCategory.FullHouse:
                return GetFullHouseScore(dice);
            case YachtCategory.FourOfAKind:
                return GetFourOfAKindScore(dice);
            case YachtCategory.LittleStraight:
                return GetStraightScore(dice, 9);
            case YachtCategory.BigStraight:
                return GetStraightScore(dice, 10);
            //case YachtCategory.Choice:
            //    break;
            case YachtCategory.Yacht:
                return GetYachtScore(dice);
            default:
                throw new ArgumentException();
        }
    }

    private static int GetStraightScore(int[] dice, int category)
    {
        var descendingDice = dice.OrderBy(x => x).ToArray();
        int[] littleStraight = { 1, 2, 3, 4, 5 };
        int[] bigStraight = { 2, 3, 4, 5, 6 };

        if (descendingDice.SequenceEqual(littleStraight) && category == 9)
        {
            return 30;
        }
        if (descendingDice.SequenceEqual(bigStraight) && category == 10)
        {
            return 30;
        }
        else
        {
            return 0;
        }

    }

    private static int GetFourOfAKindScore(int[] dice)
    {
        var groupedDice = dice.GroupBy(x => x);
        foreach (var item in groupedDice)
        {
            if (item.Count() >= 4)
            {
                {
                    return dice[0] * 4;
                }
            }
            else
            {
                continue;
            }
        }
        return 0;
    }

    private static int GetFullHouseScore(int[] dice)
    {
        var groupedDice = dice.GroupBy(x => x).ToArray();
        if (groupedDice.Count() == 2)
        {
            if (groupedDice[0].Count() == 2 || groupedDice[0].Count() == 3)
            {
                return dice.Sum(x => x);
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
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

