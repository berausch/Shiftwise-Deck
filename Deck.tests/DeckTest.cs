using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deck;
using Xunit;

namespace Deck.tests
{
    public class DeckTest
    {
        [Fact]
        public void GetCardNameTest()
        {
            //Arrange
            var thisCard = new Card("2", "Clubs");

            //Act
            var result = thisCard.Name;

            //Assert
            Assert.Equal("2 of Clubs", result);
        }

        [Fact]
        public void GetDeckTest()
        {
            //Arrange
            var thisDeck = new Deck().OrderedDeck();

            Assert.Equal(52, thisDeck.Count);

            var clubs = thisDeck.Where(x => x.Suit == "Clubs").Count();
            var diamonds = thisDeck.Where(x => x.Suit == "Diamonds").Count();
            var hearts = thisDeck.Where(x => x.Suit == "Hearts").Count();
            var spades = thisDeck.Where(x => x.Suit == "Spades").Count();

            Assert.Equal(13, clubs);
            Assert.Equal(13, diamonds);
            Assert.Equal(13, hearts);
            Assert.Equal(13, spades);


            //Check to see make sure if there are only one of certain random cards
            var AceClubs = thisDeck.Where(x => x.Suit == "Clubs" && x.Value == "Ace").Count();
            var KingHearts = thisDeck.Where(x => x.Suit == "Hearts" && x.Value == "King").Count();
            var ThreeDiamonds = thisDeck.Where(x => x.Suit == "Diamonds" && x.Value == "3").Count();
            var NineSpades = thisDeck.Where(x => x.Suit == "Spades" && x.Value == "9").Count();

            Assert.Equal(1, AceClubs);
            Assert.Equal(1, KingHearts);
            Assert.Equal(1, ThreeDiamonds);
            Assert.Equal(1, NineSpades);
        }

        [Fact]
        public void GetOrderedDeckTest()
        {

            var thisDeck = new Deck().OrderedDeck();

            //Make sure the Suits are in the right Alphabetical order
            int AceClubs = thisDeck.FindIndex(x => x.Value == "Ace" && x.Suit == "Clubs");
            int AceDiamonds = thisDeck.FindIndex(x => x.Value == "Ace" && x.Suit == "Diamonds");
            int AceHearts = thisDeck.FindIndex(x => x.Value == "Ace" && x.Suit == "Hearts");
            int AceSpades = thisDeck.FindIndex(x => x.Value == "Ace" && x.Suit == "Spades");

            Assert.Equal(true, AceClubs < AceDiamonds);
            Assert.Equal(true, AceDiamonds < AceHearts);
            Assert.Equal(true, AceHearts < AceSpades);


            //Check if random cards are Consecutive
            int TwoClubs = thisDeck.FindIndex(x => x.Value == "2" && x.Suit == "Clubs");
            int ThreeClubs = thisDeck.FindIndex(x => x.Value == "3" && x.Suit == "Clubs");
            int FourDiamonds = thisDeck.FindIndex(x => x.Value == "4" && x.Suit == "Diamonds");
            int FiveDiamonds = thisDeck.FindIndex(x => x.Value == "5" && x.Suit == "Diamonds");
            int SixHearts = thisDeck.FindIndex(x => x.Value == "6" && x.Suit == "Hearts");
            int SevenHearts = thisDeck.FindIndex(x => x.Value == "7" && x.Suit == "Hearts");
            int EightSpades = thisDeck.FindIndex(x => x.Value == "8" && x.Suit == "Spades");
            int NineSpades = thisDeck.FindIndex(x => x.Value == "9" && x.Suit == "Spades");

            Assert.Equal(true, TwoClubs + 1 == ThreeClubs);
            Assert.Equal(true, FourDiamonds + 1 == FiveDiamonds);
            Assert.Equal(true, SixHearts + 1 == SevenHearts);
            Assert.Equal(true, EightSpades + 1 == NineSpades);

        }

        [Fact]
        public void GetShuffledDeckTest()
        {
            var thisDeck = new Deck().OrderedDeck();
            var thatDeck = new Deck().OrderedDeck();

            var DifferenceSame = thisDeck.SequenceEqual(thatDeck);

            Assert.Equal(true, DifferenceSame);


            var shuffledDeck = new Deck().ShuffledDeck();

            var DifferenceShuffled = thisDeck.SequenceEqual(shuffledDeck);

            Assert.Equal(false, DifferenceShuffled);
        }
    }
}
