using System.Collections.Generic;

public class NavigationHistory
{
    private Stack<string> backStack = new Stack<string>();
    private Stack<string> forwardStack = new Stack<string>();

    public void Visit(string page)
    {
        backStack.Push(page);
        forwardStack.Clear();
    }

    public string Back()
    {
        if (backStack.Count > 1)
        {
            string current = backStack.Pop();
            forwardStack.Push(current);
            return backStack.Peek();
        }
        return null;
    }

    public string Forward()
    {
        if (forwardStack.Count > 0)
        {
            string page = forwardStack.Pop();
            backStack.Push(page);
            return page;
        }
        return null;
    }
}
