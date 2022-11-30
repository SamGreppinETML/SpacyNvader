﻿using System.Runtime.CompilerServices;
using Classes;
using System.Threading;

///// Variable declaration /////

byte bytPositionY = 15;                                             // Position Y of the arrow
string strPlayerUsername = "";                                      // Username of the current player
bool bolVolume = true;                                              // Volume of the music
byte bytDifficulty = 1;                                             // Difficulty of the game
byte bytPlayerLives = 3;                                            // Lives of the player
int intPlayerScore = 0;                                             // Score of the player
List<Alien> listAliveAliens = new List<Alien>();                    // Alien list

///// Main code /////

// Open the Window full size
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

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
        strPlayerUsername = Console.ReadLine();

        // Check the length of the username
        // If it's shorter than 3 characters
        if (strPlayerUsername.Length < 3)
        {
            // Put 's' in chrVerify
            chrVerify = 's';
        }
        else
        {
            // If it's longer than 20 characters
            if (strPlayerUsername.Length > 20)
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
    // Verify variable
    byte bytPositionYSettings = 11;

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
    Console.Write("\n\n\tUsername : ");
    Console.Write(strPlayerUsername);

    // Write lives
    Console.Write("\t\tLives : ");

    // for to write all the hearts
    Console.ForegroundColor = ConsoleColor.Red;
    for (byte x = 0; x < bytPlayerLives; x++)
    {
        Console.Write("♥");
    }
    Console.ForegroundColor = ConsoleColor.Green;

    // Write score
    Console.Write("\t\tScore : ");
    Console.Write(intPlayerScore);

    // Line break
    Console.WriteLine("");
    Console.WriteLine("");

    // Capture the width of the console
    int intConsoleWidth = Console.WindowWidth;

    // Write "_" all the width
    for (int x = 0; x < intConsoleWidth; x++)
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
            Alien alien = new Alien(x, bytLocationX, 6, true);
            listAliveAliens.Add(alien);
            bytLocationX += 14;

            if (x == 4)
            {
                bytLocationX = 2;
            }
        }
        else
        {
            Alien alien = new Alien(x, bytLocationX, 12, true);
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

    // Display ship
    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 8);
    Console.WriteLine("    █    ");
    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 7);
    Console.WriteLine("  █████  ");
    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 6);
    Console.WriteLine("█████████");
    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 5);
    Console.WriteLine("█████████");

    // Timer to do a break between alien moves
    //Timer timer = new Timer(new TimerCallback(MoveAliens));
    //timer.Change(0, 200);

    // Move the player
    MovePlayer();
}

void MoveAliens(object state)
{
    // Counter
    byte bytCompteur = 0;

    // Move aliens
    foreach (Alien aliens in listAliveAliens)
    {
         Console.MoveBufferArea(listAliveAliens[bytCompteur].LocationX, listAliveAliens[bytCompteur].LocationY, 12, 5, listAliveAliens[bytCompteur].LocationX + 2, listAliveAliens[bytCompteur].LocationY);
        listAliveAliens[bytCompteur].LocationX += 2;
        bytCompteur += 1;
    }
}

void MovePlayer()
{
    byte bytPlayerLocation = Convert.ToByte(Console.WindowWidth / 2);   // Default player locyation

    while (true)
    {
        // Thread.Sleep(1);

        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.LeftArrow:
                if (bytPlayerLocation >= 2)
                {
                    Console.MoveBufferArea(bytPlayerLocation, Console.WindowHeight - 8, 9, 4, bytPlayerLocation - 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    bytPlayerLocation -= 1;
                }
                break;

            case ConsoleKey.RightArrow:
                if (bytPlayerLocation <= Console.WindowWidth - 11)
                {
                    Console.MoveBufferArea(bytPlayerLocation, Console.WindowHeight - 8, 9, 4, bytPlayerLocation + 1, Console.WindowHeight - 8);
                    // Change the location of the player
                    bytPlayerLocation += 1;
                }
                break;
        }
    }
}