namespace UserSystem;

public abstract class User
{
    private static int _nextId = 0;

    public int Id { get; init; }
    public string UserName { get; private set; }
    public string EMail { get; private set; }
    public DateTime DateRegistered { get; init; }

    protected User(string userName, string eMail)
    {
        Id = ++_nextId; // auto-increment
        UserName = userName;
        EMail = eMail;
        DateRegistered = DateTime.Now;
    }

    public abstract void ShowDashboard();
}