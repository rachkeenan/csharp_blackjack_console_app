using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    public class Dealer : Player
    {
        // Properties
        //public Card[] Hand { get; set; } = new Card[10];
        private Deck Deck;

        // Constructors
        public Dealer()
        {
            Deck = new Deck();
        }

        public Card[] DealCards(int amount)
        {
            return Deck.DealCards(amount);
        }

        // Methods

        /* I commented all of this code out because it was duplicated, I used inheritance instead.
           See: https://rachael.hashnode.dev/how-csharp-inheritance-saved-me-100-lines-of-code */ 

        //public void GiveCards(Card[] hand)
        //{
        //    // add cards to the hand
        //    // if the card at the index is filled add to the next index
        //    int cardsGiven = 0;

        //    for (int i = 0; cardsGiven != hand.Length; i++)
        //    {
        //        if (Hand[i] == null) // if the card at index i is empty
        //        {
        //            Hand[i] = hand[cardsGiven];
        //            cardsGiven++;

        //            Console.WriteLine($"Card dealt: {Hand[i]}");

        //            continue;
        //        }
        //    }
        //}

        //public int GetHandValue()
        //{
        //    int handValue = 0;
        //    bool handHasAce = HasAnAce(Hand);
        //    int numOfAces = NumOfAces(Hand);

        //    for (int i = 0; i < Hand.Length; i++)
        //    {
        //        if (Hand[i] == null)
        //            continue;

        //        handValue += Hand[i].CardValue;
        //    }

        //    if (handValue <= 21)
        //    {
        //        return handValue;
        //    }
        //    else
        //    {
        //        if (handHasAce)
        //        {
        //            for (int ace = 0; ace < numOfAces; ace++)
        //            {
        //                handValue -= 10;

        //                if (handValue <= 21)
        //                    break;
        //            }
        //        }

        //    }

        //    return handValue;

        //}
        //
        //private bool HasAnAce(Card[] cards)
        //{
        //    foreach (Card card in cards)
        //    {
        //        if (card == null)
        //            continue;

        //        if (card.CardType == "Ace")
        //            return true;
        //    }
        //    return false;
        //}

        //private int NumOfAces(Card[] cards)
        //{
        //    int aceCount = 0;

        //    foreach (Card card in cards)
        //    {
        //        if (card == null)
        //            continue;

        //        if (card.CardType == "Ace")
        //            aceCount++;
        //    }

        //    return aceCount;
        //}
    }
}
