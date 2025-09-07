using MidtermClassLibrary.Models;
using MidtermClassLibrary.DataStructures;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var list = new DoublyList();
        bool running = true;

        while (running)
        {
            Console.Clear();
            ShowMenu();
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": HandleAddStudent(list); break;
                case "2": HandleDeleteStudent(list); break;
                case "3": HandleSearchStudent(list); break;
                case "4": HandleUpdateStudent(list); break;
                case "5": list.DisplayAll(); Pause(); break;
                case "6": running = false; Console.WriteLine("\nARDUA NON TIMEO"); break;
                default: Console.WriteLine("Invalid option. Please choose between 1–6."); Pause(); break;
            }
        }
    }
    static void ShowMenu()
    {
        Console.WriteLine("=== Student Record Management System ===");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Delete Student");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Display All Students");
        Console.WriteLine("6. Exit");
        Console.Write("\nChoose an option: ");
    }
    static void HandleAddStudent(DoublyList list)
    {
        var student = new ClassStudent
        {
            ID = GetValidatedInt("Enter ID", 1, int.MaxValue, list),
            Name = $"{GetValidatedString("Enter First Name")} {GetValidatedString("Enter Last Name")}",
            Age = GetValidatedInt("Enter Age", 1, 500),
            Gender = GetValidatedGender("Enter Gender (M/F)"),
            Course = GetValidatedString("Enter Course"),
            YearLevel = GetValidatedInt("Enter Year Level", 1, 5),
            GPA = GetValidatedDouble("Enter GPA", 1.0, 5.0),
            Address = GetValidatedString("Enter Address", allowNumbers: true),
            Email = GetValidatedEmail("Enter Email"),
            PhoneNumber = GetValidatedString("Enter Phone Number", allowNumbers: true),
            GuardianName = GetValidatedString("Enter Guardian Name"),
            GuardianPhoneNumber = GetValidatedString("Enter Guardian Phone Number", allowNumbers: true),
        };

        InsertPosition position = GetPositionChoice(out int index);
        bool success = list.AddStudent(student, position, index);

        Console.WriteLine(success
            ? "Student added successfully."
            : "Failed to add student at the specified position.");
        Pause();
    }

    static string GetValidatedGender(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "M" || input == "F")
            {
                return input;
            }
            Console.WriteLine("Invalid input. Please enter the expected Gender");
        }
    }
    static void HandleDeleteStudent(DoublyList list)
    {
        int id = GetValidatedInt("Enter ID to delete", 1, int.MaxValue);
        list.DeleteStudent(id);
        Pause();
    }
    static void HandleSearchStudent(DoublyList list)
    {
        Console.Write("Enter ID or Name to search: ");
        string key = Console.ReadLine()?.Trim();
        list.SearchStudent(key);
        Pause();
    }
    static void HandleUpdateStudent(DoublyList list)
    {
        int id = GetValidatedInt("Enter ID to update", 1, int.MaxValue);
        list.UpdateStudentInteractive(id);
        Pause();
    }
    static int GetValidatedInt(string prompt, int min, int max, DoublyList list = null)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            {
                if (list != null && list.IsDuplicate(value))
                {
                    Console.WriteLine($"ID {value} already exists. Try again.");
                    continue;
                }
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    static double GetValidatedDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            if (double.TryParse(Console.ReadLine(), out double value) && value >= min && value <= max)
                return value;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    static string GetValidatedString(string prompt, bool allowNumbers = false)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }

            if (!allowNumbers && input.Any(char.IsDigit))
            {
                Console.WriteLine("Letters only. Numbers are not allowed.");
                continue;
            }

            return input;
        }
    }
    static string GetValidatedEmail(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Email cannot be empty.");
                continue;
            }

            if (!input.Contains("@") || !input.Contains("."))
            {
                Console.WriteLine("Invalid email format. Please try again.");
                continue;
            }

            return input;
        }
    }
    static InsertPosition GetPositionChoice(out int index)
    {
        index = 0;
        Console.WriteLine("Choose insert position:");
        Console.WriteLine("1. Beginning");
        Console.WriteLine("2. End");
        Console.WriteLine("3. Specific Position");

        while (true)
        {
            Console.Write("Choice: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": return InsertPosition.Beginning;
                case "2": return InsertPosition.End;
                case "3":
                    index = GetValidatedInt("Enter position (starting from 1)", 1, int.MaxValue);
                    return InsertPosition.Specific;
                default:
                    Console.WriteLine("Invalid choice. Enter 1, 2, or 3.");
                    break;
            }
        }
    }
    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}