using System.Collections.Generic;

public class IntegerListHandler
{
    public void AddElement(List<int> list, int value)
    {
        list.Add(value);
    }

    public void RemoveElement(List<int> list, int value)
    {
        list.Remove(value);
    }

    public int GetSize(List<int> list)
    {
        return list.Count;
    }
}