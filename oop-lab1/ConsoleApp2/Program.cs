using System;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            SetCustomCulture(); // Зміна 1: винесено налаштування культури в окремий метод

            double a = ReadDouble("Введіть значення a: ");
            double b = ReadDouble("Введіть значення b: ");
            double c = ReadDouble("Введіть значення c: ");

            SolveQuadraticEquation(a, b, c); // Зміна 2: перейменовано метод для більшої ясності
        }

        static void SetCustomCulture()
        {
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out double result))
                {
                    return result;
                }
                Console.WriteLine("Помилка введення, спробуйте ще раз.");
            }
        }

        static void SolveQuadraticEquation(double a, double b, double c)
        {
            if (a == 0)
            {
                Console.WriteLine("Це не квадратне рівняння."); // Зміна 3: додано перевірку на некоректне введення
                return;
            }

            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискримінант: {discriminant:F3}");

            if (discriminant > 0)
            {
                double sqrtD = Math.Sqrt(discriminant);
                double x1 = (-b + sqrtD) / (2 * a);
                double x2 = (-b - sqrtD) / (2 * a);
                Console.WriteLine($"Розв'язки: x1 = {x1:F3}, x2 = {x2:F3}");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Розв'язок: x = {x:F3}");
            }
            else
            {
                Console.WriteLine("Розв'язків немає.");
            }
        }
    }
}