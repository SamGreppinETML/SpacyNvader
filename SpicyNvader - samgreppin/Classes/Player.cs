using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Player
    {
        private string name;
        private int score;

        public Player(string name, int score)
        {
            if (name.Length > 30)
            {
                throw new Exception("impossible to create player");
            }
            else
            {
                this.Name = name;
            }
            this.Score = score;
        }

        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
    }
}
