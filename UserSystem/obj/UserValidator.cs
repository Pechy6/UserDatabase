using System.Globalization;

namespace UserSystem.obj;

public class UserValidator
{
    public string GetValidName()
    {
        string name;
        while (true)
        {
            Console.Write("Name: ");
            name = Console.ReadLine()?.Trim() ?? "";
            if (name.Length is <= 4 or > 12)
            {
                Console.WriteLine("Name can have 4 - 12 characters");
                Console.Write("Name: ");
                continue;
            }

            if (name.Contains(' '))
            {
                Console.WriteLine("Name cant have space");
                Console.Write("Name: ");
                continue;
            }

            break;
        }

        return name;
    }

    public string GetValidEmail()
    {
        string email;
        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine()?.Trim() ?? "";

            var at = email.IndexOf('@');
            var lastIndexAt = email.LastIndexOf('@');

            if (at <= 0 || at != lastIndexAt || at == email.Length - 1)
            {
                Console.WriteLine("Invalid email. Exactly one '@' and not at start/end");
                Console.Write("Email: ");
                continue;
            }

            var count = email.Length - (at + 1);
            if (count <= 4)
            {
                Console.WriteLine("Invalid email. Domain must contain at least 4 characters");
                Console.Write("Email: ");
                continue;
            }

            break;
        }

        return email;
    }

    public int GetValidId()
    {
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid id. Try again:\nFor id you must input number");
        }

        return id;
    }

    public DateTime GetValidDate()
    {
        string pattern = "dd.M.yyyy";
        var styles = DateTimeStyles.AllowWhiteSpaces;
        Console.WriteLine($"Enter date in format: {pattern}");

        while (true)
        {
            var input = Console.ReadLine();
            if (DateTime.TryParseExact(input, pattern, CultureInfo.CurrentCulture, styles, out var date))
                return date;
            
            Console.WriteLine("Invalid date, try again");
        }
    }
}