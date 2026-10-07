

var quit = false;

while (!quit)
{
    WriteMainMenu();
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            quit = true;
            break;
        case "1":
            break;
        case "2":
            break;
        case "3":
            break;
        default:
            WriteInvalidChoiceMessage();
            break;
    }

    Console.WriteLine();
}

static void WriteMainMenu()
{
    Console.WriteLine("Main menu");
    Console.WriteLine("---------");
    Console.WriteLine();
    Console.WriteLine("This is the Main menu. Enter your choice '1' - '3'. Enter '0' to quit the application");
    Console.WriteLine();
    Console.WriteLine("1. Option 1");
    Console.WriteLine("2. Option 2");
    Console.WriteLine("3. Option 3");
    Console.WriteLine("0. Quit");
    Console.WriteLine();
    Console.Write("Please enter your choice: ");
}

static void WriteInvalidChoiceMessage()
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Invalid choice. Please try again.");
    Console.ResetColor();
    Console.WriteLine();
}
