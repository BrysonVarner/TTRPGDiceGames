using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPGDiceGames
{
    public static class EntryChecker
    {
        private static int invalidEntryCounter = 0;
        private static int standCounter = 0;
        public static void InvalidEntryChecker()
        {
            if (invalidEntryCounter < 10)
            {
                invalidEntryCounter++;
            }
            else if (invalidEntryCounter >= 10)
            {
                Console.WriteLine("I am sorry, too many invalid entries have been made. Shutting down in...");
                for (int i = 5; i > 0; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                
            }
        }
        public static void StandCounter(int myRollTotal, int gold)
        {
            if (standCounter < 5)
            {
                standCounter++;
                Console.WriteLine($"Your stand count is currently at {standCounter} out of 5.");
            }
            else if (standCounter >= 5)
            {
                int tieSplitter = 0;
                bool loseCheck = false;
                Console.WriteLine("We can't hold forever. Let's see who the winner is...");
                foreach (var opponent in Opponent.OpponentList)
                {
                    var opponentTotal = opponent.OpponentRolls.Sum();
                    if (myRollTotal > opponentTotal)
                    {
                        Opponent.BustList.Add(opponent);
                    }
                    else if (myRollTotal < opponentTotal)
                    {
                        Console.WriteLine($"Your total is less than {opponent.OpponentID} who has {opponent.OpponentRolls.Sum()}.");
                        loseCheck = true;
                    }
                    else 
                    {
                        Console.WriteLine($"Your total is the same as {opponent.OpponentID} who has {opponent.OpponentRolls.Sum()}.");
                        tieSplitter++;
                    }
                   
                }
                var opponentsRemaining = Opponent.OpponentList.Except(Opponent.BustList).ToList();
                if (opponentsRemaining.Count == 0 && tieSplitter == 0)
                {
                    Console.WriteLine("You are the winner!");
                    Console.WriteLine($"You Win {gold} gold pieces!");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Program.DiceRoller();
                }
                else if (opponentsRemaining.Count > 0 && tieSplitter == 0)
                {
                    Console.WriteLine($"I am sorry, you lose! You almost had those {gold} gold pieces!");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Program.DiceRoller();
                }
                else if (opponentsRemaining.Count > 0 && loseCheck)
                {
                    Console.WriteLine($"I am sorry, you lose! You almost had those {gold} gold pieces!");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Program.DiceRoller();
                }
                else
                {
                    Console.WriteLine($"It is a tie between {tieSplitter} players! You receive {gold / tieSplitter} gold pieces!");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Program.DiceRoller();
                }

                Console.WriteLine("Returning to menu in...");
                for (int i = 5; i > 0; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                Program.DiceRoller();
            }
        }
    }
}
