using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageViewYahtzee.Models
{
    public class Player
    {
        private int playerNum;
        private ObservableCollection<int> scores = new ObservableCollection<int>(new List<int>() { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0 });
        private ObservableCollection<bool> scoreable = new ObservableCollection<bool>(new List<bool>() { false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        public Player(int playerNum)
        {
            this.playerNum = playerNum;
        }
        

    }
}
