using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Obstacle
    {
        private int location;
        private byte health;

        public Obstacle(int location, byte health)
        {
            this.Location = location;
            this.Health = health;
        }

        public int Location { get => location; set => location = value; }
        public byte Health { get => health; set => health = value; }
    }
}
