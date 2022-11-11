using System.Runtime.CompilerServices;

///// Variable declaration /////

byte bytPositionY = 15;   // Position Y of the arrow
string strPlayerUsername; // Username of the current player
bool bolVolume = true;    // Volume of the music
byte bytDifficulty = 1;      // Difficulty of the game

///// Main code /////

// Open the Window full size
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

// Call DisplayMenu()
DisplayMenu();

void DisplayMenu()
{
    while (true)
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



        // Arrow display
        Console.SetCursorPosition(0, bytPositionY);
        Console.WriteLine("\t          __");
        Console.WriteLine("\t _________\\ \\");
        Console.WriteLine("\t|_________   >");
        Console.WriteLine("\t          /_/");



        // Verify the key
        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.UpArrow:
                if (bytPositionY == 15)
                {
                    bytPositionY += 20;
                    break;
                }
                else
                {
                    bytPositionY -= 5;
                    break;
                }

            // If the player press the down arrow
            case ConsoleKey.DownArrow:
                if (bytPositionY == 35)
                {
                    bytPositionY -= 20;
                    break;
                }
                else
                {
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
    Console.WriteLine("\n\t                                                                                             ");
    Console.SetCursorPosition(23, 8);
    Console.Write("\n\tYour username is valid. Press Esc to go to the main menu.");

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

void SelectSettings()
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
    Console.WriteLine("\t ___  ____  ____  ____  ____  _  _  ___  ___");
    Console.WriteLine("\t/ __)( ___)(_  _)(_  _)(_  _)( \\( )/ __)/ __)");
    Console.WriteLine("\t\\__ \\ )__)   )(    )(   _)(_  )  (( (_-.\\__ \\");
    Console.WriteLine("\t(___/(____) (__)  (__) (____)(_)\\_)\\___/(___/");

    Console.WriteLine("\n\n\tSelect your settings and press Enter to change it !");

    Console.Write("\n\n\t\tMusic : ");
    if (bolVolume == true)
    {
        Console.Write("\tON");
    }
    else
    {
        Console.Write("\tOFF");
    }

    Console.Write("\n\n\t\tDifficulty : ");
    if (bytDifficulty == 1)
    {
        Console.Write("\tPADAWAN");
    }
    else
    {
        Console.Write("\tJEDI");
    }

    while (true)
    {
        // Arrow display
        Console.SetCursorPosition(0, bytPositionYSettings);
        Console.Write("\t---->");

        // Verify the key
        switch (Console.ReadKey().Key)
        {
            // If the player press the up arrow
            case ConsoleKey.UpArrow:
                if (bytPositionYSettings == 11)
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t     ");
                    bytPositionYSettings = 13;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t     ");
                    bytPositionYSettings = 11;
                    break;
                }

            // If the player press the down arrow
            case ConsoleKey.DownArrow:
                if (bytPositionYSettings == 11)
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t     ");
                    bytPositionYSettings = 13;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, bytPositionYSettings);
                    Console.Write("\t     ");
                    bytPositionYSettings = 11;
                    break;
                }

            // If the player press the enter key
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

void SelectScore()
{

}

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

void SelectExit()
{

}