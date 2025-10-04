namespace UserSystem;

public class UserManager
{
    private readonly Database<User> _database = new();

    public void AddUser(User user)
    {
        _database.Add(user);
    }
    
    public void RemoveUser(User user)
    {
        _database.Remove(user);
    }

    public void WriteAllUsers()
    {
        foreach (var user in _database.GetAll())
        {
            user.ShowDashboard();
        }
    }

    public User? FindUserByName(string name)
    {
        return _database.Find(u => u.UserName == name).FirstOrDefault();
    }

    public User? FindUserById(int id)
    {
        return _database.Find(u => u.Id == id).FirstOrDefault();
    }
    
    public User? FindUserByEmail(string email)
    {
        return _database.Find(u => u.EMail == email).FirstOrDefault();
    }
    
    public User? FindUserByDate(DateTime date)
    {
        var d = DateOnly.FromDateTime(date);
        return _database.Find(u => DateOnly.FromDateTime(u.DateRegistered) == d).FirstOrDefault();
    }
}