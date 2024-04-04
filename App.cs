using CoreLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoreLogic.Model;

namespace  UILayer;

class App
{
    private readonly StudentService _studentService;

    public App() //why do we do this?
    {
        _studentService = new StudentService(); 
    }
    public void RunUI(bool AppIsRunning)
    {
        while (AppIsRunning)
        {
            MainMenu();
            
            switch(UserChoice())
            {
                case "1":
                    ListStudents();
                    break;
                case "2":
                    AddStudent();
                    break;
                case "3":
                    UpdateStudent();
                    break;
                case "4":
                    RemoveStudent();
                    break;
                case "5":
                    FilterCity();
                    break;
                case "6":
                    Console.WriteLine($"bye");
                    AppIsRunning = false;
                    break;
                default:
                    Console.WriteLine($"Invalid choice, choose again.");
                    break;

            };
                   
        };

    }

    private void UpdateStudent()
    {
        

        bool updating = true;
        while (updating == true)
        {
            
            UpdateMenu();
            Student s = new Student();
            switch (UserChoice())
            {
                case "1":
                    Console.WriteLine("Updating Name");

                    

                    s.Id = StudentId();
                    s.Name = StudentName();

                    _studentService.Update(s);
                    Console.WriteLine("Student name is updated!");

                    //DisplayStudentsList();

                    updating = false;
                    break;
                case "2":

                    Console.WriteLine("Updating City");

                    s.Id = StudentId();
                    s.City = StudentCity();

                    _studentService.UpdateCity(s);
                    Console.WriteLine("Student City is updated!");

                    updating = false;
                    break;
                case "N":
                    Console.WriteLine("Exit Update");
                    updating = false;
                    break;
                default:
                    Console.WriteLine($"Invalid choice, choose again.");
                    break;
            }
        }
    }
    private void MainMenu()
    {
        Console.WriteLine("**************** MENU *********************");
        Console.WriteLine("1) List students");
        Console.WriteLine("2) Create new student");
        Console.WriteLine("3) Update student details");
        Console.WriteLine("4) Delete student");
        Console.WriteLine("5) Filter City");
        Console.WriteLine("6) Exit");
        Console.WriteLine("*******************************************");
    }
    private void UpdateMenu()
    {
        Console.WriteLine("**************** UPDATE *******************");
        Console.WriteLine("1) Update Name");
        Console.WriteLine("2) Update City");
        Console.WriteLine("N) Exit Update");
        Console.WriteLine("*******************************************");
    }

    private void ListStudents()
    {
        Console.WriteLine("List of Students");
        var students = _studentService.RetrieveAll();

        Console.WriteLine();
        foreach (var student in students)
            Console.WriteLine($"{student.Id,-5}{student.Name,-15}{student.City}");
        Console.WriteLine();
    }
    private void AddStudent()
    {
        Student s = new Student();
        s.Id = StudentId();
        s.Name = StudentName();
        s.City = StudentCity();

        _studentService.Create(s);

        Console.WriteLine($"Student {s.Name} registered!");
    }

    private void RemoveStudent()
    {
        int Id = StudentId();
        Console.WriteLine($"Removing Record of Student ID {Id}");

        _studentService.Delete(Id);

        Console.WriteLine($"Student {Id} deleted!");
        ListStudents();
    }

    private void FilterCity()
    {
        Student s = new Student();
        s.City = StudentCity();

        var students = _studentService.FilterCity(s);

        foreach (var student in students)
            Console.WriteLine($"{student.Id,-5}{student.Name,-15}{student.City}");
        Console.WriteLine("FilterCity");
    }
    
    private string UserChoice()
    {
        Console.Write("Enter Choice: ");
        string choice = Console.ReadLine().ToString();
        return choice;
    }
    private int StudentId()
    {
        Console.Write("Enter Student ID: ");
        var Id = Convert.ToInt32(Console.ReadLine());
        return Id;
    }
    private string StudentName()
    {
        Console.Write("Enter Student Name: ");
        var Name = Convert.ToString(Console.ReadLine());
        return Name;
    }
    private string StudentCity()
    {
        Console.Write("Enter Student City: ");
        var City = Convert.ToString(Console.ReadLine().ToUpper());
        return City;
    }


};

