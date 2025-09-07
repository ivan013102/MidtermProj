# Student Record Management System

## 📌 Description

This is a simple **console-based application** developed in **C#** that manages student records using a **doubly linked list** data structure. It allows users to add, delete, search, update, and view student information in a structured and interactive manner.

The system uses a custom data structure (`DoublyList`) with nodes (`ClassNode`) that store student details (`ClassStudent`). Each student has personal, academic, and guardian information.

---

## 🛠️ Features

- ✅ Add a student (at the beginning, end, or specific position)
- 🗑️ Delete a student by ID
- 🔍 Search student by ID or name
- ✏️ Update student details interactively
- 📜 Browse all student records (next/previous navigation)
- 🔐 Input validation (email, phone number, GPA, etc.)
- 🚫 Duplicate ID detection

---

## 📁 Project Structure

MidtermClassLibrary/
│
├── Models/
│ └── ClassStudent.cs # Defines the student data model
│
├── DataStructures/
│ ├── ClassNode.cs # Node structure for the doubly linked list
│ └── DoublyList.cs # Core logic for student management
│
└── Program.cs # Main console interface


---

## 🚀 How to Run

### 1. Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (Core or Framework)
- Any C# IDE (e.g., Visual Studio, VS Code) **or** command-line interface

### 2. Run via Command Line

```bash
# Navigate to project folder
dotnet build
dotnet run

3. Run via Visual Studio

Open the solution or project

Build the solution (Ctrl + Shift + B)

Run the program (F5)

=== Student Record Management System ===
1. Add Student
2. Delete Student
3. Search Student
4. Update Student
5. Display All Students
6. Exit

Exit Message
Upon exiting the application, it displays the motto:

ARDUA NON TIMEO

Sample Student Info Format
ID              : 1001
Name            : John Doe
Age             : 20
Gender          : M
Course          : BS Computer Science
Year Level      : 2
GPA             : 3.50
Address         : 1234 Sample Street
Email           : john.doe@example.com
Phone Number    : 09171234567
Guardian Name   : Jane Doe
Guardian Phone  : 09179876543

