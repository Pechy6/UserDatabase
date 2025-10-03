namespace UserSystem;

public class UserManager
{
    private readonly Database<User> _database = new();

    public void AddUser(User user)
    {
        _database.Add(user);
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

    // public void FindUsersById(int id)
    // {
    //     var found = _database.Find(u => u.Id == id);
    //     foreach (var user in found)
    //     {
    //         user.ShowDashboard();
    //     }
    // }
    //
    // public void FindUsersByName(string name)
    // {
    //     var found = _database.Find(u => u.UserName == name);
    //     foreach (var user in found)
    //     {
    //         user.ShowDashboard();
    //     }
    // }
    //
    // public void FindUsersByEmail(string email)
    // {
    //     var found = _database.Find(u => u.EMail == email);
    //     foreach (var user in found)
    //     {
    //         user.ShowDashboard();
    //     }
    // }
    //
    // public void FindUsersByDate(DateTime date)
    // {
    //     var found = _database.Find(u => u.DateRegistered == date);
    //     foreach (var user in found)
    //     {
    //         user.ShowDashboard();
    //     }
    // }
}