using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTRPGDiceGames
{
    public class Opponent
    {
        public Opponent(int id)
        {
            OpponentID = id;
        }
        public int OpponentID { get; set; }
        public List<int> OpponentRolls { get; set; } = new List<int>();
        public static List<Opponent> OpponentList { get; set; } = new List<Opponent>();
        public static List<Opponent> BustList { get; set; } = new List<Opponent>();
        public static bool GamblerRisk(int rollTotal)
        {
            int riskFactor;
            Random r = new Random();
            int num = r.Next(1, 11);
            riskFactor = 21 - rollTotal;  //Check total vs 21
            return (num > (10 - riskFactor)) ? true : false;
        }
        
    }
}
