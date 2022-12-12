using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Shot
    {
        private int locationX;
        private int locationY;
        private bool shooting;

        public Shot(int locationX, int locationY, bool shooting)
        {
            this.LocationX = locationX;
            this.LocationY = locationY;
            this.Shooting = shooting;
        }

        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public bool Shooting { get => shooting; set => shooting = value; }
    }
}
