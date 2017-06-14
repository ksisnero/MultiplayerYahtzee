using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageViewYahtzee.Models
{
    public class Dice
    {
        private int[] diceArray;
        private Random randNum = new Random();
        public Dice(int[] diceArray)
        {
            this.diceArray = diceArray;
        }
    }
}
