/* 1. create a deck of 52 cards
        a. card class - creates a card
        b. deck class - adds 52 cards to a deck
            i. shuffle the deck
           ii. deal some cards
    2. create a player class
        a. player is dealt 2 cards
        b. can continue and be dealt another card or stick to 2 cards (loop)
        c. calculate the total value of the player's cards
    3. create a dealer class
        b. dealer is dealt cards after the player
        e. calculate the total value of the dealer's cards
        f. dealer must take another card if total value is <17, until their hand is >=17
    4. Calculate the scores and find the winner
        b. an "Ace" can be worth 11 or 1
        c. if value is greater than 21 = bust
        d. value equal or closest to 21 wins
    5. Create a loop to exit game or play again
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool playAgain;
            PrintGameDetails();

            // Loop to play again
            do
            {
                Dealer dealer = new Dealer();
                Player player = new Player();

                BlackjackGame blackjackGame = new BlackjackGame(dealer, player);

                blackjackGame.StartPlayersTurn();
                blackjackGame.StartDealersTurn();
                
                DetermineWinner(dealer, player);

                playAgain = PlayAgain();

            }
                while (playAgain);
        }

        private static bool PlayAgain()
        {
            bool playAgain = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nDo you want to play again? - y/n? ");

            if (Console.ReadLine() == "y")
                playAgain = true;

            Console.Clear();

            return playAgain;
        }

        private static void PrintGameDetails()
        {
            /* https://www.tutorialspoint.com/how-to-change-the-foreground-color-of-text-in-chash-console */
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to Blackjack");

            Console.ResetColor();

            Console.WriteLine("\nThe rules of the game are:" +
                "\nYour hand must be less than or equal to 21," +
                "\nWhen you have decided to stick, the dealer will play," +
                "\nThe dealer must take another card until they have 17 or more, or go bust," +
                "\nThe player with 21 or closest to 21, without going bust, wins!" +
                "\nExtra... Swedish Pub Blackjack rule" +
                "\nIf the dealer and player draw with hand values of 17, 18 or 19, the Dealer wins.");

            Console.WriteLine("\nPress any key to continue...");

            Console.ReadLine();
            Console.Clear();
        }

        private static void DetermineWinner(Dealer dealer, Player player)
        {
            // Find the winner
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (
                dealer.GetHandValue() > player.GetHandValue() && dealer.GetHandValue() <= 21
                ||
                player.GetHandValue() > 21 && dealer.GetHandValue() <= 21)
            {
                Console.WriteLine("\nDealer is the winner");
            }
            else if (player.GetHandValue() > dealer.GetHandValue() && player.GetHandValue() <= 21 || dealer.GetHandValue() > 21 && player.GetHandValue() <= 21)
            {
                Console.WriteLine("\nPlayer 1 is the winner");
            }
            // Swedish Pub Blackjack
            // Nightclubs and pubs in Sweden often offer a Blackjack variant that is less favourable to the players.
            else if (dealer.GetHandValue() == 17 && player.GetHandValue() == 17 || dealer.GetHandValue() == 18 && player.GetHandValue() == 18 || dealer.GetHandValue() == 19 && player.GetHandValue() == 19)
            {
                Console.WriteLine("\nDealer is the winner");
            }
            else if (dealer.GetHandValue() == player.GetHandValue())
            {
                Console.WriteLine("\nDraw... Please play again!");
            }

            else if (dealer.GetHandValue() > 21 && player.GetHandValue() > 21)
            {
                Console.WriteLine("\nNo winner...Please play again!");
            }
        }
    }
}
