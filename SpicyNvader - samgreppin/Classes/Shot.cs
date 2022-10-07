using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Shot
    {
        private int location;
        private bool shooting;

        public Shot(int location, bool shooting)
        {
            this.Location = location;
            this.Shooting = shooting;
        }

        public int Location { get => location; set => location = value; }
        public bool Shooting { get => shooting; set => shooting = value; }
    }
}
