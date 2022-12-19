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

        public Shot(int locationX, int locationY)
        {
            this.LocationX = locationX;
            this.LocationY = locationY;
        }

        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
    }
}
