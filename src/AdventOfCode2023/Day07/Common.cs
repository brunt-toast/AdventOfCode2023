namespace AdventOfCode2023.Day07
{
    internal static class Common
    {
        private static int GetCardStrength(char c) =>
            "23456789TJQKA".IndexOf(c) + 1;

        internal enum HandType // enumeration value corresponds to hand strength. 
        {
            FiveOfAKind = 6, // 1 distinct card
            FourOfAKind = 5, // 2 distinct cards, 4 + 1
            FullHouse = 4, // 2 distinct cards, 1 group (others must be same) 
            ThreeOfAKind = 3, // 2 distinct cards, 1 group (others must be different) 
            TwoPair = 2, // 3 distinct cards, 2 groups
            OnePair = 1, // 4 distinct cards, 1 group
            HighCard = 0 // 5 distinct cards, no groups
        }

        internal class Hand
        {
            public char[] Cards;

            public Hand(string cards)
            {
                Cards = new char[5];
                Cards = cards.ToCharArray();
            }

            public HandType GetHandType() =>
                Cards.ToList().Distinct().Count() switch
                {
                    1 => HandType.FiveOfAKind,
                    2 => Cards.Count(x => x == Cards[0]) == 4 || Cards.Count(x => x == Cards[0]) == 1
                        ? HandType.FourOfAKind
                        : HandType.FullHouse,
                    3 => Cards.Any(x => Cards.Count(y => y == x) == 3)
                        ? HandType.ThreeOfAKind
                        : HandType.TwoPair,
                    4 => HandType.OnePair,
                    5 => HandType.HighCard,
                    _ => throw new ArgumentOutOfRangeException()
                };

        }

        private static Hand ResolveAlikeHands(Hand hand1, Hand hand2)
        {
            for (int i = 0; i < hand1.Cards.Length; i++)
            {
                char hand1card = hand1.Cards[i];
                char hand2card = hand2.Cards[i];

                if (hand1card != hand2card)
                {
                    return GetCardStrength(hand1card) > GetCardStrength(hand2card) ? hand1 : hand2;
                }
            }

            throw new Exception("Hands were completely identical. Could not resolve.");
        }
    }
}
