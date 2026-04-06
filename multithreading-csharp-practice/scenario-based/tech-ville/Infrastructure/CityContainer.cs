using System.Collections.Generic;

public class CityContainer<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> GetAll()
    {
        return items;
    }
}
