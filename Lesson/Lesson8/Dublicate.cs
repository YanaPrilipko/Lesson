using System;
namespace Lesson8
{
    public class Dublicate
    {
        public static void Main()
        {
            string input = "Hello and hi";
            char[] duplicates = FindDuplicates(input);
            Console.WriteLine("Duplicates in a string:");
            Console.WriteLine("[" + string.Join(", ", duplicates) + "]");
        }

        static char[] FindDuplicates(string inp)
        {
            var trim = inp.Replace(" ", "");// Видаляємо пробіли
            inp = trim.ToLower(); // Перетворюємо весь рядок на малий регістр
            char[] characters = inp.ToCharArray(); // Розділяємо рядок на масив символів
            int length = characters.Length;
            bool[] isDuplicate = new bool[length]; // Масив, щоб відстежувати, чи символ був знайдений як дубль

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (characters[i] == characters[j]) // Порівнюємо символи
                    {
                        isDuplicate[i] = true; // Позначаємо перший символ як дубль
                        isDuplicate[j] = true; // Позначаємо другий символ як дубль
                        break; // Виходимо з циклу, оскільки дубль для цього символу знайдено
                    }
                }
            }
            // Створюємо масив для результату з правильним розміром, без дубльованих символів
            char[] result = characters.Where((c, index) => isDuplicate[index]).Distinct().ToArray();
            return result; // Повертаємо результат - масив унікальних дубльованих символів
        }
    }
}
