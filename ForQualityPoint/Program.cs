using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForQualityPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(  "Данное приложение выберет число с наибольшей суммой цифр и посчитает ее.\n" +
                                "Для получения результата введите \"0\".");

            int maxSum = 0;
            int numberWithMaxSum = 0;

            while (true)
            {
                Console.WriteLine("Введите целое число: ");
                string input = Console.ReadLine();

                if (input == "0")
                    break;
              
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Ввод некорректный. Пожалуйста, введите целое число.");//2147483647
                 
                    if (input.Length >= 9)
                    {
                        Console.WriteLine("Убедитесь что ваше число находится в диапозоне от - 2 147 483 648 до 2 147 483 647 ");
                    }
                    continue;
                }

                int sum = GetSumOfDigits(number);
                
                if (sum > maxSum)
                {
                    maxSum = sum;
                    numberWithMaxSum = number;
                }
            }

            Console.WriteLine("Число с максимальной суммой цифр: " + numberWithMaxSum);
            Console.WriteLine("Сумма цифр в этом числе: " + maxSum);
            Console.ReadLine();

            int GetSumOfDigits(int number)
            {
                
                bool overflow = false;
                int sum = 0;

                if (number == int.MinValue)
                {
                    overflow = true;
                    number++;
                    
                }

                number = Math.Abs(number);
                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                if (overflow)
                {
                    sum++;
                }
                return sum;
            }
        }
    }
}
