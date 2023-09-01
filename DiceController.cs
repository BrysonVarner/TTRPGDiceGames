using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPGDiceGames
{
    public class DiceController
    {
        public static void RollD4(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 5);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static void RollD6(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 7);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static void RollD8(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 9);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static void RollD10(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 11);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static void RollD12(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 13);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static void RollD20(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 21);
                rolls.Add(num);
                Console.WriteLine($"You rolled a {num}");
                Thread.Sleep(250);
            }
            var total = rolls.Sum();
            Console.WriteLine($"You rolled {total} in total.");
            rolls.Clear();
        }
        public static List<int> BaldursBones(int turns)
        {
            Random r = new Random();
            var rolls = new List<int>();
            rolls.Clear();//prevent reccurances
            for (int i = 0; i < turns; i++)
            {
                int num = r.Next(1, 7);
                rolls.Add(num);
                Thread.Sleep(250);
            }
            return rolls;
        }
    }
}
