using Classes;
namespace Test
{
    [TestClass]
    public class TestSpicyNvader
    {
        private byte[] ALIEN_NUMBERS = new byte[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21};

        [TestMethod]
        public void TestPlayerName()
        {
            Player p;
            bool success = true;
            try
            {
                p = new Player("ooooooooooooooooooooooooooooooooooooooooo", 1000); // Must fail
                success = false;
            }
            catch
            {
                // Was expected
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestGoRight()
        {
            Ship p;
            bool success = true;
            try
            {
                p = new Ship(12, 12, 3, true);
                p.moveRight(p); // Must success
            }
            catch
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestGoLeft()
        {
            Ship p;
            bool success = true;
            try
            {
                p = new Ship(12, 12, 3, true);
                p.moveLeft(p); // Must success
            }
            catch
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestCreationAlien()
        {
            Alien alien;
            bool success = true;
            try
            {
                alien = new Alien(23, 1, true);
                success = false;
            }
            catch
            {
                success=true;
            }
            Assert.IsTrue(success);
        }
    }
}