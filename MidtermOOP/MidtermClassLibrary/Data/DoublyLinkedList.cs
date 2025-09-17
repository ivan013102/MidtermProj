using MidtermClassLibrary.Models;
using System;

namespace MidtermClassLibrary.DataStructures
{
    public enum InsertPosition
    {
        Beginning,
        End,
        Specific
    }

    public class DoublyList
    {
        private ClassNode head;
        public bool IsDuplicate(int id)
        {
            ClassNode current = head;
            while (current != null)
            {
                if (current.Data.ID == id)
                    return true;
                current = current.Next;
            }
            return false;
        }
        public bool AddStudent(ClassStudent student, InsertPosition position, int index = 0)
        {
            ClassNode newNode = new ClassNode(student);

            if (head == null)
            {
                head = newNode;
                return true;
            }

            switch (position)
            {
                case InsertPosition.Beginning:
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                    break;

                case InsertPosition.End:
                    ClassNode tail = head;
                    while (tail.Next != null)
                        tail = tail.Next;

                    tail.Next = newNode;
                    newNode.Prev = tail;
                    break;

                case InsertPosition.Specific:
                    ClassNode current = head;
                    int count = 0;

                    while (current != null && count < index - 1)
                    {
                        current = current.Next;
                        count++;
                    }

                    if (current == null)
                        return false;

                    newNode.Next = current.Next;
                    newNode.Prev = current;

                    if (current.Next != null)
                        current.Next.Prev = newNode;

                    current.Next = newNode;
                    break;
            }

            return true;
        }
        public void DeleteStudent(int id)
        {
            if (head == null)
            {
                Console.WriteLine("No students to delete.");
                return;
            }

            if (head.Data.ID == id)
            {
                head = head.Next;
                if (head != null)
                    head.Prev = null;
                Console.WriteLine("Student deleted.");
                return;
            }

            ClassNode current = head;
            while (current != null && current.Data.ID != id)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;

            Console.WriteLine("Student deleted.");
        }
        public void SearchStudent(string key)
        {
            if (head == null)
            {
                Console.WriteLine("No students found.");
                return;
            }

            ClassNode current = head;
            bool found = false;

            while (current != null)
            {
                var s = current.Data;

                if (s.ID.ToString() == key || s.Name.ToLower().Contains(key.ToLower()))
                {
                    DisplayStudentDetails(s);
                    found = true;
                }

                current = current.Next;
            }

            if (!found)
                Console.WriteLine("No student found with the given key.");
        }
        public void UpdateStudentInteractive(int id)
        {
            if (head == null)
            {
                Console.WriteLine("No students to update.");
                return;
            }

            ClassNode current = head;
            while (current != null)
            {
                if (current.Data.ID == id)
                {
                    var s = current.Data;
                    Console.WriteLine("\n--- Updating Student ---");
                    Console.WriteLine("Leave blank to keep the current value.\n");

                    string input;

                    Console.Write($"Name ({s.Name}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.Name = input;

                    Console.Write($"Age ({s.Age}): ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int age)) s.Age = age;

                    Console.Write($"Gender ({s.Gender}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.Gender = input;

                    Console.Write($"Course ({s.Course}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.Course = input;

                    Console.Write($"Year Level ({s.YearLevel}): ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int yearLevel)) s.YearLevel = yearLevel;

                    Console.Write($"GPA ({s.GPA:F2}): ");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out double gpa)) s.GPA = gpa;

                    Console.Write($"Address ({s.Address}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.Address = input;

                    Console.Write($"Email ({s.Email}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.Email = input;

                    Console.Write($"Phone Number ({s.PhoneNumber}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.PhoneNumber = input;

                    Console.Write($"Guardian Name ({s.GuardianName}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.GuardianName = input;

                    Console.Write($"Guardian Phone Number ({s.GuardianPhoneNumber}): ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) s.GuardianPhoneNumber = input;

                    Console.WriteLine("\nStudent updated successfully!");
                    DisplayStudentDetails(s);
                    return;
                }

                current = current.Next;
            }

            Console.WriteLine($"No student found with ID {id}.");
        }
        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            ClassNode current = head;

            while (true)
            {
                Console.Clear();
                DisplayStudentDetails(current.Data);

                Console.WriteLine("\nOptions: [N] Next, [P] Previous, [E] Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()?.ToUpper();

                if (choice == "N")
                {
                    if (current.Next != null)
                        current = current.Next;
                    else
                        current = head;
                }
                else if (choice == "P")
                {
                    if (current.Prev != null)
                        current = current.Prev;
                    else
                    {
                        ClassNode last = head;
                        while (last.Next != null)
                            last = last.Next;
                        current = last;
                    }
                }
                else if (choice == "E")
                {
                    Console.WriteLine("Thank you and Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press any key...");
                    Console.ReadKey();
                }
            }
        }
        private void DisplayStudentDetails(ClassStudent s)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Student ID     : {s.ID}");
            Console.WriteLine($"Name           : {s.Name}");
            Console.WriteLine($"Age            : {s.Age}");
            Console.WriteLine($"Gender         : {s.Gender}");
            Console.WriteLine($"Course         : {s.Course}");
            Console.WriteLine($"Year Level     : {s.YearLevel}");
            Console.WriteLine($"GPA            : {s.GPA:F2}");
            Console.WriteLine($"Address        : {s.Address}");
            Console.WriteLine($"Email          : {s.Email}");
            Console.WriteLine($"Phone Number   : {s.PhoneNumber}");
            Console.WriteLine($"Guardian Name  : {s.GuardianName}");
            Console.WriteLine($"Guardian Phone : {s.GuardianPhoneNumber}");
            Console.WriteLine("=================================\n");
        }
    }
}