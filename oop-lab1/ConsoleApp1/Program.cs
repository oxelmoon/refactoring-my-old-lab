using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;

            double x = ReadDouble("Введіть значення x: ");
            double y = ReadDouble("Введіть значення y: ");
            double z = ReadDouble("Введіть значення z: ");

            double s = CalculateExpression(x, y, z);
            Console.WriteLine($"Результат обчислень: {s:F3}");
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

        static double CalculateExpression(double x, double y, double z)
        {
            return 1 + Math.Sin(x + y) / Math.Abs((z - 2 * x) / (1 + x * x * y * y)) * Math.Pow(x, Math.Abs(y)) + Math.Tan(1 / z);
        }
    }
}
