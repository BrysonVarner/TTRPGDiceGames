﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPGDiceGames
{
    internal class BonesMethod
    {


        public static void BonesStart()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var pot = 0;
            var ante = 1;
            var numOfPlayers = 2;
            var playerRollTotal = 0;
            var opponentsAtTable = Opponent.OpponentList;
            opponentsAtTable = Opponent.OpponentList.Except(Opponent.BustList).ToList();
            opponentsAtTable.Clear();
            Opponent.OpponentList.Clear();            
            Console.WriteLine("Welcome to the Tavern! Pull up a chair and prepare to empty your coin purse!");
            Console.WriteLine($"The game is Baldur's Bones, {ante} gold piece ante.");
            Console.WriteLine("Roll three D6 Dice to start, and one additional each round after.");
            Console.WriteLine("Each round you can choose to \"roll\", \"stand\", or \"wager\" to change the betting amount.");
            Console.WriteLine("Player that gets closest to 21 without going over is the winner!");
            Console.WriteLine();
            Console.WriteLine("How many challengers are you willing to have at the table?");
            var input = Console.ReadLine();
            if (int.TryParse(input,out numOfPlayers)) 
            {
                Console.WriteLine($"{numOfPlayers} against 1. May the odds be in your favor!");
            }
            else
            {
                Console.WriteLine("Please enter a number of challengers, numbers only");
                Console.WriteLine("Lets try this again, shall we?");
                EntryChecker.InvalidEntryChecker();
                BonesStart();
            }                                     
            for (int i = 0; i < numOfPlayers; i++)
            {
                opponentsAtTable.Add(new Opponent(i));
            }             
            Console.WriteLine("You ready to play?");           
            Opponent.BustList.Clear();
            Opponent.OpponentList = opponentsAtTable;
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Ante up, {numOfPlayers + 1} and only one winner... well, maybe one...");
            pot = +((opponentsAtTable.Count * ante) + ante);
            Console.WriteLine($"The pot is currently at {pot} gold pieces");
            var currentRoll0 = DiceController.BaldursBones(3);
            playerRollTotal = currentRoll0.Sum();
            foreach (var playerRoll in currentRoll0)
            {
                Console.WriteLine($"You rolled a {playerRoll}");
                Thread.Sleep(250);
            }
            Console.WriteLine($"Your current roll total is at {playerRollTotal}.");
            Console.WriteLine();
            foreach (var opponent in opponentsAtTable)//Roll for each opponent and display
            {
                int opponentRollThis;
                opponent.OpponentRolls.Clear();
                var opponentRoll = DiceController.BaldursBones(3);
                foreach (var roll in opponentRoll)
                {
                        Console.WriteLine($"The roll was {roll}.");
                        Thread.Sleep(250);
                }
                opponentRollThis = +opponentRoll.Sum();
                opponent.OpponentRolls.Add(opponentRollThis);
                Console.WriteLine($"Opponent {opponent.OpponentID} rolled {opponentRollThis}.");
                Console.WriteLine();
                if (opponent.OpponentRolls.Sum() > 21)
                {
                        Console.WriteLine($"Opponent {opponent.OpponentID} Busts!");
                        Opponent.BustList.Add(opponent);
                        Thread.Sleep(500);                       
                }
            }
            BonesMethod.Bones(pot, playerRollTotal, ante);
            
        }
    

        public static void Bones(int gold, int currentScore, int anteGold)
        {

            int pot = gold;
            int newPot;
            var ante = anteGold;
            int newTotalOld = currentScore;            
            var opponentsAtTable = Opponent.OpponentList;                        
            opponentsAtTable = Opponent.OpponentList.Except(Opponent.BustList).ToList();
            Opponent.OpponentList = opponentsAtTable;   //Reset class list to match adjusted list.
            Thread.Sleep(100);
            Console.WriteLine($"There are {Opponent.OpponentList.Count} players left.");
            Console.WriteLine($"You are currently at {newTotalOld}.");
            Console.WriteLine($"The pot is at {pot} gold pieces. Will you Roll, Stand, or change the Wager?");
            Console.WriteLine();
            var reply = Console.ReadLine();            
            if (reply.Equals("roll", StringComparison.OrdinalIgnoreCase) || (reply.Equals("hit", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Another coin in the pot for all of ya.");
                newPot = pot + ((opponentsAtTable.Count * ante) + ante);
                var currentRoll = DiceController.BaldursBones(1);
                var rollTotal =+ currentRoll.Sum();                
                foreach (var playerRoll in currentRoll)
                {
                    Console.WriteLine($"You rolled a {playerRoll}");
                }
                var newTotal = rollTotal + newTotalOld;
                Console.WriteLine($"You are currently at {newTotal}.");
                Console.WriteLine();
                if (newTotal > 21)
                {
                    Console.WriteLine($"YOU BUST! you leave a pot of {newPot} on the table!");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Program.DiceRoller();
                }
                else
                {
                    foreach (var opponent in opponentsAtTable)//Roll for each opponent and display
                    {
                        
                        if (opponent.OpponentRolls.Sum() < 18 || Opponent.GamblerRisk(opponent.OpponentRolls.Sum()))
                        {
                            int opponentTotal;
                            int opponentRollThis;
                            var opponentRoll = DiceController.BaldursBones(1);
                            foreach (var roll in opponentRoll)
                            {
                                Console.WriteLine($"The roll was {roll}.");
                            }
                            opponentRollThis = +opponentRoll.Sum();
                            opponent.OpponentRolls.Add(opponentRollThis);
                            opponentTotal = opponent.OpponentRolls.Sum();
                            Console.WriteLine($"Opponent {opponent.OpponentID} is at {opponentTotal} in total.");
                            Console.WriteLine();
                            if (opponent.OpponentRolls.Sum() > 21)
                            {
                                Console.WriteLine($"Opponent {opponent.OpponentID} Busts!");                                
                                Opponent.BustList.Add(opponent);
                                Console.WriteLine();

                            }
                            

                        }
                        else
                        {
                            var opponentTotal = opponent.OpponentRolls.Sum();
                            Console.WriteLine($"Opponent {opponent.OpponentID} stands at {opponentTotal} in total.");
                            
                        }
                    }                    
                    if (opponentsAtTable.Count == 0)
                    {
                        Console.WriteLine($"Congratulations! You win the game and {newPot} gold pieces");
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadKey();
                        Program.DiceRoller();
                    }
                    else
                    {                        
                        BonesMethod.Bones(newPot, newTotal, ante);
                    }
                }



            }
            else if (reply.Equals("hold", StringComparison.OrdinalIgnoreCase) || reply.Equals("stay", StringComparison.OrdinalIgnoreCase) || reply.Equals("stand", StringComparison.OrdinalIgnoreCase))
            {
                EntryChecker.StandCounter(newTotalOld, pot);
                Console.WriteLine($"Holding at {newTotalOld}? You Scared?");
                Console.WriteLine();
                Console.WriteLine("Another coin in the pot for all of ya.");
                newPot = pot + ((opponentsAtTable.Count * ante) + ante);
                
                foreach (var opponent in opponentsAtTable)//Roll for each opponent and display
                {
                    if (opponent.OpponentRolls.Sum() < 18 || Opponent.GamblerRisk(opponent.OpponentRolls.Sum()))
                    {
                        int opponentTotal;
                        int opponentRollThis;
                        var opponentRoll = DiceController.BaldursBones(1);
                        foreach (var roll in opponentRoll)
                        {
                            Console.WriteLine($"The roll was {roll}.");
                        }
                        opponentRollThis = +opponentRoll.Sum();
                        opponent.OpponentRolls.Add(opponentRollThis);
                        opponentTotal = opponent.OpponentRolls.Sum();
                        Console.WriteLine($"Opponent {opponent.OpponentID} is at {opponentTotal} in total.");
                        Console.WriteLine();
                        if (opponent.OpponentRolls.Sum() > 21)
                        {
                            Console.WriteLine($"Opponent {opponent.OpponentID} Busts!");
                            Opponent.BustList.Add(opponent);
                            Console.WriteLine();
                        }                        
                    }
                    else
                    {
                        var opponentTotal = opponent.OpponentRolls.Sum();
                        Console.WriteLine($"Opponent {opponent.OpponentID} stands at {opponentTotal} in total.");
                        Console.WriteLine();
                    }
                }                
                if (opponentsAtTable.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Congratulations! You win the game and {newPot} gold pieces");
                }
                else
                {                    
                    Bones(newPot, currentScore, ante);
                }
            }
            else if (reply.Equals("wager", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("What did you want to change the current bet to?");
                var wagerChange = Console.ReadLine();
                if (int.TryParse(wagerChange, out ante))
                {
                    Console.WriteLine($"The current wager has been changed to {ante}");
                    Bones(pot, currentScore, ante);
                }
                else
                {
                    Console.WriteLine("Please enter a number for a new wager, numbers only");
                    EntryChecker.InvalidEntryChecker();
                    Bones(pot, currentScore, ante);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid option entered! Please try again");
                Console.WriteLine();
                EntryChecker.InvalidEntryChecker();
                Bones(pot, currentScore, ante);
            }
        }

    }
}
