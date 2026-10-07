using MenuApp;
using System.Text;

var quit = false;

while (!quit)
{
    var choice = ReadMainMenuChoice();

    switch (choice)
    {
        case "0":
            quit = true;
            break;
        case "1":
            OnGetCinemaTicketPriceForPerson();
            break;
        case "2":
            OnGetCinemaTicketPriceForCompany();
            break;
        case "3":
            OnWriteUserInput(10);
            break;
        case "4":
            OnWriteThirdWordOfUserInput();
            break;
        default:
            WriteErrorMessage("Invalid choice. Please try again.");
            break;
    }
}

static string ReadMainMenuChoice()
{
    Console.WriteLine();
    Console.WriteLine("MAIN MENU");
    Console.WriteLine("---------");
    Console.WriteLine();
    Console.WriteLine("This is the Main menu. Please enter a choice between '1' and '4'. Enter '0' to quit the application");
    Console.WriteLine();
    Console.WriteLine("1. Get cinema ticket price for person.");
    Console.WriteLine("2. Get cinema ticket price for company.");
    Console.WriteLine("3. Write the user input 10 times.");
    Console.WriteLine("4. Write the third word of the user input.");
    Console.WriteLine("0. Quit");
    Console.WriteLine();
    Console.Write("Please enter a choice: ");
    var choice = Console.ReadLine();

    return choice ?? string.Empty;
}

static int ReadAge(string prompt)
{
    var ageInput = string.Empty;
    var age = 0;

    do
    {
        Console.Write(prompt);
        ageInput = Console.ReadLine();
    }
    while (int.TryParse(ageInput, out age) == false || age < 0);

    return age;
}

static int ReadCompanySize()
{
    var companySizeInput = string.Empty;
    var companySize = 0;

    do
    {
        Console.Write("Please enter the size of the company (minimum 2 people): ");
        companySizeInput = Console.ReadLine();
    }
    while (int.TryParse(companySizeInput, out companySize) == false || companySize < 2);

    return companySize;
}

static void WriteErrorMessage(string message)
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
    Console.WriteLine();
}

static void WriteInfoMessage(string message)
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
    Console.WriteLine();
}

static void OnGetCinemaTicketPriceForPerson()
{
    Console.WriteLine();
    var age = ReadAge("Please enter the age: ");

    var person = new Person(age);
    var ticketPrice = person.GetTicketPrice();
    
    WriteInfoMessage($"The ticket price for the person is {ticketPrice:C}");
}

static void OnGetCinemaTicketPriceForCompany()
{
    Console.WriteLine();
    var companySize = ReadCompanySize();

    var company = new Company(companySize);

    for (var i = 1; i <= companySize; i++)
    {
        var age = ReadAge($"Please enter the age for person {i}: ");
        company.AddPerson(new Person(age));
    }

    var companyTicketPrice = company.GetTicketPrice();
    WriteInfoMessage($"The ticket price for the company of {company.Size} people is {companyTicketPrice:C}");
}

static void OnWriteUserInput(int n)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine($"Please enter a line of text:");
        var userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            WriteErrorMessage("Input cannot be empty. Please try again.");
            continue;
        }

        Console.WriteLine();

        // Use the StringBuilder class to efficiently build the output string with the user input to be used in the WriteInfoMessage method.
        var stringBuilder = new StringBuilder();

        var i = 1;
        for (; i <= n - 1; i++)
        {
            stringBuilder.Append($"{i}. {userInput}, ");
        }
        stringBuilder.Append($"{i}. {userInput}");

        WriteInfoMessage(stringBuilder.ToString());
        break;
    }
}

static void OnWriteThirdWordOfUserInput()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Please enter a line of text:");
        var userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            WriteErrorMessage("Input cannot be empty. Please try again.");
            continue;
        }

        var words = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (words.Length < 3)
        {
            WriteErrorMessage("Input must contain at least three words. Please try again.");
            continue;
        }

        WriteInfoMessage($"The third word is: {words[2].Trim()}"); // Use String.Trim method to remove any leading or trailing whitespace from the third word.
        break;
    }
}
