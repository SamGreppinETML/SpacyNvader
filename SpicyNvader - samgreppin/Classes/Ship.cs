using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Ship
    {
        private int locationX;
        private int locationY;
        private byte health;
        private bool alive;

        public Ship(int locationX, int locationY, byte health, bool alive)
        {
            this.LocationX = locationX;
            this.LocationY = locationY;
            this.Health = health;
            this.Alive = alive;
        }

        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public byte Health { get => health; set => health = value; }
        public bool Alive { get => alive; set => alive = value; }

        public void moveRight(Ship ship)
        {
            ship.LocationX++;
        }
        public void moveLeft(Ship ship)
        {
            ship.LocationX--;
        }
    }
}
