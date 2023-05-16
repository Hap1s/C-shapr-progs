using System;
using System.Collections.Generic;
using System.IO;

struct SPoint // определяем структуру SPoint
{
    public string name;
    public int year;
    public string position;
    public double salary;
    public int experience;
}

class Program
{
    static void Main(string[] args)
    {
        List<SPoint> employees = new List<SPoint>(); // создаем список сотрудников

        // считываем данные из входного файла и заполняем список
        StreamReader reader = new StreamReader("input.txt");
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] data = line.Split(';');
            SPoint employee = new SPoint();
            employee.name = data[0];
            employee.year = int.Parse(data[1]);
            employee.position = data[2];
            employee.salary = double.Parse(data[3]);
            employee.experience = int.Parse(data[4]);
            employees.Add(employee);
        }
        reader.Close();

        // выводим информацию о сотрудниках, имеющих зарплату ниже определенного уровня, отсортированных по рабочему стажу
        double minSalary = 20000;
        employees.Sort((x, y) => x.experience.CompareTo(y.experience)); // сортируем по рабочему стажу
        StreamWriter writer = new StreamWriter("output.txt");
        foreach (SPoint employee in employees)
        {
            if (employee.salary < minSalary)
            {
                writer.WriteLine("ФИО: " + employee.name);
                writer.WriteLine("Год принятия на работу: " + employee.year);
                writer.WriteLine("Должность: " + employee.position);
                writer.WriteLine("Зарплата: " + employee.salary);
                writer.WriteLine("Рабочий стаж: " + employee.experience);
                writer.WriteLine();
            }
        }
        writer.Close();

        Console.WriteLine("Готово!");
        Console.ReadLine();
    }
}

