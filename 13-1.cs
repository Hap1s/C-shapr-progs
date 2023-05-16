using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\example.txt"; // путь к файлу
        int longestLineNum = 0; // номер самой длинной строки
        int currentLineNum = 0; // текущий номер строки
        int longestLineLength = 0; // длина самой длинной строки

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                currentLineNum++;
                string line = reader.ReadLine();
                if (line.Length > longestLineLength)
                {
                    longestLineNum = currentLineNum;
                    longestLineLength = line.Length;
                }
            }
        }

        Console.WriteLine("Номер самой длинной строки: " + longestLineNum);
        Console.ReadLine();
    }
}
