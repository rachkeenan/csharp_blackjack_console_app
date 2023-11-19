using Blackjack;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public string[] cardType = new string[13] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "King", "Queen", "Jack" };
        public string[] cardSuit = new string[4] { "❤️", "♠️", "♣️", "♦️" };
        public int[] cardValue = new int[] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };

        // Properties
        public Card[] Cards { get; } = new Card[52];

        // Constructors
        public Deck()
        {
            Cards = CreateDeck();
        }

        // Methods
        // Create a deck of cards
        // https://rachael.hashnode.dev/creating-a-deck-of-cards-in-csharp
        private Card[] CreateDeck()
        {
            // A deck of cards has 52 cards
            // 4 card suits
            // 13 card types and values
            int cardIndex = 0;

            for (int cardSuitIndex = 0; cardSuitIndex < cardSuit.Length; cardSuitIndex++)
            {
                for (int cardTypeIndex = 0; cardTypeIndex < cardType.Length; cardTypeIndex++)
                {
                    Cards[cardIndex] = new Card(cardType[cardTypeIndex], cardSuit[cardSuitIndex], cardValue[cardTypeIndex]);
                    cardIndex++;
                }
            }

            ShuffleDeck();

            return Cards;
        }

        // Shuffle the deck
        // https://rachael.hashnode.dev/shuffling-an-array-in-csharp
        public void ShuffleDeck()
        {
            Random randomCard = new Random();

            for (int shuffleNum = 0; shuffleNum < 720; shuffleNum++)
            {
                // pick the first card
                Card firstCard = Cards[0];

                // pick a card that's not the first card
                int shuffleCardIndex = randomCard.Next(1, Cards.Length);

                // swap the first card with the shuffle card
                Cards[0] = Cards[shuffleCardIndex];
                Cards[shuffleCardIndex] = firstCard;
            }
        }

        // Deal some cards
        // https://rachael.hashnode.dev/deal-from-a-deck-of-cards-in-csharp
        public Card[] DealCards(int amount)
        {
            int cardsDealt = 0;

            Card[] tempCardsToDeal = new Card[amount];

            for (int cardIndex = 0; cardsDealt != amount && cardIndex < Cards.Length; cardIndex++)
            {
                if (Cards[cardIndex] == null) // if there is no card at the card index, increment to the next card 
                {
                    cardIndex++;
                    continue;
                }

                tempCardsToDeal[cardsDealt] = Cards[cardIndex];
                Cards[cardIndex] = null;
                cardsDealt++;
            }

            return tempCardsToDeal;
        }
    }
}
