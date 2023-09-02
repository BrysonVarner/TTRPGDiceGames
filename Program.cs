using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;

namespace TTRPGDiceGames
{
    internal class Program
    {
        public static void DiceRoller()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var rollerHeader ="Welcome to the Dice Roller!";
            Console.SetCursorPosition((Console.WindowWidth - rollerHeader.Length) / 2, Console.CursorTop);
            Console.WriteLine(rollerHeader);
            var rollerDivider = "---------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - rollerDivider.Length) / 2, Console.CursorTop);
            Console.WriteLine(rollerDivider);
            Console.WriteLine("Please select the die type you wish to roll ( D4, D6, D8, D10, D12, D20, or \"clear\" to clear the screen)");
            Console.WriteLine("You can type \"Bones\" to try your luck at winning some gold! If nothing sounds appealing type \"exit\" to quit.");
            var dieType = Console.ReadLine();
            if (dieType == "D4" || dieType == "d4")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD4(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }
            else if (dieType == "D6" || dieType == "d6")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD6(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }
            else if (dieType == "D8" || dieType == "d8")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD8(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }
            else if (dieType == "D10" || dieType == "d10")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD10(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }
            else if (dieType == "D12" || dieType == "d12")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD12(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }
            else if (dieType == "D20" || dieType == "d20")
            {
                Console.WriteLine($"How many {dieType}s do you want to roll?");
                var input = Console.ReadLine();
                var turns = int.Parse(input);
                DiceController.RollD20(turns);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                DiceRoller();
            }

            else if (dieType.Equals("clear", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                DiceRoller();
            }
            else if ((dieType.Equals("bones", StringComparison.OrdinalIgnoreCase)))
            {
                BonesMethod.BonesStart();
            }
            else if (dieType.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Thank you very much for playing!");
                Thread.Sleep(1000);
                Environment.Exit(0);                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid response");
                EntryChecker.InvalidEntryChecker();
                DiceRoller();
            }
        }
        static void Main(string[] args)
        {
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var header = "Welcome to my TTRPG Dice Games Program";
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);
            var divider = "---------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();

            Thread.Sleep(1000);
            Console.WriteLine("  You have been on your journey for weeks now. Bandits, Highwaymen, and Monsters trying to help themselves to your");
            Console.WriteLine("belongings, or worse. Several times, you yourself have avoided becoming the entree on the dinner platter.");
            Console.WriteLine();

            Console.WriteLine("  It has been raining since dusk yesterday, and you are soaked, and chilled to the bone.You round a corner on the trail");
            Console.WriteLine("through the dreary forest, and see a very welcoming sight, the surprise of a roadside inn makes you quicken your");
            Console.WriteLine("pace towards warmth and dry shelter. As you enter, the noise of cheers and alcohol infused chatter hits your ears");
            Console.WriteLine("like a thunderclap. Finally, somewhere dry to sit, eat, and blow off some steam!");
            Console.WriteLine();

            Console.WriteLine("  You remove your cloak, and drape it over the back of the chair to dry by the warmth of the hearth a short");
            Console.WriteLine("distance from you. You sit down in the chair and notice a small pouch of dice on the table. You pull them out");
            Console.WriteLine("and roll them around for amusement. A tall man with a fantastically long beard approaches you.");
            Console.WriteLine();

            Console.WriteLine("\"Welcome welcome! Have a seat and get a drink!\" ");
            Console.WriteLine("\"Are you willing to try your luck at a game of Baldur's Bones?\"");
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
            Console.Clear();
            DiceRoller(); 
        }
    
    }
}