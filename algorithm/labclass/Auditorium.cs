using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.Run();
    }
}

class Auditorium
{
    public int Seats { get; set; }
    public bool Projector { get; set; }
    public bool Computers { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }

    public Auditorium(int seats, bool projector, bool computers, int floor, int number)
    {
        Seats = seats;
        Projector = projector;
        Computers = computers;
        Floor = floor;
        Number = number;
    }
}

class Menu
{
    private Auditorium[] auditoriums;
    public Menu()
    {
        auditoriums = new Auditorium[0];
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Функции:");
            Console.WriteLine("1. Заполнить аудиторный фонд");
            Console.WriteLine("2. Добавить аудиторию");
            Console.WriteLine("3. Изменить данные аудитории");
            Console.WriteLine("4. Вывести список аудиторий с количеством мест >= заданному");
            Console.WriteLine("5. Вывести список аудиторий с проектором и заданным количеством мест");
            Console.WriteLine("6. Вывести список аудиторий с компьютерами и заданным количеством мест");
            Console.WriteLine("7. Вывести список аудиторий на заданном этаже");
            Console.WriteLine("8. Вывести полный список всех аудиторий и их данных");
            Console.WriteLine("9. Очистить окно -> Возврат в меню");
            Console.WriteLine("10. Выход");

            Console.Write("\nВведите номер выбранной функции (1/2/3/4/5/6/7/8/9/10): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FillAuditoriums();
                    Console.WriteLine("\nАудиторный фонд заполнен.");
                    Console.ReadKey();
                    break;
                case 2:
                    AddAuditorium();
                    Console.ReadKey();
                    break;
                case 3:
                    EditAuditorium();
                    Console.ReadKey();
                    break;
                case 4:
                    FilterBySeats();
                    Console.ReadKey();
                    break;
                case 5:
                    FilterByProjector();
                    Console.ReadKey();
                    break;
                case 6:
                    FilterByComputers();
                    Console.ReadKey();
                    break;
                case 7:
                    FilterByFloor();
                    Console.ReadKey();
                    break;
                case 8:
                    PrintAllAuditoriums();
                    Console.ReadKey();
                    break;
                case 9:
                    Console.Clear();
                    Run();
                    Console.ReadKey();
                    break;
                case 10:
                    exit = true;
                    Console.Clear();
                    Console.WriteLine("Чтобы вернуться, нажмите 0");
                    int ent = Convert.ToInt32(Console.ReadLine());
                    if (ent == 0)
                    {
                        Run();
                    }
                    break;
                default:
                    Console.WriteLine("\nОшибка: неверный выбор.");
                    Console.ReadKey();
                    break;
            }
        }
    }



    public void FillAuditoriums()
    {
        Console.Write("Введите количество аудиторий: ");
        int count = Convert.ToInt32(Console.ReadLine());
        auditoriums = new Auditorium[count];
        for (int i = 0; i < count; i++)
        {

            //проверка
            int seats;
            Console.Write("Введите количество мест: ");
            while (!int.TryParse(Console.ReadLine(), out seats))
            {
                Console.WriteLine("Ошибка: введите корректное число мест!");
                Console.Write("Введите количество мест: ");
            }
            int floor;
            Console.Write("Введите этаж: ");
            while (!int.TryParse(Console.ReadLine(), out floor))
            {
                Console.WriteLine("Ошибка: введите корректный номер этажа!");
                Console.Write("Введите этаж: ");
            }

            int number;
            Console.Write("Введите номер аудитории: ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка: введите корректный номер аудитории!");
                Console.Write("Введите номер аудитории: ");
            }

            Console.Write("Наличие проектора (да/нет): ");
            string projectorInput;
            do
            {
                projectorInput = Console.ReadLine();
                if (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
                }
            } while (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
            bool projector = projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase);

            Console.Write("Наличие компьютеров (да/нет): ");
            string computersInput;
            do
            {
                computersInput = Console.ReadLine();
                if (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
                }
            } while (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
            bool computers = computersInput.Equals("да", StringComparison.OrdinalIgnoreCase);


            Auditorium auditorium = new Auditorium(seats, projector, computers, floor, number);
            auditoriums[i] = auditorium;


        }

        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }


    private void AddAuditorium()
    {
        //проверка
        int seats;
        Console.Write("Введите количество мест: ");
        while (!int.TryParse(Console.ReadLine(), out seats))
        {
            Console.WriteLine("Ошибка: введите корректное число мест!");
            Console.Write("Введите количество мест: ");
        }
        int floor;
        Console.Write("Введите этаж: ");
        while (!int.TryParse(Console.ReadLine(), out floor))
        {
            Console.WriteLine("Ошибка: введите корректный номер этажа!");
            Console.Write("Введите этаж: ");
        }

        int number;
        Console.Write("Введите номер аудитории: ");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Ошибка: введите корректный номер аудитории!");
            Console.Write("Введите номер аудитории: ");
        }

        Console.Write("Наличие проектора (да/нет): ");
        string projectorInput;
        do
        {
            projectorInput = Console.ReadLine();
            if (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
            }
        } while (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
        bool projector = projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase);

        Console.Write("Наличие компьютеров (да/нет): ");
        string computersInput;
        do
        {
            computersInput = Console.ReadLine();
            if (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
            }
        } while (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
        bool computers = computersInput.Equals("да", StringComparison.OrdinalIgnoreCase);

        Auditorium[] auditoriums = new Auditorium[1];
        auditoriums[0] = new Auditorium(seats, projector, computers, floor, number);

        Console.WriteLine("Аудитория успешно добавлена.");
        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }

    private void EditAuditorium()
    {
        Console.Write("\nВведите номер этажа аудитории, которую нужно изменить: ");
        int floor = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите номер аудитории, которую нужно изменить: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Auditorium auditorium = auditoriums.FirstOrDefault(a => a.Floor == floor && a.Number == number);

        if (auditorium != null)
        {
            Console.Write("Введите новое количество посадочных мест: ");
            int seats = Convert.ToInt32(Console.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out seats))
            {
                Console.WriteLine("Ошибка: введите корректное число мест!");
                Console.Write("Введите количество мест: ");
            }
            Console.Write("Наличие проектора (да/нет): ");
            string projectorInput;
            do
            {
                projectorInput = Console.ReadLine();
                if (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
                }
            } while (!projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !projectorInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
            bool projector = projectorInput.Equals("да", StringComparison.OrdinalIgnoreCase);

            Console.Write("Наличие компьютеров (да/нет): ");
            string computersInput;
            do
            {
                computersInput = Console.ReadLine();
                if (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ошибка: введите 'да' или 'нет'!");
                }
            } while (!computersInput.Equals("да", StringComparison.OrdinalIgnoreCase) && !computersInput.Equals("нет", StringComparison.OrdinalIgnoreCase));
            bool computers = computersInput.Equals("да", StringComparison.OrdinalIgnoreCase);



            auditorium.Seats = seats;
            auditorium.Projector = projector;
            auditorium.Computers = computers;

            Console.WriteLine("\nДанные аудитории успешно изменены.");
        }
        else
        {
            Console.WriteLine("\nОшибка: аудитория не найдена.");
        }
        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }

    private void FilterBySeats()
    {
        if (auditoriums == null || auditoriums.Length == 0)
        {
            Console.WriteLine("База данных не сформирована. Для возвращения в меню нажмите 0");
            int enet = Convert.ToInt32(Console.ReadLine());
            if (enet == 0)
            {
                Run();
            }
        }
        else
        {
            Console.Write("\nВведите количество мест: ");
            int seats = Convert.ToInt32(Console.ReadLine());

            Auditorium[] filteredAuditoriums = auditoriums.Where(a => a.Seats >= seats).ToArray();

            if (filteredAuditoriums.Length > 0)
            {
                Console.WriteLine("\nСписок аудиторий с количеством мест >= {0}:", seats);
                foreach (Auditorium auditorium in filteredAuditoriums)
                {
                    Console.WriteLine("Аудитория {0} (этаж {1})", auditorium.Number, auditorium.Floor);
                }
            }
            else
            {
                Console.WriteLine("\nАудитории с количеством мест >= {0} не найдены.", seats);
            }
        }

        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }

    private void FilterByProjector()
    {
        Console.Write("\nВведите количество мест: ");
        int seats = Convert.ToInt32(Console.ReadLine());
        if (auditoriums == null || auditoriums.Length == 0)
        {
            Console.WriteLine("База данных не сформирована. Для возвращения в меню нажмите 0");
            int enet = Convert.ToInt32(Console.ReadLine());
            if (enet == 0)
            {
                Run();
            }
        }


        Auditorium[] filteredAuditoriums = auditoriums.Where(a => a.Projector && a.Seats == seats).ToArray();

        if (filteredAuditoriums.Length > 0)
        {
            Console.WriteLine("\nСписок аудиторий с проектором и количеством мест = {0}:", seats);
            foreach (Auditorium auditorium in filteredAuditoriums)
            {
                Console.WriteLine("Аудитория {0} (этаж {1})", auditorium.Number, auditorium.Floor);
            }
        }
        else
        {
            Console.WriteLine("\nАудитории с проектором и количеством мест = {0} не найдены.", seats);
        }
        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }


    private void FilterByComputers()
    {
        Console.Write("\nВведите количество мест: ");
        int seats = Convert.ToInt32(Console.ReadLine());
        if (auditoriums == null || auditoriums.Length == 0)
        {
            Console.WriteLine("База данных не сформирована. Для возвращения в меню нажмите 0");
            int enet = Convert.ToInt32(Console.ReadLine());
            if (enet == 0)
            {
                Run();
            }
        }
        Auditorium[] filteredAuditoriums = auditoriums.Where(a => a.Computers && a.Seats == seats).ToArray();

        if (filteredAuditoriums.Length > 0)
        {
            Console.WriteLine("\nСписок аудиторий с компьютерами и количеством мест = {0}:", seats);
            foreach (Auditorium auditorium in filteredAuditoriums)
            {
                Console.WriteLine("Аудитория {1}-{0}", auditorium.Number, auditorium.Floor);
            }
        }
        else
        {
            Console.WriteLine("\nАудитории с компьютерами и количеством мест = {0} не найдены.", seats);
        }
        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }

    private void FilterByFloor()
    {
        Console.Write("\nВведите номер этажа: ");
        int floor = Convert.ToInt32(Console.ReadLine());
        Auditorium[] filteredAuditoriums = auditoriums.Where(a => a.Floor == floor).ToArray();
        if (auditoriums == null || auditoriums.Length == 0)
        {
            Console.WriteLine("База данных не сформирована. Для возвращения в меню нажмите 0");
            int enet = Convert.ToInt32(Console.ReadLine());
            if (enet == 0)
            {
                Run();
            }
        }

        if (filteredAuditoriums.Length > 0)
        {
            Console.WriteLine("\nСписок аудиторий на этаже {0}:", floor);
            foreach (Auditorium auditorium in filteredAuditoriums)
            {
                Console.WriteLine("Аудитория {1}-{0}", auditorium.Number, auditorium.Floor);
            }
        }
        else
        {
            Console.WriteLine("\nАудитории на этаже {0} не найдены.", floor);
        }
        Console.WriteLine("Для продолжения нажмите 0");
        int ent = Convert.ToInt32(Console.ReadLine());
        if (ent == 0)
        {
            Run();
        }
    }

    private void PrintAllAuditoriums()
    {
        if (auditoriums == null || auditoriums.Length == 0)
        {
            Console.WriteLine("База данных не сформирована. Для возвращения в меню нажмите 0");
            int enet = Convert.ToInt32(Console.ReadLine());
            if (enet == 0)
            {
                Run();
            }
        }

        else
        {
            Console.WriteLine("\nСписок всех аудиторий и их данных:");
            foreach (Auditorium auditorium in auditoriums)
            {
                Console.WriteLine("Аудитория {2}-{0} (мест: {1}, проектор: {3}, компьютеры: {4})",
                auditorium.Number, auditorium.Seats, auditorium.Floor,
                auditorium.Projector ? "да" : "нет", auditorium.Computers ? "да" : "нет");
            }
            Console.WriteLine("Для продолжения нажмите 0");
            int ent = Convert.ToInt32(Console.ReadLine());
            if (ent == 0)
            {
                Run();
            }
        }
    }
}