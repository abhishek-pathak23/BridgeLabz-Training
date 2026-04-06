using System.Collections.Generic;

public class Repository<T, ID>
{
    private Dictionary<ID, T> storage = new Dictionary<ID, T>();

    public void Save(ID id, T entity)
    {
        storage[id] = entity;
    }

    public T FindById(ID id)
    {
        if (storage.ContainsKey(id))
            return storage[id];

        return default(T);
    }

    public void Delete(ID id)
    {
        if (storage.ContainsKey(id))
            storage.Remove(id);
    }

    public List<T> GetAll()
    {
        return new List<T>(storage.Values);
    }
}
