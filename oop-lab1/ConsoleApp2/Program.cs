using System;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;

            double a = ReadDouble("Введіть значення a: ");
            double b = ReadDouble("Введіть значення b: ");
            double c = ReadDouble("Введіть значення c: ");

            CalculateRoots(a, b, c);
        }

        static double ReadDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out result))
                {
                    break;
                }
                Console.WriteLine("Помилка введення, спробуйте ще раз.");
            }
            return result;
        }

        static void CalculateRoots(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискримінант: {discriminant:F3}");

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
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
