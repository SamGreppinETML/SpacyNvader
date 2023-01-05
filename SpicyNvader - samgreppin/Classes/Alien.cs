namespace Classes
{
    /*
     * Cette classe permet de créer les aliens.
     * 
     * Alien byte number
     * Alien int locationX
     * Alien int locationY
     * Alien bool alive
     */
    public class Alien
    {
        private byte number;
        private int locationX;
        private int locationY;
        private bool alive;

        public Alien(byte number, int locationX, int locationY, bool alive)
        {
            if (number > 10)
            {
                throw new Exception("impossible to create alien");
            }
            else
            {
                this.Number = number;
            }
            this.LocationX = locationX;
            this.LocationY = locationY;
            this.Alive = alive;
        }

        public byte Number { get => number; set => number = value; }
        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public bool Alive { get => alive; set => alive = value; }
    }
}