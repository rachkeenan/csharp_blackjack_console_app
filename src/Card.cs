using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        // Properties
        public string CardType { get; set; }
        public string CardSuit { get; set; }
        public int CardValue { get; set; }

        // Constructors
        public Card(string cardType, string cardSuit, int cardValue)
        {
            CardType = cardType;
            CardSuit = cardSuit;
            CardValue = cardValue;
        }

        // Methods
        public override string ToString()
        {            
            return $"{CardType} of {CardSuit}, value: {CardValue}";
        }
    }
}
