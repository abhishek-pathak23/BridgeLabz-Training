using System;

namespace BrowserBuddyApp
{
    // Doubly Linked List Node
    class PageNode
    {
        public string Url;
        public PageNode Prev;
        public PageNode Next;

        public PageNode(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }

    // Stack Node for Closed Tabs
    class ClosedTabNode
    {
        public PageNode HistoryPointer;
        public ClosedTabNode Next;

        public ClosedTabNode(PageNode pointer)
        {
            HistoryPointer = pointer;
            Next = null;
        }
    }

    // Stack for closed tabs
    class ClosedTabStack
    {
        private ClosedTabNode top;

        public void Push(PageNode pointer)
        {
            ClosedTabNode node = new ClosedTabNode(pointer);
            node.Next = top;
            top = node;
        }

        public PageNode Pop()
        {
            if (top == null)
                return null;

            PageNode data = top.HistoryPointer;
            top = top.Next;
            return data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

    // Browser Tab with Doubly Linked List
    class BrowserTab
    {
        private PageNode current;

        public void Visit(string url)
        {
            PageNode newPage = new PageNode(url);

            if (current != null)
            {
                current.Next = null;
                newPage.Prev = current;
                current.Next = newPage;
            }

            current = newPage;
            Console.WriteLine($"Visited: {url}");
        }

        public void GoBack()
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine($"Back to: {current.Url}");
            }
            else
            {
                Console.WriteLine("No previous page");
            }
        }

        public void GoForward()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                Console.WriteLine($"Forward to: {current.Url}");
            }
            else
            {
                Console.WriteLine("No forward page");
            }
        }

        public PageNode CloseTab()
        {
            Console.WriteLine("Tab closed");
            return current;
        }

        public void RestoreTab(PageNode pointer)
        {
            current = pointer;
            Console.WriteLine($"Tab restored at: {current.Url}");
        }

        public void ShowCurrent()
        {
            if (current != null)
                Console.WriteLine($"Current Page: {current.Url}");
            else
                Console.WriteLine("No active tab");
        }
    }

    class BrowserBuddyMain
    {
        static void Main()
        {
            BrowserTab tab = new BrowserTab();
            ClosedTabStack closedTabs = new ClosedTabStack();

            int choice;

            do
            {
                Console.WriteLine("\n--- BrowserBuddy Menu ---");
                Console.WriteLine("1. Visit New Page");
                Console.WriteLine("2. Back");
                Console.WriteLine("3. Forward");
                Console.WriteLine("4. Close Tab");
                Console.WriteLine("5. Restore Closed Tab");
                Console.WriteLine("6. Show Current Page");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter URL: ");
                        tab.Visit(Console.ReadLine());
                        break;

                    case 2:
                        tab.GoBack();
                        break;

                    case 3:
                        tab.GoForward();
                        break;

                    case 4:
                        closedTabs.Push(tab.CloseTab());
                        break;

                    case 5:
                        if (!closedTabs.IsEmpty())
                            tab.RestoreTab(closedTabs.Pop());
                        else
                            Console.WriteLine("No closed tabs to restore");
                        break;

                    case 6:
                        tab.ShowCurrent();
                        break;
                }

            } while (choice != 0);
        }
    }
}