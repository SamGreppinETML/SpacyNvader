using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /*
     * Cette classe permet de créer les tirs des aliens et du joueur.
     * 
     * Shot int locationX
     * Shot int locationY
     */
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
