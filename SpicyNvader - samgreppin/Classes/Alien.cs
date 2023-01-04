namespace Classes
{
    public class Alien
    {
        private byte number;
        private int locationX;
        private int locationY;
        private bool alive;
        private bool shootable;

        public Alien(byte number, int locationX, int locationY, bool alive, bool shootable)
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
            this.Shootable = shootable;
        }

        public byte Number { get => number; set => number = value; }
        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public bool Alive { get => alive; set => alive = value; }
        public bool Shootable { get => shootable; set => shootable = value; }
    }
}