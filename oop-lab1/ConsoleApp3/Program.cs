using System;
using System.Globalization;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            SetCustomCulture(); // Зміна 1: винесено налаштування культури в окремий метод

            int N = ReadPositiveInteger("Введіть ціле число N (> 0): "); // Зміна 2: винесено введення в окремий метод

            double sum = CalculateSum(N);
            Console.WriteLine($"Сума 1^N + 2^(N-1) + ... + N^1 = {sum:F3}");
        }

        static void SetCustomCulture()
        {
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;
        }

        static int ReadPositiveInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                {
                    return number;
                }
                Console.WriteLine("Помилка введення. Спробуйте ще раз.");
            }
        }

        static double CalculateSum(int N) // Зміна 3: винесено обчислення суми в окремий метод
        {
            double sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum += Math.Pow(i, N - i + 1);
            }
            return sum;
        }
    }
}
