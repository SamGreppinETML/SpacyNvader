namespace Classes
{
    public class Alien
    {
        private byte number;
        private int location;
        private bool alive;

        public Alien(byte number, int location, bool alive)
        {
            if (number > 21)
            {
                throw new Exception("impossible to create alien");
            }
            else
            {
                this.Number = number;
            }
            this.Location = location;
            this.Alive = alive;
        }

        public byte Number { get => number; set => number = value; }
        public int Location { get => location; set => location = value; }
        public bool Alive { get => alive; set => alive = value; }
    }
}