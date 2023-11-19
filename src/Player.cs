using System;
using System.CodeDom;
using System.Globalization;
using System.Linq;

namespace Blackjack
{
    public class Player
    {
        // Properties
        public Card[] Hand { get; set; } = new Card[10];

        // Constructors
        public Player()
        {

        }

        // Methods
        // Deal cards to player hand
        // https://rachael.hashnode.dev/deal-from-a-deck-of-cards-in-csharp
        public void GiveCards(Card[] hand)
        {
            // add cards to the hand
            // if the card at the index is filled add to the next index
            int cardsGiven = 0;

            for (int i = 0; cardsGiven != hand.Length; i++)
            {
                if (Hand[i] == null) // if the card at index i is empty
                {
                    Hand[i] = hand[cardsGiven];
                    cardsGiven++;

                    Console.WriteLine($"Card dealt is the {Hand[i]}");
                }
            }
        }

        // get value of cards in hand 
        // https://rachael.hashnode.dev/calculating-a-players-hand-value-in-blackjack-using-csharp
        public int GetHandValue()
        {
            int handValue = 0;
            bool handHasAce = HasAnAce(Hand);
            int numOfAces = NumOfAces(Hand);

            for (int i = 0; i < Hand.Length; i++)
            {
                if (Hand[i] == null)
                    continue;

                handValue += Hand[i].CardValue;
            }

            //if the hand value is <= 21, RETURN hand value
            //if > 21, check if theres an ace
            // then check how many aces - for loop
            // if theres an ace -10 from hand value
            // check hand value, if it is still >21 loop and again and -10
            // when <=21 RETURN hand value
            
            if (handValue <= 21)
            {
                return handValue;
            } 
            else
            {
                if (handHasAce)
                {
                    for (int ace = 0; ace < numOfAces; ace++)
                    {
                        handValue -= 10;

                        if (handValue <= 21)
                            break;
                    }
                }

            }

            return handValue;

        }
        private bool HasAnAce(Card[] cards)
        {
            foreach (Card card in cards)
            {
                if (card == null)
                    continue;

                if (card.CardType == "Ace")
                    return true;
            }
            return false;
        }

        private int NumOfAces(Card[] cards)
        {
            int aceCount = 0;

            foreach (Card card in cards)
            {
                if (card == null)
                    continue;

                if (card.CardType == "Ace")
                    aceCount++;
            }

            return aceCount;
        }

    }
}
