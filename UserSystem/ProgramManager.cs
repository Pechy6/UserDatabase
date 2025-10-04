using System.Reflection.Metadata.Ecma335;
using UserSystem.obj;

namespace UserSystem;

public class ProgramManager
{
    UserManager userManager = new();
    private bool isRunning = true;
    private readonly UserValidator _userValidator = new();


    public void Run()
    {
        while (isRunning)
        {
            DisplayMainMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddUser();
                    break;
                case 2:
                    Console.Clear();
                    FindUser();
                    break;
                case 3:
                    isRunning = false;
                    break;
                case 4:
                    Console.Clear();
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ACTIONS 
    private void AddUser()
    {
        while (true)
        {
            DisplayUserMenu();

            if (!int.TryParse(Console.ReadLine(), out var typeChoice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (typeChoice == 4)
            {
                Console.Clear();
                return;
            }

            if (typeChoice is < 1 or > 4)
            {
                Console.WriteLine("Invalid type. Try again:");
                continue;
            }

            var (name, email) = GetUserInput();

            switch (typeChoice)
            {
                case 1:
                    userManager.AddUser(new RegularUser(name, email));
                    Console.WriteLine($"Regular user {name} has been created.");
                    Console.Clear();
                    break;
                case 2:
                    userManager.AddUser(new Moderator(name, email));
                    Console.Clear();
                    break;
                case 3:
                    userManager.AddUser(new Admin(name, email));
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }
    }

    private void FindUser()
    {
        while (true)
        {
            DisplayFindUser();

            int action;
            while (!int.TryParse(Console.ReadLine(), out action))
            {
                Console.WriteLine("Invalid input. Try again:");
                Console.WriteLine("You must enter a number.");
            }

            if (action > 7 || action <= 0)
            {
                continue;
            }

            DisplayFindUser();

            switch (action)
            {
                case 1:
                    Console.Clear();
                    FindUserByName();
                    DisplayContinue();
                    break;
                case 2:
                    Console.Clear();
                    FindUserById();
                    DisplayContinue();
                    break;
                case 3:
                    Console.Clear();
                    FindUserByEmail();
                    DisplayContinue();
                    break;
                case 4:
                    Console.Clear();
                    FindUserByDate();
                    DisplayContinue();
                    break;
                case 5:
                    Console.Clear();
                    userManager.WriteAllUsers();
                    DisplayContinue();
                    break;
                case 6:
                    Console.Clear();
                    RemoveUser();
                    DisplayContinue();
                    break;
                case 7:
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }
    }


    private void RemoveUser()
    {
        while (true)
        {
            DisplayRemoveUser();
            var id = _userValidator.GetValidId();
            var user = userManager.FindUserById(id);
            if (user is null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            userManager.RemoveUser(user);
            Console.WriteLine($"User {user.UserName} has been deleted.");
            return;
        }
    }

    // ACTION METHODS FOR FIND USER
    private void FindUserByName() // BY NAME
    {
        var name = _userValidator.GetValidName();
        var user = userManager.FindUserByName(name);
        if (user is null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.ShowDashboard();
    }

    private void FindUserById() // BY ID
    {
        Console.Write("Enter id: ");
        var id = _userValidator.GetValidId();
        var user = userManager.FindUserById(id);
        if (user is null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.ShowDashboard();
    }

    private void FindUserByEmail() // BY EMAIL
    {
        var email = _userValidator.GetValidEmail();
        var user = userManager.FindUserByEmail(email);
        if (user is null)
        {
            Console.WriteLine("User not found");
            return;
        }

        user.ShowDashboard();
    }

    private void FindUserByDate() // BY DATE
    {
        var date = _userValidator.GetValidDate();
        var user = userManager.FindUserByDate(date);
        if (user is null)
        {
            Console.WriteLine("User not found");
            return;
        }

        user.ShowDashboard();
    }

    // GET USER INPUT
    private (string name, string email) GetUserInput()
    {
        var name = _userValidator.GetValidName();
        var email = _userValidator.GetValidEmail();
        return (name, email);
    }


    // DISPLAY MENU
    private void DisplayMainMenu()
    {
        Console.WriteLine("USER SYSTEM made by Pechy6\n");
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("1. Add user");
        Console.WriteLine("2. Write all users");
        Console.WriteLine("3. Exit");
    }

    private void DisplayUserMenu()
    {
        Console.WriteLine("USER SYSTEM made by Pechy6\n");
        Console.WriteLine("CREAT USER");
        Console.WriteLine("1. Regular user\n2. Moderator\n3. Admin\n4.Back to main menu");
    }

    private void DisplayFindUser()
    {
        Console.WriteLine("USER SYSTEM made by Pechy6\n");
        Console.WriteLine("FIND USER");
        Console.WriteLine("1. Find by name");
        Console.WriteLine("2. Find by id");
        Console.WriteLine("3. Find by email");
        Console.WriteLine("4. Find by date of registration");
        Console.WriteLine("5. Find all users");
        Console.WriteLine("6. Remove user by id");
        Console.WriteLine("7. Back to main menu");
    }

    private void DisplayContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DisplayRemoveUser()
    {
        Console.WriteLine("Delete user by id:");
        Console.Write("Enter id: ");
    }
}