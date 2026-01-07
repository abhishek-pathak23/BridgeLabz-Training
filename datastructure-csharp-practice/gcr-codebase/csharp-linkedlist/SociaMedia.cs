using System;

// Node to store Friend IDs (linked list inside user)
class FriendNode
{
    public int FriendId;
    public FriendNode Next;

    public FriendNode(int friendId)
    {
        FriendId = friendId;
        Next = null;
    }
}

// Node representing a User
class UserNode
{
    public int UserId;
    public string Name;
    public int Age;

    // Head of friend list
    public FriendNode FriendHead;

    // Pointer to next user
    public UserNode Next;

    public UserNode(int userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
        FriendHead = null;
        Next = null;
    }
}

// Singly Linked List for Social Media System
class SocialMediaLinkedList
{
    private UserNode head;

    // Add new user
    public void AddUser(int id, string name, int age)
    {
        UserNode newUser = new UserNode(id, name, age);
        newUser.Next = head;
        head = newUser;
    }

    // Find user by ID
    private UserNode FindUserById(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserId == id)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    // Check if friend already exists
    private bool FriendExists(FriendNode head, int friendId)
    {
        while (head != null)
        {
            if (head.FriendId == friendId)
                return true;
            head = head.Next;
        }
        return false;
    }

    // Add friend connection (two-way)
    public void AddFriendConnection(int id1, int id2)
    {
        UserNode u1 = FindUserById(id1);
        UserNode u2 = FindUserById(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        if (!FriendExists(u1.FriendHead, id2))
        {
            FriendNode f1 = new FriendNode(id2);
            f1.Next = u1.FriendHead;
            u1.FriendHead = f1;
        }

        if (!FriendExists(u2.FriendHead, id1))
        {
            FriendNode f2 = new FriendNode(id1);
            f2.Next = u2.FriendHead;
            u2.FriendHead = f2;
        }

        Console.WriteLine("Friend connection added");
    }

    // Remove friend connection
    public void RemoveFriendConnection(int id1, int id2)
    {
        RemoveFriend(id1, id2);
        RemoveFriend(id2, id1);
        Console.WriteLine("Friend connection removed");
    }

    private void RemoveFriend(int userId, int friendId)
    {
        UserNode user = FindUserById(userId);
        if (user == null) return;

        FriendNode curr = user.FriendHead;
        FriendNode prev = null;

        while (curr != null)
        {
            if (curr.FriendId == friendId)
            {
                if (prev == null)
                    user.FriendHead = curr.Next;
                else
                    prev.Next = curr.Next;
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
    }

    // Display all friends of a user
    public void DisplayFriends(int userId)
    {
        UserNode user = FindUserById(userId);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.WriteLine("Friends of " + user.Name + ":");

        FriendNode temp = user.FriendHead;
        if (temp == null)
        {
            Console.WriteLine("No friends");
            return;
        }

        while (temp != null)
        {
            UserNode friend = FindUserById(temp.FriendId);
            if (friend != null)
                Console.WriteLine(friend.Name + " (ID: " + friend.UserId + ")");
            temp = temp.Next;
        }
    }

    // Find mutual friends
    public void FindMutualFriends(int id1, int id2)
    {
        UserNode u1 = FindUserById(id1);
        UserNode u2 = FindUserById(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.WriteLine("Mutual Friends:");

        FriendNode f1 = u1.FriendHead;
        bool found = false;

        while (f1 != null)
        {
            if (FriendExists(u2.FriendHead, f1.FriendId))
            {
                UserNode mutual = FindUserById(f1.FriendId);
                if (mutual != null)
                {
                    Console.WriteLine(mutual.Name + " (ID: " + mutual.UserId + ")");
                    found = true;
                }
            }
            f1 = f1.Next;
        }

        if (!found)
            Console.WriteLine("No mutual friends");
    }

    // Search user by ID
    public void SearchById(int id)
    {
        UserNode user = FindUserById(id);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        DisplayUser(user);
    }

    // Search user by Name
    public void SearchByName(string name)
    {
        UserNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                DisplayUser(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("User not found");
    }

    // Count number of friends for each user
    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            int count = 0;
            FriendNode f = temp.FriendHead;
            while (f != null)
            {
                count++;
                f = f.Next;
            }
            Console.WriteLine(temp.Name + " has " + count + " friends");
            temp = temp.Next;
        }
    }

    // Display user details
    private void DisplayUser(UserNode user)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("User ID : " + user.UserId);
        Console.WriteLine("Name    : " + user.Name);
        Console.WriteLine("Age     : " + user.Age);
    }
}

// Main class
class SociaMedia
{
    static void Main()
    {
        SocialMediaLinkedList sm = new SocialMediaLinkedList();

        sm.AddUser(1, "Aditya", 22);
        sm.AddUser(2, "Rohan", 21);
        sm.AddUser(3, "Neha", 23);

        sm.AddFriendConnection(1, 2);
        sm.AddFriendConnection(1, 3);

        Console.WriteLine();
        sm.DisplayFriends(1);

        Console.WriteLine();
        sm.FindMutualFriends(2, 3);

        Console.WriteLine();
        sm.CountFriends();
    }
}