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
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = customCulture;

            int N;
            while (true)
            {
                Console.Write("Введіть ціле число N (> 0): ");
                if (int.TryParse(Console.ReadLine(), out N) && N > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Помилка введення. Спробуйте ще раз.");
                }
            }

            double sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum += Math.Pow(i, N - i + 1);
            }

            Console.WriteLine($"Сума 1^N + 2^(N-1) + ... + N^1 = {sum:F3}");
        }
    }
}
