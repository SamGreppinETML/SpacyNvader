///// Variable declaration /////

byte bytPositionY = 15; // Position Y of the arrow
string strPlayerUsername; // Username of the current player

///// Main code /////

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
        case ConsoleKey.UpArrow :
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
        case ConsoleKey.DownArrow :
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
        case ConsoleKey.Enter :
            // Verify the position of the arrow
            switch (bytPositionY)
            {
                // If the arrow is on Play
                case 15 :
                    do
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

                        // Read the username and put it in the variable
                        strPlayerUsername = Console.ReadLine();

                        // Check the length of the username
                        // If it's shorter than 3 characters
                        if (strPlayerUsername.Length < 3)
                        {
                            // Red color
                            Console.ForegroundColor = ConsoleColor.Red;
                            // Alert
                            Console.WriteLine("\tYour username must be longer than three characters\n\tPress enter to try again");
                            // Put the cursor at the start of the username
                            Console.SetCursorPosition(23, 8);
                            // Delete the username
                            Console.WriteLine("         ");
                            // Put the cursor at the start of the username
                            Console.SetCursorPosition(23, 8);
                            // Green color
                            Console.ForegroundColor = ConsoleColor.Green;
                            // Keep open
                            Console.ReadLine();
                        }
                        else
                        {
                            // If it's longer than 20 characters
                            if (strPlayerUsername.Length > 20)
                            {
                                // Red color
                                Console.ForegroundColor = ConsoleColor.Red;
                                // Alert
                                Console.WriteLine("\tYour username must be shorter than twenty characters\n\tPress enter to try again");
                                // Put the cursor at the start of the username
                                Console.SetCursorPosition(23, 8);
                                // Delete the username
                                Console.WriteLine("                                                                                                          ");
                                // Put the cursor at the start of the username
                                Console.SetCursorPosition(23, 8);
                                // Green color
                                Console.ForegroundColor = ConsoleColor.Green;
                                // Keep open
                                Console.ReadLine();
                            }
                            else
                            {
                                // Alert
                                Console.WriteLine("\tYour username is correct");
                                // Keep open
                                Console.ReadLine();
                            }
                        }
                    }
                    while (true == true);

                    Console.ReadLine();

                    break;
            }
            break;
    }
}