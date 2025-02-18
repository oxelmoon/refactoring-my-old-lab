using System;
using System.Text;
using SimpleClassLibrary;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Worker[] workers = ReadWorkersArray();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            DisplayMenu(); 
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintWorkerByIndex(workers);
                    break;
                case "2":
                    PrintWorkers(workers);
                    break;
                case "3":
                    PrintMinMaxSalaryWorkers(workers);
                    break;
                case "4":
                    SortAndPrintWorkers(workers, SortWorkerBySalary);
                    break;
                case "5":
                    SortAndPrintWorkers(workers, SortWorkerByWorkExperience);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("1. Вивести інформацію про працівника");
        Console.WriteLine("2. Вивести інформацію про всіх працівників");
        Console.WriteLine("3. Отримати інформацію про найбільшу та найменшу зарплату");
        Console.WriteLine("4. Сортувати працівників за спаданням зарплати");
        Console.WriteLine("5. Сортувати працівників за зростанням стажу роботи");
        Console.WriteLine("6. Вийти");
    }

    static void PrintWorkerByIndex(Worker[] workers)
    {
        Console.Write("Введіть індекс працівника: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < workers.Length)
        {
            PrintWorker(workers[index]);
        }
        else
        {
            Console.WriteLine("Некоректний індекс.");
        }
    }

    static void PrintMinMaxSalaryWorkers(Worker[] workers)
    {
        GetWorkersInfo(workers, out Worker minSalaryWorker, out Worker maxSalaryWorker);
        Console.WriteLine("Працівник з найменшою зарплатою:");
        PrintWorker(minSalaryWorker);
        Console.WriteLine("Працівник з найбільшою зарплатою:");
        PrintWorker(maxSalaryWorker);
    }

    static void SortAndPrintWorkers(Worker[] workers, Action<Worker[]> sortMethod)
    {
        sortMethod(workers); 
        PrintWorkers(workers);
    }

    static Worker[] ReadWorkersArray()
    {
        Console.Write("Введіть кількість працівників: ");
        int n = int.Parse(Console.ReadLine());
        Worker[] workers = new Worker[n];

        for (int i = 0; i < n; i++)
        {
            workers[i] = ReadWorkerData(i + 1);
        }

        return workers;
    }

    static Worker ReadWorkerData(int index)
    {
        Console.WriteLine($"Введіть дані для працівника {index}:");
        Console.Write("Прізвище та ініціали: ");
        string name = Console.ReadLine();
        Console.Write("Рік початку роботи: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Місяць початку роботи: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Назва компанії: ");
        string companyName = Console.ReadLine();
        Console.Write("Посада: ");
        string position = Console.ReadLine();
        Console.Write("Зарплата: ");
        double salary = double.Parse(Console.ReadLine());

        double bonus = ReadBonus();

        Company company = new Company(companyName, position, salary);
        return new Worker(name, year, month, company, bonus);
    }

    static double ReadBonus()
    {
        Console.WriteLine("Оберіть одиниці вимірювання для введення розміру премії:");
        Console.WriteLine("1. Гривні (UAH)");
        Console.WriteLine("2. Долари (USD)");
        Console.WriteLine("3. Євро (EUR)");

        return Console.ReadLine() switch
        {
            "1" => ReadBonusAmount("гривнях"),
            "2" => ReadBonusAmount("доларах") * 27.0,
            "3" => ReadBonusAmount("євро") * 30.0,
            _ => 0 
        };
    }

    static double ReadBonusAmount(string currency)
    {
        Console.Write($"Введіть розмір премії в {currency}: ");
        return double.Parse(Console.ReadLine());
    }

    static void PrintWorker(Worker worker)
    {
        Console.WriteLine($"Ім'я: {worker.GetName()}");
        Console.WriteLine($"Компанія: {worker.GetWorkPlace().GetName()}");
        Console.WriteLine($"Посада: {worker.GetWorkPlace().GetPosition()}");
        Console.WriteLine($"Зарплата: {worker.GetWorkPlace().GetSalary()}");
        Console.WriteLine($"Стаж роботи: {worker.GetWorkExperience()} місяців");
        Console.WriteLine($"Заробіток за весь час: {worker.GetTotalMoney()}");
        Console.WriteLine($"Премія в UAH: {worker.GetBonusInUAH()}");
    }

    static void PrintWorkers(Worker[] workers)
    {
        foreach (var worker in workers)
        {
            PrintWorker(worker);
            Console.WriteLine("-----------");
        }
    }

    static void GetWorkersInfo(Worker[] workers, out Worker minSalaryWorker, out Worker maxSalaryWorker)
    {
        minSalaryWorker = workers.OrderBy(w => w.GetWorkPlace().GetSalary()).First();
        maxSalaryWorker = workers.OrderByDescending(w => w.GetWorkPlace().GetSalary()).First();
    }

    static void SortWorkerBySalary(Worker[] workers)
    {
        Array.Sort(workers, (w1, w2) => w2.GetWorkPlace().GetSalary().CompareTo(w1.GetWorkPlace().GetSalary()));
    }

    static void SortWorkerByWorkExperience(Worker[] workers)
    {
        Array.Sort(workers, (w1, w2) => w1.GetWorkExperience().CompareTo(w2.GetWorkExperience()));
    }
}
