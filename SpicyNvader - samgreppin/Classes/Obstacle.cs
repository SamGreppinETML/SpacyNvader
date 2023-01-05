using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /*
     * Cette classe permet de créer les obstacles.
     * 
     * Obstacle int locationX
     * Obstacle int locationY
     * Obstacle byte health
     */
    public class Obstacle
    {
        private int locationX;
        private int locationY;
        private byte health;

        public Obstacle(int locationX, int locationY, byte health)
        {
            this.LocationX = locationX;
            this.LocationY = locationY;
            this.Health = health;
        }

        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public byte Health { get => health; set => health = value; }
    }
}
