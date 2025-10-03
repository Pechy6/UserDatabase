namespace UserSystem;

public class Admin(string userName, string eMail) : User(userName, eMail), ICanPost, ICanBanUsers
{
    public override void ShowDashboard()
    {
        Console.WriteLine("---Dashboard---");
        Console.WriteLine($"Role: Admin\nUser Id: {Id}\nName: {UserName}\nEmail: {EMail}\nRegistration Date {DateRegistered}\n");
    }

    public void CreatePost(string content)
    {
        Console.WriteLine(content);   
    }
    
    public void BanUser(User user)
    {
        Console.WriteLine($"User {user.UserName} has been banned.");
    }
}