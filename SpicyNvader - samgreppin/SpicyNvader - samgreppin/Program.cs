using System.Runtime.CompilerServices;
using Classes;
using System.Threading;
using WMPLib;

/*
 *  Auteur : Sam Greppin
 *  Date : 26.09.2022
 *  Titre : Spicy Nvader
 *  
 *  Descripton : 
 *  Ce programme qui a éété fait dans le cadre du P_Prod
 *  consiste à créer un jeu vidéo s'inspirant fortement
 *  du célèbre jeu Space Invaders. Nous contrôlons un
 *  cannon pouvant tirer sur des aliens attaquant la
 *  terre.
 */

///// Variable declaration /////

byte bytPositionY = 15;                                                     // Position Y of the arrow
bool bolVolume = true;                                                      // Volume of the music
byte bytDifficulty = 1;                                                     // Difficulty of the game
bool advance = false;                                                       // Advance of the aliens
string direction = "right";                                                 // Direction of the aliens
bool bolFirstGameVerify = true;                                             // Verify if it's the first game
bool bolIsPlayerAlive = true;                                               // Verify if the player is still alive

// Constant
const int INTLARGEUR = 200;                                                 // Width of the game

// Class
Player player = new Player("x", 0);                                         // Creation of the player
Ship ship= new Ship(INTLARGEUR / 2, Console.WindowHeight - 8, 3, true);     // Creation of the ship
Shot shot = new Shot(ship.LocationX + 4, Console.WindowHeight - 9);         // Creation of a missile

// List
List<Alien> listAliveAliens = new List<Alien>();                            // Alien list
List<Alien> listAliensCanShoot = new List<Alien>();                         // Alien can shoot
List<Shot> listShot = new List<Shot>();                                     // Shot list
List<Obstacle> listObstacles = new List<Obstacle>();                        // Obstacle list
List<Shot> listShotAliens = new List<Shot>();                               // Alien shot list
List<Timer> listTimer = new List<Timer>();                                  // List of the timers

///// Main code /////

// Open the Window full size
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

// Play Music
WindowsMediaPlayer wMPPlayer = new WindowsMediaPlayer();
Directory.SetCurrentDirectory(@"..\..\..\bin\Debug\net6.0\");
wMPPlayer.URL = Directory.GetCurrentDirectory() + @"\chad.mp3";

// Call DisplayMenu()
DisplayMenu();

/*
 * Name : DisplayMenu
 * 
 * Description :
 * This method display the menu and the different 
 * option to select.
 */
void DisplayMenu()
{
    // Clear the console
    Console.Clear();

    // Position of the cursor at the start
    Console.SetCursorPosition(0, 0);

    // Change the color
    Console.ForegroundColor = ConsoleColor.Green;

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\t  /$$$$$$            /$$                     /$$   /$$                           /$$");
    Console.WriteLine("\t /$$__  $$          |__/                    | $$$ | $$                          | $$");
    Console.WriteLine("\t| $$  \\__/  /$$$$$$  /$$  /$$$$$$$ /$$   /$$| $$$$| $$ /$$    /$$ /$$$$$$   /$$$$$$$  /$$$$$$   /$$$$$$");
    Console.WriteLine("\t|  $$$$$$  /$$__  $$| $$ /$$_____/| $$  | $$| $$ $$ $$|  $$  /$$/|____  $$ /$$__  $$ /$$__  $$ /$$__  $$");
    Console.WriteLine("\t \\____  $$| $$  \\ $$| $$| $$      | $$  | $$| $$  $$$$ \\  $$/$$/  /$$$$$$$| $$  | $$| $$$$$$$$| $$  \\__/");
    Console.WriteLine("\t /$$  \\ $$| $$  | $$| $$| $$      | $$  | $$| $$\\  $$$  \\  $$$/  /$$__  $$| $$  | $$| $$_____/| $$");
    Console.WriteLine("\t|  $$$$$$/| $$$$$$$/| $$|  $$$$$$$|  $$$$$$$| $$ \\  $$   \\  $/  |  $$$$$$$|  $$$$$$$|  $$$$$$$| $$");
    Console.WriteLine("\t \\______/ | $$____/ |__/ \\_______/ \\____  $$|__/  \\__/    \\_/    \\_______/ \\_______/ \\_______/|__/");
    Console.WriteLine("\t          | $$                     /$$  | $$");
    Console.WriteLine("\t          | $$                    |  $$$$$$/");
    Console.WriteLine("\t          |__/                     \\______/");

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Play display
    Console.WriteLine("\t\t\t ____  __     __   _  _");
    Console.WriteLine("\t\t\t(  _ \\(  )   / _\\ ( \\/ )");
    Console.WriteLine("\t\t\t ) __// (_/\\/    \\ )  /");
    Console.WriteLine("\t\t\t(__)  \\____/\\_/\\_/(__/");

    // Line break
    Console.WriteLine();

    // Settings display
    Console.WriteLine("\t\t\t ____  ____  ____  ____  __  __ _   ___  ____");
    Console.WriteLine("\t\t\t/ ___)(  __)(_  _)(_  _)(  )(  ( \\ / __)/ ___)");
    Console.WriteLine("\t\t\t\\___ \\ ) _)   )(    )(   )( /    /( (_  \\___ \\");
    Console.WriteLine("\t\t\t(____/(____) (__)  (__) (__)\\_)__) \\___/(____/");

    // Line break
    Console.WriteLine();

    // Score display
    Console.WriteLine("\t\t\t ____   ___  __  ____  ____");
    Console.WriteLine("\t\t\t/ ___) / __)/  \\(  _ \\(  __)");
    Console.WriteLine("\t\t\t\\___ \\( (__(  O ))   / ) _)");
    Console.WriteLine("\t\t\t(____/ \\___)\\__/(__\\_)(____)");

    // Line break
    Console.WriteLine();

    // About display
    Console.WriteLine("\t\t\t  __   ____   __   _  _  ____");
    Console.WriteLine("\t\t\t / _\\ (  _ \\ /  \\ / )( \\(_  _)");
    Console.WriteLine("\t\t\t/    \\ ) _ ((  O )) \\/ (  )(");
    Console.WriteLine("\t\t\t\\_/\\_/(____/ \\__/ \\____/ (__)");

    // Line break
    Console.WriteLine();

    // Exit display
    Console.WriteLine("\t\t\t ____  _  _  __  ____");
    Console.WriteLine("\t\t\t(  __)( \\/ )(  )(_  _)");
    Console.WriteLine("\t\t\t ) _)  )  (  )(   )(");
    Console.WriteLine("\t\t\t(____)(_/\\_)(__) (__)");

    // Retenue
    byte bytPositionRetenue = 15;

    Console.SetCursorPosition(95, 38);
    Console.Write("Version 1.0");

    // Boucle pour savoir la touche appuyée
    while (true)
    {
        // Arrow delete
        Console.SetCursorPosition(0, bytPositionRetenue);
        Console.WriteLine("\t            ");
        Console.WriteLine("\t             ");
        Console.WriteLine("\t              ");
        Console.WriteLine("\t             ");
        Console.WriteLine(" ");

        // Arrow display
        Console.SetCursorPosition(0, bytPositionY);
        Console.WriteLine("\t          __");
        Console.WriteLine("\t _________\\ \\");
        Console.WriteLine("\t|_________   >");
        Console.WriteLine("\t          /_/");

        // Verify the key
        switch (Console.ReadKey(true).Key)
        {
            // If the player press the up arrow
            case ConsoleKey.UpArrow:
                if (bytPositionY == 15)
                {
                    bytPositionRetenue = bytPositionY;
                    bytPositionY += 20;
                    break;
                }
                else
                {
                    bytPositionRetenue = bytPositionY;
                    bytPositionY -= 5;
                    break;
                }

            // If the player press the down arrow
            case ConsoleKey.DownArrow:
                if (bytPositionY == 35)
                {
                    bytPositionRetenue = bytPositionY;
                    bytPositionY -= 20;
                    break;
                }
                else
                {
                    bytPositionRetenue = bytPositionY;
                    bytPositionY += 5;
                    break;
                }

            // If the player press the enter key
            case ConsoleKey.Enter:
                // Verify the position of the arrow
                switch (bytPositionY)
                {
                    // If the arrow is on Play
                    case 15:
                        // Call SelectUsername()
                        SelectUsername();
                        return;

                    // If the arrow is on Play
                    case 20:
                        // Call SelectUsername()
                        SelectSettings();
                        return;

                    // If the arrow is on Play
                    case 25:
                        // Call SelectUsername()
                        SelectScore();
                        return;

                    // If the arrow is on Play
                    case 30:
                        // Call SelectUsername()
                        SelectAbout();
                        return;

                    // If the arrow is on Play
                    case 35:
                        // Call SelectUsername()
                        SelectExit();
                        return;
                }
                break;
        }
    }
}

/*
 * Name : SelectUsername
 * 
 * Description :
 * This method ask the player to choose a 
 * username and verify it. If the username
 * is correct, it save it.
 */
void SelectUsername()
{
    // Verify variable
    char chrVerify = ' ';
    int compterTour = 0;
    while (chrVerify != 'y')
    {
        // Clear the console
        Console.Clear();

        // Change the color
        Console.ForegroundColor = ConsoleColor.Green;

        // Line break
        Console.WriteLine();
        Console.WriteLine();

        // Title display
        Console.WriteLine("\t  ___  _  _   __    __   ____  ____    _  _  __   _  _  ____    _  _  ____  ____  ____  __ _   __   _  _  ____");
        Console.WriteLine("\t / __)/ )( \\ /  \\  /  \\ / ___)(  __)  ( \\/ )/  \\ / )( \\(  _ \\  / )( \\/ ___)(  __)(  _ \\(  ( \\ / _\\ ( \\/ )(  __)");
        Console.WriteLine("\t( (__ ) __ ((  O )(  O )\\___ \\ ) _)    )  /(  O )) \\/ ( )   /  ) \\/ (\\___ \\ ) _)  )   //    //    \\/ \\/ \\ ) _)");
        Console.WriteLine("\t \\___)\\_)(_/ \\__/  \\__/ (____/(____)  (__/  \\__/ \\____/(__\\_)  \\____/(____/(____)(__\\_)\\_)__)\\_/\\_/\\_)(_/(____)");

        // Ask for the username
        Console.Write("\n\n\tYour username: ");
        if (compterTour != 0)
        {
            // Condition
            if (chrVerify == 's')
            {
                // Red color
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tYour username must be longer than three characters");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                if (chrVerify == 'l')
                {
                    // Red color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tYour username must be shorter than twenty characters");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        Console.SetCursorPosition(23, 8);
        chrVerify = 'y';
        // Read the username and put it in the variable
        player.Name = Console.ReadLine();

        // Check the length of the username
        // If it's shorter than 3 characters
        if (player.Name.Length < 3)
        {
            // Put 's' in chrVerify
            chrVerify = 's';
        }
        else
        {
            // If it's longer than 20 characters
            if (player.Name.Length > 20)
            {
                // Put 'l' in chrVerify
                chrVerify = 'l';
            }
            else
            {
                // Put 'x' in chrVerify
                chrVerify = 'y';
            }
        }
        compterTour++;
    }

    // Confirm the username
    Console.SetCursorPosition(23, 8);

    // Delete the text
    Console.WriteLine("\n\t                                                                                             ");
    Console.SetCursorPosition(23, 8);

    // Confirm the username
    Console.Write("\n\tYour username is valid. \n\tPress Esc to go to the main menu or Enter to start the game.");

    // Verify if the player press Esc
    while (true)
    {
        switch (Console.ReadKey().Key)
        {
            // If the player press escape
            case ConsoleKey.Escape:
                // Go to the menu
                DisplayMenu();
                break;
            // If the player press enter
            case ConsoleKey.Enter:
                // Start the game
                NewGame();
                break;
        }
        Console.SetCursorPosition(68, 10);
        Console.WriteLine(" ");
        Console.SetCursorPosition(68, 10);
    }
}

/*
 * Name : SelectSettings
 * 
 * Description :
 * This method display the settings. It saves
 * the modifications of the player.
 */
void SelectSettings()
{
    // Verify variable
    byte bytPositionYSettings = 11;

    // Clear the console
    Console.Clear();

    // Change the color
    Console.ForegroundColor = ConsoleColor.Green;

    // Line breaks
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\t ___  ____  ____  ____  ____  _  _  ___  ___");
    Console.WriteLine("\t/ __)( ___)(_  _)(_  _)(_  _)( \\( )/ __)/ __)");
    Console.WriteLine("\t\\__ \\ )__)   )(    )(   _)(_  )  (( (_-.\\__ \\");
    Console.WriteLine("\t(___/(____) (__)  (__) (____)(_)\\_)\\___/(___/");

    // Give information
    Console.WriteLine("\n\n\tSelect your settings and press Enter to change it !");

    // Display the state of the music
    Console.Write("\n\n\t\tMusic : ");
    if (bolVolume == true)
    {
        Console.Write("\tON");
    }
    else
    {
        Console.Write("\tOFF");
    }

    // Display the difficulty
    Console.Write("\n\n\t\tDifficulty : ");
    if (bytDifficulty == 1)
    {
        Console.Write("\tPADAWAN");
    }
    else
    {
        Console.Write("\tJEDI");
    }

    // Verify the key of the player
    while (true)
    {
        // Arrow display
        Console.SetCursorPosition(0, bytPositionYSettings);
        Console.Write("\t---->");

        // Can't write character
        Console.SetCursorPosition(12, bytPositionYSettings);
        Console.Write("");

        // Verify the key
        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.UpArrow:
                if (bytPositionYSettings == 11)
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t      ");
                    bytPositionYSettings = 13;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t      ");
                    bytPositionYSettings = 11;
                    break;
                }

            // If the player press the down arrow
            case ConsoleKey.DownArrow:
                if (bytPositionYSettings == 11)
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t      ");
                    bytPositionYSettings = 13;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t      ");
                    bytPositionYSettings = 11;
                    break;
                }

            // If the player press enter
            case ConsoleKey.Enter:
                // Verify the position of the arrow
                switch (bytPositionYSettings)
                {
                    case 11:
                        if (bolVolume == true)
                        {
                            bolVolume = false;
                            Console.SetCursorPosition(32, 11);
                            Console.Write("OFF");
                        }
                        else
                        {
                            bolVolume = true;
                            Console.SetCursorPosition(32, 11);
                            Console.Write("ON ");
                        }
                        break;

                    case 13:
                        if (bytDifficulty == 1)
                        {
                            bytDifficulty = 2;
                            Console.SetCursorPosition(32, 13);
                            Console.Write("JEDI   ");
                        }
                        else
                        {
                            bytDifficulty = 1;
                            Console.SetCursorPosition(32, 13);
                            Console.Write("PADAWAN");
                        }
                        break;
                }
                break;

            // If the player press the enter key
            case ConsoleKey.Escape:
                DisplayMenu();
                break;
        }
    }
}

/*
 * Name : SelectScore
 * 
 * Description :
 * This method display the score of the
 * differents players.
 */
void SelectScore()
{
    // Clear the console
    Console.Clear();

    // Change the color
    Console.ForegroundColor = ConsoleColor.Green;

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\t ___   ___  _____  ____  ____");
    Console.WriteLine("\t/ __) / __)(  _  )(  _ \\( ___)");
    Console.WriteLine("\t\\__ \\( (__  )(_)(  )   / )__)");
    Console.WriteLine("\t(___/ \\___)(_____)(_)\\_)(____)");

    while (true)
    {
        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.Escape:
                DisplayMenu();
                break;
        }
        Console.SetCursorPosition(65, 9);
        Console.WriteLine(" ");
        Console.SetCursorPosition(65, 9);
    }
}

/*
 * Name : SelectAbout
 * 
 * Description :
 * This method display the description on
 * the game.
 */
void SelectAbout()
{
    // Clear the console
    Console.Clear();

    // Change the color
    Console.ForegroundColor = ConsoleColor.Green;

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\t  __   ____   __   _  _  ____");
    Console.WriteLine("\t / _\\ (  _ \\ /  \\ / )( \\(_  _)");
    Console.WriteLine("\t/    \\ ) _ ((  O )) \\/ (  )(");
    Console.WriteLine("\t\\_/\\_/(____/ \\__/ \\____/ (__)");

    Console.WriteLine("\n\n\tWe will tell you some informations about the game ! (In french)");

    Console.WriteLine("\tCe projet a été fait dans le cadre du P_Dev.");
    Console.WriteLine("\tC'est la parodie du célèbre jeu \"Space Invaders\". Nous le reproduisons en mode console grâce au langage C#.");
    Console.WriteLine("\tLe jeu possède deux difficultés. Elles peuvent être changées dans le menu \"Settings\" accessible depuis le menu principal.");
    Console.WriteLine("\tUne fois en jeu, une horde d'aliens va faire des allers retour de droite à gauche et à chaques traversées, elle va descendre.");
    Console.WriteLine("\tLe but du jeu est de déplacer son vaisseau de droite à gauche afin d'éliminer tous les aliens avant qu'ils touchent le sol.");
    Console.WriteLine("\tLe joueur doit donc éviter les tirs des aliens en se cachant derrière des obstacles et tous les éliminer");
    Console.WriteLine("\tgrâce à ses tirs !");
    Console.WriteLine("\n\tGood luck !");

    Console.WriteLine("\n\tPress Esc to go to the main menu.");

    // Verify the key
    while (true)
    {
        switch (Console.ReadKey(true).Key)
        {
            // If the player press the up arrow
            case ConsoleKey.Escape:
                DisplayMenu();
                break;
        }
    }
}

/*
 * Name : SelectExit
 * 
 * Description :
 * This method quit the application.
 */
void SelectExit()
{
    // Clear the console
    Console.Clear();

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\tSee you soon !");

    // Close the programm
    Environment.Exit(0);
}

/*
 * Name : NewGame
 * 
 * Description :
 * This method start the game, creates
 * the aliens, obstacles and the timers.
 */
void NewGame()
{
    // Clear the console
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Green;

    // Write the header
    // Write username
    Console.SetCursorPosition(4, 2);
    Console.Write("Username : ");
    Console.Write(player.Name);

    // Write lives
    Console.SetCursorPosition(34, 2);
    Console.Write("Lives : ");

    // for to write all the hearts
    Console.ForegroundColor = ConsoleColor.Red;
    for (byte x = 0; x < ship.Health; x++)
    {
        Console.Write("♥");
    }
    Console.ForegroundColor = ConsoleColor.Green;

    // Write score
    Console.SetCursorPosition(49, 2);
    Console.Write("Score : ");
    Console.Write(player.Score);

    // Line break
    Console.WriteLine("");
    Console.WriteLine("");

    // Write "_" all the width
    for (int x = 0; x < INTLARGEUR; x++)
    {
        Console.Write("_");
    }

    // locationX of aliens
    byte bytLocationX = 2;

    // Create aliens
    for (byte x = 0; x < 10; x++)
    {
        if (x < 5)
        {
            Alien alien = new Alien(x, bytLocationX, 12, true);
            listAliveAliens.Add(alien);
            bytLocationX += 14;

            if (x == 4)
            {
                bytLocationX = 2;
            }
        }
        else
        {
            Alien alien = new Alien(x, bytLocationX, 6, true);
            listAliveAliens.Add(alien);
            bytLocationX += 14;
        }
    }

    // Display Aliens
    foreach (Alien alien in listAliveAliens)
    {
        Console.SetCursorPosition(alien.LocationX, alien.LocationY);
        Console.WriteLine("▄ ▀▄   ▄▀ ▄");
        Console.SetCursorPosition(alien.LocationX, alien.LocationY + 1);
        Console.WriteLine("█▄███████▄█");
        Console.SetCursorPosition(alien.LocationX, alien.LocationY + 2);
        Console.WriteLine("███▄███▄███");
        Console.SetCursorPosition(alien.LocationX, alien.LocationY + 3);
        Console.WriteLine("▀█████████▀");
        Console.SetCursorPosition(alien.LocationX, alien.LocationY + 4);
        Console.WriteLine(" ▄▀     ▀▄");
    }

    ship.LocationY = Console.WindowHeight - 8;

    // Display ship
    Console.SetCursorPosition(ship.LocationX, ship.LocationY);
    Console.WriteLine("    █    ");
    Console.SetCursorPosition(ship.LocationX, ship.LocationY + 1);
    Console.WriteLine("  █████  ");
    Console.SetCursorPosition(ship.LocationX, ship.LocationY + 2);
    Console.WriteLine("█████████");
    Console.SetCursorPosition(ship.LocationX, ship.LocationY + 3);
    Console.WriteLine("█████████");

    if (bolFirstGameVerify == true)
    {
        // Creation of the obstacles
        Obstacle obstacle1 = new Obstacle(10, 50, 3);
        listObstacles.Add(obstacle1);
        Obstacle obstacle2 = new Obstacle(60, 50, 3);
        listObstacles.Add(obstacle2);
        Obstacle obstacle3 = new Obstacle(110, 50, 3);
        listObstacles.Add(obstacle3);
        Obstacle obstacle4 = new Obstacle(160, 50, 3);
        listObstacles.Add(obstacle4);
    }

    // Display obstacle
    foreach (Obstacle obstacle in listObstacles)
    {
        if (obstacle.Health == 3)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (obstacle.Health == 2)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else if (obstacle.Health == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
        Console.Write("██████████████████████████████");
        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
        Console.Write("██████████████████████████████");
    }

    if (bolFirstGameVerify == true)
    {
        // Timer to move the player's shot
        Timer shotTimer = new Timer(new TimerCallback(ShotPlayer));
        shotTimer.Change(0, 80);
        listTimer.Add(shotTimer);

        // Timer to do a break between alien moves
        Timer moveTimer = new Timer(new TimerCallback(MoveAliens));
        if (bytDifficulty == 1)
        {
            moveTimer.Change(0, 200);
        }
        if (bytDifficulty == 2)
        {
            moveTimer.Change(0, 100);
        }
        listTimer.Add(moveTimer);

        // Timer to move the alien's shot
        Timer alienShotTimer = new Timer(new TimerCallback(ShotAliens));
        alienShotTimer.Change(0, 80);
        listTimer.Add(alienShotTimer);

        // Timer for alien shots
        Timer chooseAlienTimer = new Timer(new TimerCallback(ChooseAlien));
        if (bytDifficulty == 1)
        {
            chooseAlienTimer.Change(0, 2000);
        }
        if (bytDifficulty == 2)
        {
            chooseAlienTimer.Change(0, 300);
        }
        listTimer.Add(chooseAlienTimer);
    }

    // Read the keys
    while (true)
    {
        switch (Console.ReadKey(true).Key)
        {
            // If the player press the spacebar
            case ConsoleKey.Spacebar:
                if (listShot.Count == 0)
                {
                    // Create a new shot
                    Shot shot = new Shot(ship.LocationX + 4, 53);
                    // Add the shot to the list
                    listShot.Add(shot);

                    // Display the missile at the right position
                    Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                break;

            // If the player press the left arrow
            case ConsoleKey.LeftArrow:
                if (ship.LocationX > 1)
                {
                    // Move the player to the left
                    Console.MoveBufferArea(ship.LocationX, Console.WindowHeight - 8, 9, 4, ship.LocationX - 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    ship.LocationX -= 1;
                }
                break;

            // If the player press the right arrow
            case ConsoleKey.RightArrow:
                if (ship.LocationX < INTLARGEUR - 10)
                {
                    // Move the player to the right
                    Console.MoveBufferArea(ship.LocationX, Console.WindowHeight - 8, 9, 4, ship.LocationX + 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    ship.LocationX += 1;
                }
                break;
        }
    }
}

/*
 * Name : MoveAliens
 * 
 * Description :
 * The method of the timermoveTimer
 * moves the aliens.
 */
void MoveAliens(object state)
{
    bolFirstGameVerify = false;

    // Stop the game and the timers if the aliens are on the finish
    foreach (Alien alien in listAliveAliens)
    {
        if (alien.LocationY >= 40)
        {
            foreach (Timer timer in listTimer)
            {
                timer.Dispose();
            }
            GameOver();
        }
    }

    // Verify if the aliens are full right or left
    foreach (Alien aliens in listAliveAliens)
    {
        if (aliens.LocationY == 60)
        {

        }
        else
        {
            // If the aliens touch the right limit
            if (direction == "right")
            {
                if (aliens.LocationX >= INTLARGEUR - 13)
                {
                    advance = true;
                }
            }
            // If the aliens touch the left limit
            else if (direction == "left")
            {
                if (aliens.LocationX <= 2)
                {
                    advance = true;
                }
            }
        }
    }

    // Move the aliens to the bottom
    if (advance)
    {
        foreach (Alien aliens in listAliveAliens)
        {
            Console.MoveBufferArea(aliens.LocationX, aliens.LocationY, 12, 5, aliens.LocationX, aliens.LocationY + 3);
            aliens.LocationY += 3;
        }

        if (direction == "right")
        {
            direction = "left";
        }
        else if (direction == "left")
        {
            direction = "right";
        }

        advance = false;
    }
    // Move the aliens right or left
    else
    {
        // Move the aliens to the right
        if (direction == "right")
        {
            foreach (Alien alien in listAliveAliens)
            {
                Console.MoveBufferArea(alien.LocationX, alien.LocationY, 12, 5, alien.LocationX + 2, alien.LocationY);
                alien.LocationX += 2;
            }
        }
        // Move the aliens to the left
        else if (direction == "left")
        {
            foreach (Alien alien in listAliveAliens)
            {
                Console.MoveBufferArea(alien.LocationX, alien.LocationY, 12, 5, alien.LocationX - 2, alien.LocationY);
                alien.LocationX -= 2;
            }
        }
    }
}

/*
 * Name : ShotPlayer
 * 
 * Description :
 * The method of the shotTimer
 * moves the shots of the player.
 */
void ShotPlayer(object state)
{
    if (listShot.Count > 0)
    {
        foreach (Shot shot in listShot.ToArray())
        {
            // Move the shot of the player to the top
            shot.LocationY -= 1;
            Console.MoveBufferArea(shot.LocationX, shot.LocationY + 1, 1, 1, shot.LocationX, shot.LocationY);
            if (shot.LocationY < 7)
            {
                Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                Console.Write(" ");
                listShot.Remove(shot);
            }

            foreach (Alien alien in listAliveAliens)
            {   
                // Verify if the shot touch an alien
                if (shot.LocationX >= alien.LocationX && shot.LocationX <= alien.LocationX + 12 && shot.LocationY >= alien.LocationY && shot.LocationY <= alien.LocationY + 5)
                {
                    // Delete Alien
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY);
                    Console.Write("            ");
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY+1);
                    Console.Write("            ");
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY+2);
                    Console.Write("            ");
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY+3);
                    Console.Write("            ");
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY+4);
                    Console.Write("            ");
                    Console.SetCursorPosition(alien.LocationX, alien.LocationY+5);
                    Console.Write("            ");

                    // Remove the alien from the lists
                    listAliveAliens.Remove(alien);
                    listAliensCanShoot.Remove(alien);

                    // Add score to the player
                    player.Score = player.Score + 100;
                    Console.SetCursorPosition(57, 2);
                    Console.Write(player.Score);

                    // Delete Shot
                    Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                    Console.Write(" ");
                    listShot.RemoveAt(0);

                    // If all aliens are dead it starts a new game
                    if (listAliveAliens.Count == 0)
                    {
                        NewGame();
                    }

                    break;
                }
            }

            foreach (Obstacle obstacle in listObstacles)
            {
                // Verify if the shot touch an obstacle
                if (shot.LocationX >= obstacle.LocationX && shot.LocationX <= obstacle.LocationX + 30 && shot.LocationY >= obstacle.LocationY && shot.LocationY <= obstacle.LocationY + 1)
                {
                    // Delete Shot
                    Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                    Console.Write(" ");
                    listShot.RemoveAt(0);


                    // Change the health of the obstacle
                    if (obstacle.Health == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                        Console.Write("██████████████████████████████");
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                        Console.Write("██████████████████████████████");
                    }
                    else if (obstacle.Health == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                        Console.Write("██████████████████████████████");
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                        Console.Write("██████████████████████████████");
                    }
                    else if (obstacle.Health == 1)
                    {
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                        Console.Write("                              ");
                        Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                        Console.Write("                              ");
                    }
                    obstacle.Health -= 1;

                    // Verify if the obstacle is destroy
                    if (obstacle.Health <= 0)
                    {
                        // Delete the obstacle from the list
                        listObstacles.Remove(obstacle);
                    }

                    break;
                }
            }
        }
    }
}

/*
 * Name : ShotAliens
 * 
 * Description :
 * The method of the alienShotTimer
 * moves the shots of the alien.
 */
void ShotAliens(object state)
{
    foreach (Shot shot in listShotAliens.ToArray())
    {
        // Remove the shot if it touch the bottom
        if (shot.LocationY >= 60)
        {
            Console.SetCursorPosition(shot.LocationX, shot.LocationY);
            Console.Write(" ");
            listShotAliens.Remove(shot);
        }
        else
        {
            // Verify if it touch the player
            if (shot.LocationX >= ship.LocationX && shot.LocationX <= ship.LocationX + 9 && shot.LocationY >= ship.LocationY - 1 && shot.LocationY <= ship.LocationY + 4)
            {
                // Delete the shot
                Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                Console.Write(" ");
                listShotAliens.Remove(shot);

                // Reduce the health of the ship
                if (ship.Health == 3)
                {
                    Console.SetCursorPosition(44, 2);
                    Console.Write(" ");
                    ship.Health = ship.Health - 1;
                }
                else if (ship.Health == 2)
                {
                    Console.SetCursorPosition(43, 2);
                    Console.Write(" ");
                    ship.Health = ship.Health - 1;
                }
                else if (ship.Health == 1)
                {
                    // Stop the timers and the game if the ship is destroyed
                    foreach (Timer timer in listTimer)
                    {
                        timer.Dispose();
                    }
                    GameOver();
                }
            }
            else
            {
                // Move the shot to the bottom
                Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.Green;

                shot.LocationY += 1;
                Console.MoveBufferArea(shot.LocationX, shot.LocationY - 1, 1, 1, shot.LocationX, shot.LocationY);
            }
        }

        foreach (Obstacle obstacle in listObstacles)
        {
            // Verify if the missile touched an obstacle
            if (shot.LocationX >= obstacle.LocationX && shot.LocationX <= obstacle.LocationX + 30 && shot.LocationY >= obstacle.LocationY && shot.LocationY <= obstacle.LocationY + 1)
            {
                // Delete Shot
                Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                Console.Write(" ");
                listShotAliens.Remove(shot);


                // Change the health of the obstacle
                if (obstacle.Health == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                    Console.Write("██████████████████████████████");
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                    Console.Write("██████████████████████████████");
                }
                else if (obstacle.Health == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                    Console.Write("██████████████████████████████");
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                    Console.Write("██████████████████████████████");
                }
                else if (obstacle.Health == 1)
                {
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY);
                    Console.Write("                              ");
                    Console.SetCursorPosition(obstacle.LocationX, obstacle.LocationY + 1);
                    Console.Write("                              ");
                }
                obstacle.Health -= 1;

                // Verify if the obstacle is destroyed
                if (obstacle.Health <= 0)
                {
                    // Delete the obstacle from the list
                    listObstacles.Remove(obstacle);
                }

                break;
            }
        }
    }
}

/*
 * Name : ChooseAlien
 * 
 * Description :
 * The method of the chooseAlienTimer
 * choose a random alien to shoot.
 */
void ChooseAlien(object state)
{
    Random rnd = new Random();                                          // Random variable
    int num;                                                            // Valeure aléatoire
    byte bytNumberOfAliens = Convert.ToByte(listAliveAliens.Count);     // Number of aliens alive
    bool bolAlienDown = false;                                          // Verify if a bottom alien is still alive

    foreach (Alien alien in listAliveAliens)
    {
        for (byte x = 0; x < bytNumberOfAliens; x++)
        {
            // Verify if a bottom alien is alive and put it in a list
            if (alien.LocationY > listAliveAliens[x].LocationY)
            {
                listAliensCanShoot.Add(alien);
                bolAlienDown = true;
            }
            else
            {
                // Add all the top aliens
                if (bolAlienDown == false)
                {
                    listAliensCanShoot.Add(alien);
                }
            }
        }
    }

    // Generate a random number to choose the shooting alien
    num = rnd.Next(listAliensCanShoot.Count);

    foreach (Alien alien in listAliveAliens)
    {
        if (alien == listAliensCanShoot[num])
        {
            // Make the alien shoot
            Shot shot = new Shot(alien.LocationX + 5, alien.LocationY + 4);
            listShotAliens.Add(shot);
        }
    }
}

/*
 * Name : ShotPlayer
 * 
 * Description :
 * This method display the Game Over
 * screen and the score of the player.
 */
void GameOver()
{
    // Clear the console
    Console.Clear();

    // Position of the cursor at the start
    Console.SetCursorPosition(0, 0);

    // Change the color
    Console.ForegroundColor = ConsoleColor.Green;

    // Line break
    Console.WriteLine();
    Console.WriteLine();

    // Title display
    Console.WriteLine("\t  /$$$$$$                                           /$$$$$$");
    Console.WriteLine("\t /$$__  $$                                         /$$__  $$");
    Console.WriteLine("\t| $$  \\__/  /$$$$$$  /$$$$$$/$$$$   /$$$$$$       | $$  \\ $$ /$$    /$$ /$$$$$$   /$$$$$$");
    Console.WriteLine("\t| $$ /$$$$ |____  $$| $$_  $$_  $$ /$$__  $$      | $$  | $$|  $$  /$$//$$__  $$ /$$__  $$");
    Console.WriteLine("\t| $$|_  $$  /$$$$$$$| $$ \\ $$ \\ $$| $$$$$$$$      | $$  | $$ \\  $$/$$/| $$$$$$$$| $$  \\__/");
    Console.WriteLine("\t| $$  \\ $$ /$$__  $$| $$ | $$ | $$| $$_____/      | $$  | $$  \\  $$$/ | $$_____/| $$");
    Console.WriteLine("\t|  $$$$$$/|  $$$$$$$| $$ | $$ | $$|  $$$$$$$      |  $$$$$$/   \\  $/  |  $$$$$$$| $$");
    Console.WriteLine("\t \\______/  \\_______/|__/ |__/ |__/ \\_______/       \\______/     \\_/    \\_______/|__/");

    // Write the score of the player
    Console.Write("\n\n\tYour score : " + player.Score);

    // Write indications
    Console.Write("\n\n\tPress Esc to go to the menu.");

    // Put the First game to true
    bolFirstGameVerify = true;

    // Verify the key
    switch (Console.ReadKey(true).Key)
    {
        // If the player press the up arrow
        case ConsoleKey.Escape:
            DisplayMenu();
            break;
    }
}