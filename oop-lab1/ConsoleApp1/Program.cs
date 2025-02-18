using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            SetCustomCulture(); // Винесено в окремий метод для кращої організації

            double x = ReadDouble("Введіть значення x: ");
            double y = ReadDouble("Введіть значення y: ");
            double z = ReadDouble("Введіть значення z: ");

            double s = CalculateExpression(x, y, z);
            Console.WriteLine($"Результат обчислень: {s:F3}");
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
                    return result; // Оптимізація: одразу повертаємо результат без використання break
                }
                Console.WriteLine("Помилка введення, спробуйте ще раз.");
            }
        }

        static double CalculateExpression(double x, double y, double z)
        {
            double denominator = (z - 2 * x) / (1 + x * x * y * y);
            if (denominator == 0)
            {
                throw new DivideByZeroException("Знаменник дорівнює нулю, обчислення неможливе.");
            }

            // Оптимізація: розбиття на окремі змінні для кращого розуміння
            double term1 = 1 + Math.Sin(x + y);
            double term2 = Math.Abs(denominator);
            double term3 = Math.Pow(x, Math.Abs(y));
            double term4 = Math.Tan(1 / z);

            return term1 / term2 * term3 + term4;
        }
    }
}
