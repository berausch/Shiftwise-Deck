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

            Assert.Equal(13, clubs);

            var AceClubs = thisDeck.Where(x => x.Suit == "Clubs" && x.Value == "Ace").Count();

            Assert.Equal(1, AceClubs);

        }
    }
}
