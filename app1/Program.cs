using System;
using dll;

namespace MyApp
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    internal class Program
    {
        private static float ReadDouble(string message)
        {
            Console.Write(message);
            if (!float.TryParse(Console.ReadLine(), out float result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            return result;
        }

        private static int ReadInteger(string message)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            return result;
        }
        static void Main(string[] args)
        {
            try
            {
                int productType = ReadInteger("Введите тип продукции (1-3): ");
                int materialType = ReadInteger("\nВведите тип материала (1-2): ");
                int count = ReadInteger("\nВведите количество: ");
                float width = ReadDouble("\nВведите ширину: ");
                float length = ReadInteger("\nВведите длину: ");
                int resilt = dll.Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
                if (resilt != -1) Console.WriteLine($"\nКоличество необходимого качественного сырья на одну единицу продукции: {resilt}");
                else Console.WriteLine("Вычисление не удалось.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}"); 
            }
        }
    }
}