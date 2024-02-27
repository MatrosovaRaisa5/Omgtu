using System;

class Student
{
    public string name { get; set; }
    public int year { get; set; }
    public string group { get; set; }

    public Student(string name1, int year1, string group1)
    {
        name = name1;
        year = year1;
        group = group1;
    }

    public void PrintStudentInfo()
    {
        Console.WriteLine($"ФИО: {name}, Год рождения: {year}, Группа: {group}");
    }
}


class Program
{
    static Student[] students;
    static void Main()
    {
        Console.WriteLine("Введите количество задаваемых студентов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        students = new Student[n];

        InputStudentsData();
        SearchByYear();
        SearchByGroup();
    }

    static void InputStudentsData()
    {
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"Введите информацию о студенте {i + 1}:");

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            students[i] = new Student(name, year, group);
        }
    }

    static void SearchByYear()
    {
        Console.Write("Введите год рождения для поиска: ");
        int searchYear = Convert.ToInt32(Console.ReadLine());

        foreach (Student student in students)
        {
            if (student.year == searchYear)
            {
                student.PrintStudentInfo();
            }
        }
    }

    static void SearchByGroup()
    {
        Console.Write("Введите группу для поиска: ");
        string searchGroup = Console.ReadLine();

        foreach (Student student in students)
        {
            if (student.group == searchGroup)
            {
                student.PrintStudentInfo();
            }
        }
    }
}