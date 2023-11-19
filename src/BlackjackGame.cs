using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class BlackjackGame
    {
        // Properties
        private Dealer dealer1;
        private Player player1;

        // Constructors
        public BlackjackGame(Dealer dealer, Player player)
        {
            dealer1 = dealer;
            player1 = player;
        }

        // Methods
        // Player's play
        public void StartPlayersTurn()
        {
            string playerChoice;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("***************************************");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Player Hand:");

            Console.ResetColor();

            player1.GiveCards(dealer1.DealCards(2));
            Console.WriteLine($"Your score is: {player1.GetHandValue()}");

            // If the card value is < 21, ask the player if they want to stick or twist
            while (player1.GetHandValue() < 21)
            {
                Console.WriteLine("\nDo you want to stick or twist - s/t?: ");
                playerChoice = Console.ReadLine();

                if (playerChoice == "t")
                {
                    player1.GiveCards(dealer1.DealCards(1));
                    Console.WriteLine($"Player 1 hand value is: {player1.GetHandValue()}");
                }

                if (playerChoice == "s" || playerChoice == "")
                {
                    Console.WriteLine($"Player 1 hand value is: {player1.GetHandValue()}");
                    break;
                }
            }
        }
        public void StartDealersTurn()
        {
            // Dealer's play
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n***************************************");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Dealer Hand:");

            Console.ResetColor();

            dealer1.GiveCards(dealer1.DealCards(2));
            Console.WriteLine($"Dealer's score is: {dealer1.GetHandValue()}");

            // If dealer's hand value is < 17 give another card
            if (dealer1.GetHandValue() < 17)
            {
                while (dealer1.GetHandValue() < 17)
                {
                    dealer1.GiveCards(dealer1.DealCards(1));
                    Console.WriteLine($"Dealer hand value is: {dealer1.GetHandValue()}");
                }
            }
        }
    }
}

