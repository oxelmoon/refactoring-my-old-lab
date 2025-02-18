using System;
using System.Globalization;

namespace ConsoleApp5
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

            int evenCount = 0, oddCount = 0, positiveCount = 0, negativeCount = 0;
            while (true)
            {
                Console.Write("Введіть ціле число (введіть 0 для завершення): ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number == 0)
                    {
                        break;
                    }

                    if (number % 2 == 0)
                    {
                        evenCount++;
                    }
                    else
                    {
                        oddCount++;
                    }

                    if (number > 0)
                    {
                        positiveCount++;
                    }
                    else if (number < 0)
                    {
                        negativeCount++;
                    }
                }
                else
                {
                    Console.WriteLine("Помилка введення. Спробуйте ще раз.");
                }
            }

            Console.WriteLine($"Кількість парних чисел: {evenCount}");
            Console.WriteLine($"Кількість непарних чисел: {oddCount}");
            Console.WriteLine($"Кількість додатних чисел: {positiveCount}");
            Console.WriteLine($"Кількість від'ємних чисел: {negativeCount}");
        }
    }
}
