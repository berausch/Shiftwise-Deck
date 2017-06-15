using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Deck
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public string Name { get; set; } 

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
            Name = value + " of " + suit;
        }
    }

    public class Deck : List<Card>
    {
       
        public List<Card> OrderedDeck()
        {
            var suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
            var suitNumbers = new List<string> { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var thisDeck = new List<Card> { };

            for (var i = 0; i < 4; i++)
            {
                for (var ii = 0; ii < 13; ii++)
                {
                    var thisCard = new Card(suitNumbers[ii], suits[i]);
                    thisDeck.Add(thisCard);
                }
            }
            return thisDeck;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var orderedDeck = new Deck().OrderedDeck();
            var shuffledDeck = ShuffledDeck();
            Console.WriteLine("Get a free Deck of Cards! 1: Type 1 for ordered Deck. 2: Type 2 for shuffled deck");
            string deckChoice = Console.ReadLine();
            if (deckChoice == "1")
            {
                orderedDeck.Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            }
            else if (deckChoice == "2")
            {
                shuffledDeck.Select(x => x.Name).ToList().ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("You only get a deck if you follow instructions...");
            }
            Console.ReadLine();
        }
        

        static List<Card> ShuffledDeck()
        {
            var thisDeck = new Deck().OrderedDeck();
            var rand = new Random();
            for (int i = thisDeck.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                var temp = thisDeck[i];
                thisDeck[i] = thisDeck[n];
                thisDeck[n] = temp;
            }
            return thisDeck;
        }
    }
}
