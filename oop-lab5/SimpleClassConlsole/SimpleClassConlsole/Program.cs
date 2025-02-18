using System;
using System.Text;
using SimpleClassLibrary;

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
            Console.WriteLine("1. Вивести інформацію про працівника");
            Console.WriteLine("2. Вивести інформацію про всіх працівників");
            Console.WriteLine("3. Отримати інформацію про найбільшу та найменшу зарплату");
            Console.WriteLine("4. Сортувати працівників за спаданням зарплати");
            Console.WriteLine("5. Сортувати працівників за зростанням стажу роботи");
            Console.WriteLine("6. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть індекс працівника: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < workers.Length)
                    {
                        PrintWorker(workers[index]);
                    }
                    else
                    {
                        Console.WriteLine("Некоректний індекс.");
                    }
                    break;
                case "2":
                    PrintWorkers(workers);
                    break;
                case "3":
                    GetWorkersInfo(workers, out Worker minSalaryWorker, out Worker maxSalaryWorker);
                    Console.WriteLine("Працівник з найменшою зарплатою:");
                    PrintWorker(minSalaryWorker);
                    Console.WriteLine("Працівник з найбільшою зарплатою:");
                    PrintWorker(maxSalaryWorker);
                    break;
                case "4":
                    SortWorkerBySalary(workers);
                    PrintWorkers(workers);
                    break;
                case "5":
                    SortWorkerByWorkExperience(workers);
                    PrintWorkers(workers);
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

    public static Worker[] ReadWorkersArray()
    {
        Console.Write("Введіть кількість працівників: ");
        int n = int.Parse(Console.ReadLine());
        Worker[] workers = new Worker[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть дані для працівника {i + 1}:");
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

            Console.WriteLine("Оберіть одиниці вимірювання для введення розміру премії:");
            Console.WriteLine("1. Гривні (UAH)");
            Console.WriteLine("2. Долари (USD)");
            Console.WriteLine("3. Євро (EUR)");

            double bonus = 0;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введіть розмір премії в гривнях: ");
                    bonus = double.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Введіть розмір премії в доларах: ");
                    bonus = double.Parse(Console.ReadLine()) * 27.0; // example exchange rate
                    break;
                case "3":
                    Console.Write("Введіть розмір премії в євро: ");
                    bonus = double.Parse(Console.ReadLine()) * 30.0; // example exchange rate
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }

            Company company = new Company(companyName, position, salary);
            workers[i] = new Worker(name, year, month, company, bonus);
        }

        return workers;
    }

    public static void PrintWorker(Worker worker)
    {
        Console.WriteLine($"Ім'я: {worker.GetName()}");
        Console.WriteLine($"Рік початку роботи: {worker.GetYear()}");
        Console.WriteLine($"Місяць початку роботи: {worker.GetMonth()}");
        Console.WriteLine($"Компанія: {worker.GetWorkPlace().GetName()}");
        Console.WriteLine($"Посада: {worker.GetWorkPlace().GetPosition()}");
        Console.WriteLine($"Зарплата: {worker.GetWorkPlace().GetSalary()}");
        Console.WriteLine($"Стаж роботи: {worker.GetWorkExperience()} місяців");
        Console.WriteLine($"Заробіток за весь час: {worker.GetTotalMoney()}");
        Console.WriteLine($"Премія в UAH: {worker.GetBonusInUAH()}");
        Console.WriteLine($"Премія в USD: {worker.GetBonusInUSD(27.0)}"); // example exchange rate
        Console.WriteLine($"Премія в EUR: {worker.GetBonusInEUR(30.0)}"); // example exchange rate
    }

    public static void PrintWorkers(Worker[] workers)
    {
        foreach (var worker in workers)
        {
            PrintWorker(worker);
            Console.WriteLine("-----------");
        }
    }

    public static void GetWorkersInfo(Worker[] workers, out Worker minSalaryWorker, out Worker maxSalaryWorker)
    {
        minSalaryWorker = workers.OrderBy(w => w.GetWorkPlace().GetSalary()).First();
        maxSalaryWorker = workers.OrderByDescending(w => w.GetWorkPlace().GetSalary()).First();
    }

    public static void SortWorkerBySalary(Worker[] workers)
    {
        Array.Sort(workers, (w1, w2) => w2.GetWorkPlace().GetSalary().CompareTo(w1.GetWorkPlace().GetSalary()));
    }

    public static void SortWorkerByWorkExperience(Worker[] workers)
    {
        Array.Sort(workers, (w1, w2) => w1.GetWorkExperience().CompareTo(w2.GetWorkExperience()));
    }
}
