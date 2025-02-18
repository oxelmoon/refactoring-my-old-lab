using System;
using System.Globalization;

namespace ConsoleApp4
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

            int N, K;
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

            while (true)
            {
                Console.Write("Введіть ціле число K (> 0): ");
                if (int.TryParse(Console.ReadLine(), out K) && K > 0)
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
                sum += Math.Pow(i, K);
            }

            Console.WriteLine($"Сума 1^K + 2^K + ... + N^K = {sum:F3}");
        }
    }
}
