using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath1 = @"C:\file1.txt"; // путь к первому файлу
        string filePath2 = @"C:\file2.txt"; // путь ко второму файлу
        string resultFilePath = @"C:\result.txt"; // путь к файлу с результатом

        int[] numbers1 = ReadNumbersFromFile(filePath1); // читаем числа из первого файла
        int[] numbers2 = ReadNumbersFromFile(filePath2); // читаем числа из второго файла

        if (numbers1.Length != numbers2.Length) // проверяем, что массивы имеют одинаковую длину
        {
            Console.WriteLine("Ошибка: массивы имеют разную длину.");
            Console.ReadLine();
            return;
        }

        int[] result = new int[numbers1.Length]; // создаем массив для результата

        for (int i = 0; i < numbers1.Length; i++) // складываем соответствующие элементы массивов
        {
            result[i] = numbers1[i] + numbers2[i];
        }

        WriteNumbersToFile(resultFilePath, result); // записываем результат в файл

        Console.WriteLine("Результат успешно записан в файл " + resultFilePath);
        Console.ReadLine();
    }

    static int[] ReadNumbersFromFile(string filePath) // метод для чтения чисел из файла
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(' ');
            int[] numbers = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                numbers[i] = int.Parse(parts[i]);
            }
            return numbers;
        }
    }

    static void WriteNumbersToFile(string filePath, int[] numbers) // метод для записи чисел в файл
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                writer.Write(numbers[i] + " ");
            }
        }
    }
}
