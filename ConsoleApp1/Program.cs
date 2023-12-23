using System;
using System.Collections.Generic;

class Program
{
    static List<User> users = new List<User>();
    static List<Manager> Managers = new List<Manager>();

    public static int Manager_Flag;

    static void Main()
    {   main_menu:
        Console.WriteLine("Welcome to Connection's Task Manager!");
        Console.WriteLine("1.Manager");
        Console.WriteLine("2.User(Team member)");
        Console.WriteLine("3.Exit");
        Console.WriteLine("\nPlease Select Your Position: ");
        string choice1 = Console.ReadLine();
           switch (choice1)
            {
                case "1":
                    Manager_Flag=1;
                    break;
                case "2":
                    Manager_Flag=0;
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose from the list (1-3). Please try again.");
                    break;
            }

        //while (true)
        //{

            Console.WriteLine("\n1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Sign Out");
            Console.WriteLine("4.Go Back");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SignUp();
                    break;
                case "2":
                    SignIn();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                case "4":
                goto main_menu;

                default:
                    Console.WriteLine("Choose from the list (1-3). Please try again.");
                    break;
            }
        //}
    }

    static void SignUp()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if(Manager_Flag==0){
        User user = users.Find(u => u.Username == username);
        if (user != null)
        {
            Console.WriteLine("This Username is already taken as a User(Team Member)");
        }
        else
        {
            User newUser = new User(username, password);
        users.Add(newUser);
        Console.WriteLine("User Added Successfully!");
        }}
        if(Manager_Flag==1){
        Manager manager = Managers.Find(m => m.Username == username);

        if (manager != null)
        {
            Console.WriteLine("This Username is already taken as a Manager");
        }
        else
        {
            Manager newManager = new Manager(username,password);
        Managers.Add(newManager);
        Console.WriteLine("Manager Added Successfully!");
        }}  
    }

    static void SignIn()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if(Manager_Flag==0){
        User user = users.Find(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine($"Welcome, {user.Username}! You are now signed in.");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }}
        if(Manager_Flag==1){
        Manager manager = Managers.Find(m => m.Username == username && m.Password == password);

        if (manager != null)
        {
            Console.WriteLine($"Welcome, {manager.Username}! You are now signed in.");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }}
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
}

class User : Account
{
    public User(string username, string password) : base(username, password)
    {
    }
}

class Manager : Account
{
    public Manager(string username, string password) : base(username, password)
    {
    }
}
