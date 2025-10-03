namespace UserSystem;

public class RegularUser(string userName, string eMail) : User(userName, eMail), ICanPost
{
    public override void ShowDashboard()
    {
        Console.WriteLine("---Dashboard---");
        Console.WriteLine($"Role: User\nUser Id: {Id}\nName: {UserName}\nEmail: {EMail}\nRegistration Date {DateRegistered}\n");
    }

    public void CreatePost(string content)
    {
        Console.WriteLine(content);
    }
}