namespace UserSystem;

public class Database<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }
    
    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;   
    }

    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _items.Where(predicate);  
    }
}