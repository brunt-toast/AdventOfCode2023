using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day7
{
    /*
     *--- Day 7: Camel Cards ---
     * Your all-expenses-paid trip turns out to be a one-way, five-minute ride in an airship. (At least it's a cool airship!) It drops you off at the edge of a vast desert and descends back to Island Island.
     * 
     * "Did you bring the parts?"
     * 
     * You turn around to see an Elf completely covered in white clothing, wearing goggles, and riding a large camel.
     * 
     * "Did you bring the parts?" she asks again, louder this time. You aren't sure what parts she's looking for; you're here to figure out why the sand stopped.
     * 
     * "The parts! For the sand, yes! Come with me; I will show you." She beckons you onto the camel.
     * 
     * After riding a bit across the sands of Desert Island, you can see what look like very large rocks covering half of the horizon. The Elf explains that the rocks are all along the part of Desert Island that is directly above Island Island, making it hard to even get there. Normally, they use big machines to move the rocks and filter the sand, but the machines have broken down because Desert Island recently stopped receiving the parts they need to fix the machines.
     * 
     * You've already assumed it'll be your job to figure out why the parts stopped when she asks if you can help. You agree automatically.
     * 
     * Because the journey will take a few days, she offers to teach you the game of Camel Cards. Camel Cards is sort of similar to poker except it's designed to be easier to play while riding a camel.
     * 
     * In Camel Cards, you get a list of hands, and your goal is to order them based on the strength of each hand. A hand consists of five cards labeled one of A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2. The relative strength of each card follows this order, where A is the highest and 2 is the lowest.
     * 
     * Every hand is exactly one type. From strongest to weakest, they are:
     * 
     * Five of a kind, where all five cards have the same label: AAAAA
     * Four of a kind, where four cards have the same label and one card has a different label: AA8AA
     * Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
     * Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
     * Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
     * One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
     * High card, where all cards' labels are distinct: 23456
     * Hands are primarily ordered based on type; for example, every full house is stronger than any three of a kind.
     * 
     * If two hands have the same type, a second ordering rule takes effect. Start by comparing the first card in each hand. If these cards are different, the hand with the stronger first card is considered stronger. If the first card in each hand have the same label, however, then move on to considering the second card in each hand. If they differ, the hand with the higher second card wins; otherwise, continue with the third card in each hand, then the fourth, then the fifth.
     * 
     * So, 33332 and 2AAAA are both four of a kind hands, but 33332 is stronger because its first card is stronger. Similarly, 77888 and 77788 are both a full house, but 77888 is stronger because its third card is stronger (and both hands have the same first and second card).
     * 
     * To play Camel Cards, you are given a list of hands and their corresponding bid (your puzzle input). For example:
     * 
     * 32T3K 765
     * T55J5 684
     * KK677 28
     * KTJJT 220
     * QQQJA 483
     * This example shows five hands; each hand is followed by its bid amount. Each hand wins an amount equal to its bid multiplied by its rank, where the weakest hand gets rank 1, the second-weakest hand gets rank 2, and so on up to the strongest hand. Because there are five hands in this example, the strongest hand will have rank 5 and its bid will be multiplied by 5.
     * 
     * So, the first step is to put the hands in order of strength:
     * 
     * 32T3K is the only one pair and the other hands are all a stronger type, so it gets rank 1.
     * KK677 and KTJJT are both two pair. Their first cards both have the same label, but the second card of KK677 is stronger (K vs T), so KTJJT gets rank 2 and KK677 gets rank 3.
     * T55J5 and QQQJA are both three of a kind. QQQJA has a stronger first card, so it gets rank 5 and T55J5 gets rank 4.
     * Now, you can determine the total winnings of this set of hands by adding up the result of multiplying each hand's bid with its rank (765 * 1 + 220 * 2 + 28 * 3 + 684 * 4 + 483 * 5). So the total winnings in this example are 6440.
     * 
     * Find the rank of every hand in your set. What are the total winnings?
     */
    internal class Day7 : IAocAnswer
    {

        private StreamReader _stream = new(@"Day7/input.txt");
        private readonly string[] _input;

        public Day7()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        public long Part1()
        {
            List<Hand> hands = _input.Select(x => new Hand(x.Split(" ")[0])).ToList();
            List<int> bids = _input.Select(x => int.Parse(x.Split(" ")[1])).ToList();

            hands = hands.OrderBy(x => x.GetHandType()).ToList();

            List<int> results = new();
            for (int i = 0; i < hands.Count; i++)
            {
                Hand hand = hands[i];
                int bid = bids[i];

                Console.WriteLine($"{i+1} * {bid}: Hand with {string.Join("", hand.Cards)} has power of {hand.GetHandType()} ({(int)hand.GetHandType()})");
                // Note - look at the values and ordering in the example.

                results.Add((i + 1) * bid);
            }

            Console.WriteLine(results.Sum()); 
            return results.Sum();
        }

        public long Part2()
        {
            throw new NotImplementedException();
        }

        private int GetCardStrength(char c) =>
            "23456789TJQKA".IndexOf(c) + 1;

        private enum HandType // enumeration value corresponds to hand strength. 
        {
            FiveOfAKind = 6, // 1 distinct card
            FourOfAKind = 5, // 2 distinct cards, 4 + 1
            FullHouse = 4, // 2 distinct cards, 1 group (others must be same) 
            ThreeOfAKind = 3, // 2 distinct cards, 1 group (others must be different) 
            TwoPair = 2, // 3 distinct cards, 2 groups
            OnePair = 1, // 4 distinct cards, 1 group
            HighCard = 0 // 5 distinct cards, no groups
        }

        private class Hand
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

        private Hand ResolveAlikeHands(Hand hand1, Hand hand2)
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
