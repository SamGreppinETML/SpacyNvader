using System.Runtime.CompilerServices;
using Classes;
using System.Threading;
using WMPLib;

///// Variable declaration /////

byte bytPositionY = 15;                                                     // Position Y of the arrow
bool bolVolume = true;                                                      // Volume of the music
byte bytDifficulty = 1;                                                     // Difficulty of the game
const int INTLARGEUR = 200;                                                 // Width of the game
List<Alien> listAliveAliens = new List<Alien>();                            // Alien list
List<Shot> listShot = new List<Shot>();                                     // Shot list
List<Obstacle> listObstacles = new List<Obstacle>();                        // Obstacle list
bool advance = false;                                                       // Advance of the aliens
string direction = "right";                                                 // Direction of the aliens
Player player = new Player("x", 0);                                         // Creation of the player
Ship ship= new Ship(INTLARGEUR / 2, Console.WindowHeight - 8, 3, true);     // Creation of the ship
Shot shot = new Shot(ship.LocationX + 4, Console.WindowHeight - 9);         // Creation of a missile
bool bolFirstGameVerify = true;                                             // Verify if it's the first game

///// Main code /////

// Open the Window full size
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

// Play Music
WindowsMediaPlayer wMPPlayer = new WindowsMediaPlayer();
Directory.SetCurrentDirectory(@"..\..\..\bin\Debug\net6.0\");
wMPPlayer.URL = Directory.GetCurrentDirectory() + @"\chad.mp3";

// Call DisplayMenu()
DisplayMenu();

// Display the menu
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

// Select the username
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

// Open settings
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

// Select score
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

// Select about
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
        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.Escape:
                DisplayMenu();
                break;
        }
        Console.SetCursorPosition(0, 20);
        Console.WriteLine(" ");
        Console.SetCursorPosition(0, 20);
    }
}

// Select exit
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

// New game
void NewGame()
{
    // Clear the console
    Console.Clear();

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
            Alien alien = new Alien(x, bytLocationX, 12, true, true);
            listAliveAliens.Add(alien);
            bytLocationX += 14;

            if (x == 4)
            {
                bytLocationX = 2;
            }
        }
        else
        {
            Alien alien = new Alien(x, bytLocationX, 6, true, true);
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
        // Timer to do a break between alien moves
        Timer moveTimer = new Timer(new TimerCallback(MoveAliens));
        moveTimer.Change(0, 200);

        // Timer to do a break between alien moves
        Timer shotTimer = new Timer(new TimerCallback(ShotPlayer));
        shotTimer.Change(0, 80);
    }

    // Shot
    while (true)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Spacebar:
                if (listShot.Count == 0)
                {
                    Shot shot = new Shot(ship.LocationX + 4, 53);
                    listShot.Add(shot);

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
                    Console.MoveBufferArea(ship.LocationX, Console.WindowHeight - 8, 9, 4, ship.LocationX - 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    ship.LocationX -= 1;
                }
                break;

            case ConsoleKey.RightArrow:
                if (ship.LocationX < INTLARGEUR - 10)
                {
                    Console.MoveBufferArea(ship.LocationX, Console.WindowHeight - 8, 9, 4, ship.LocationX + 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    ship.LocationX += 1;
                }
                break;
        }
    }
}

void MoveAliens(object state)
{
    bolFirstGameVerify = false;

    // Move aliens
    foreach (Alien aliens in listAliveAliens)
    {
        if (aliens.LocationY == 60)
        {

        }
        else
        {
            if (direction == "right")
            {
                if (aliens.LocationX >= INTLARGEUR - 13)
                {
                    advance = true;
                }
            }
            else if (direction == "left")
            {
                if (aliens.LocationX <= 2)
                {
                    advance = true;
                }
            }
        }
    }

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
    else
    {
        if (direction == "right")
        {
            foreach (Alien alien in listAliveAliens)
            {
                alien.Shootable = false;
                Console.MoveBufferArea(alien.LocationX, alien.LocationY, 12, 5, alien.LocationX + 2, alien.LocationY);
                alien.LocationX += 2;
                alien.Shootable = true;
            }
        }
        else if (direction == "left")
        {
            foreach (Alien alien in listAliveAliens)
            {
                alien.Shootable = false;
                Console.MoveBufferArea(alien.LocationX, alien.LocationY, 12, 5, alien.LocationX - 2, alien.LocationY);
                alien.LocationX -= 2;
                alien.Shootable = true;
            }
        }
    }
}

void ShotPlayer(object state)
{
    if (listShot.Count > 0)
    {
        foreach (Shot shot in listShot.ToArray())
        {
            shot.LocationY -= 1;
            Console.MoveBufferArea(shot.LocationX, shot.LocationY + 1, 1, 1, shot.LocationX, shot.LocationY);
            if (shot.LocationY < 7)
            {
                Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                Console.Write(" ");
                listShot.RemoveAt(0);
            }

            foreach (Alien alien in listAliveAliens)
            {
                if (shot.LocationX >= alien.LocationX && shot.LocationX <= alien.LocationX + 12 && shot.LocationY >= alien.LocationY && shot.LocationY <= alien.LocationY + 5 && alien.Shootable == true)
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
                    listAliveAliens.Remove(alien);


                    player.Score = player.Score + 100;
                    Console.SetCursorPosition(57, 2);
                    Console.Write(player.Score);

                    // Delete Shot
                    Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                    Console.Write(" ");
                    listShot.RemoveAt(0);

                    if (listAliveAliens.Count == 0)
                    {
                        NewGame();
                        
                    }

                    break;
                }
            }

            foreach (Obstacle obstacle in listObstacles)
            {
                if (shot.LocationX >= obstacle.LocationX && shot.LocationX <= obstacle.LocationX + 30 && shot.LocationY >= obstacle.LocationY && shot.LocationY <= obstacle.LocationY + 1)
                {
                    // Delete Shot
                    Console.SetCursorPosition(shot.LocationX, shot.LocationY);
                    Console.Write(" ");
                    listShot.RemoveAt(0);


                    // Hit obstacle
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

                    if (obstacle.Health <= 0)
                    {
                        listObstacles.Remove(obstacle);
                    }

                    break;
                }
            }
        }
    }
}

void GameOver()
{
    Console.Clear();
    Console.Write("You won !");
}