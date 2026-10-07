

using MenuApp;

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
            OnEchoUserInput(10);
            break;
        default:
            WriteErrorMessage("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine();
}

static string ReadMainMenuChoice()
{
    Console.WriteLine("MAIN MENU");
    Console.WriteLine("---------");
    Console.WriteLine();
    Console.WriteLine("This is the Main menu. Please enter a choice between '1' and '3'. Enter '0' to quit the application");
    Console.WriteLine();
    Console.WriteLine("1. Get cinema ticket price for person.");
    Console.WriteLine("2. Get cinema ticket price for company.");
    Console.WriteLine("3. Write user input 10 times.");
    Console.WriteLine("0. Quit");
    Console.WriteLine();
    Console.Write("Please enter your choice: ");
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
        Console.Write("Please enter the size of the company: ");
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
    var age = ReadAge("Please enter the age: ");
    var person = new Person(age);
    var ticketPrice = Cinema.GetTicketPrice(person);
    WriteInfoMessage($"The ticket price for the person is {ticketPrice:C}");
}

static void OnGetCinemaTicketPriceForCompany()
{
    var companySize = ReadCompanySize();
    var company = new Company(companySize);

    for (var i = 1; i <= companySize; i++)
    {
        var age = ReadAge($"Please enter the age for person {i}: ");
        company.AddPerson(new Person(age));
    }

    var companyTicketPrice = company.GetTicketPrice();
    WriteInfoMessage($"The ticket price for the company of {companySize} people is {companyTicketPrice:C}");
}

static void OnEchoUserInput(int n)
{
    Console.WriteLine();
    Console.WriteLine($"Please enter a line of text to be written {n} times:");
    var userInput = Console.ReadLine();

    Console.WriteLine();

    var i = 0;
    for (; i < n - 1; i++)
    {
        Console.Write($"{i + 1}. {userInput}, ");
    }

    Console.WriteLine($"{i + 1}. {userInput}");
}
