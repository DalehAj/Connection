using System;
using System.Collections.Generic;
using System.IO;
namespace Signs{
class Program
{
    static List<User> Users = new List<User>();
    static List<Manager> Managers = new List<Manager>();
    
    static void Main()
    {
        Users = ReadFromFile<User>("UserAccounts.txt");
        Managers = ReadFromFile<Manager>("ManagerAccounts.txt");

            Console.WriteLine("\n[1] Sign Up As Manager");
            Console.WriteLine("[2] Sign Up As User (Team Member)");
            Console.WriteLine("[3] Sign In As Manager");
            Console.WriteLine("[4] Sign In As User (Team Member)");
            Console.WriteLine("[5] Exit");
            Console.WriteLine("\nEnter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SignUpAsManager();
                    break;
                case "2":
                    SignUpAsUser();
                    break;
                case "3":
                    SignInAsManager();
                    break;
                case "4":
                    SignInAsUser();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose from the list (1-5). Please try again.");
                    break;
            }
        
    }

    static void SignUpAsManager()
    {   EnterYourUsername_Manager:
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine(); 
        Manager manager = Managers.Find(m => m.Username == username);
        if (manager != null)
        {
            Console.WriteLine("This Username is already taken as a Manager");
            Console.WriteLine("Try Another Username!\n ");
            goto EnterYourUsername_Manager;
        }
        else
        {
            Manager newManager = new Manager(username,password);
        Managers.Add(newManager);
        WriteToFile("ManagerAccounts.txt",Managers);
        Console.WriteLine("Manager Added Successfully!");
        }
    }
    static void SignUpAsUser()
    {   EnterYourUsername_User:
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        
        User user = Users.Find(u => u.Username == username);
        if (user != null)
        {
            Console.WriteLine("This Username is already taken as a User(Team Member)");
            Console.WriteLine("Try Another Username!\n");
            goto EnterYourUsername_User;
        }
        else
        {
            User newUser = new User(username, password);
        Users.Add(newUser);
        WriteToFile("UserAccounts.txt",Users);
        Console.WriteLine("User Added Successfully!");
        }}
    static void SignInAsManager()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine(); 
        Manager manager = Managers.Find(m => m.Username == username && m.Password == password);

        if (manager != null)
        {
            Console.WriteLine($"Welcome, {manager.Username}! You are now signed in.");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }
    }
    static void SignInAsUser(){
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine(); 
        User user = Users.Find(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine($"Welcome, {user.Username}! You are now signed in.");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }

    }
    static void WriteToFile<T>(string pathFile, List<T> dataToWrite)
{
    try
    {
        using (StreamWriter writer = new StreamWriter(pathFile))
        {
            foreach (T item in dataToWrite)
            {
                writer.WriteLine($"{item.ToString()}");
            }
        }

        Console.WriteLine("Data has been written to the file.");
    }
    catch (IOException e)
    {
        Console.WriteLine($"An error occurred while writing to the file: {e.Message}");
    }
}
static List<T> ReadFromFile<T>(string pathFile)
{
    List<T> data = new List<T>();

    try
    {
        using (StreamReader reader = new StreamReader(pathFile))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // Parse the line and create an instance of the appropriate type (User or Manager)
                // You may need to modify this part based on your specific file format
                T item = ParseLine<T>(line);
                data.Add(item);
            }
        }
    }
    catch (IOException e)
    {
        Console.WriteLine($"An error occurred while reading from the file: {e.Message}");
    }

    return data;
}

static T ParseLine<T>(string line)
{
    // Implement parsing logic based on your specific file format
    // You may need to modify this part based on your file format
    string[] parts = line.Split(',');

    if (typeof(T) == typeof(User))
    {
        return (T)(object)new User(parts[0], parts[1]);
    }
    else if (typeof(T) == typeof(Manager))
    {
        return (T)(object)new Manager(parts[0], parts[1]);
    }

    // Handle other types as needed

    return default(T);
}

}

class Account
{
    public string Username { get; set; }
    public string Password { get; set; }

    public Account(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public override string ToString()
{
    return $"{Username},{Password}";
}

}

class User : Account
{
    public User(string username, string password) : base(username, password)
    {
    }
    public override string ToString()
{
    return $"{Username},{Password}";
}
}

class Manager : Account
{
    public Manager(string username, string password) : base(username, password)
    {
    }
    public override string ToString()
{
    return $"{Username},{Password}";
}
}
}