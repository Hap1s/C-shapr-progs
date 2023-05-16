using System;

struct SPoint // определяем структуру SPoint
{
    public int x;
    public int y;
}

class Program
{
    static void Main(string[] args)
    {
        SPoint[] points = new SPoint[10]; // создаем массив из 10 точек

        // заполняем массив случайными координатами
        Random random = new Random();
        for (int i = 0; i < points.Length; i++)
        {
            points[i].x = random.Next(100);
            points[i].y = random.Next(100);
            Console.WriteLine("Точка " + (i + 1) + ": (" + points[i].x + ", " + points[i].y + ")");
        }

        // находим две наиболее удаленные друг от друга точки
        double maxDistance = 0;
        SPoint point1 = new SPoint();
        SPoint point2 = new SPoint();
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                double distance = Distance(points[i], points[j]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    point1 = points[i];
                    point2 = points[j];
                }
            }
        }

        // выводим результаты
        Console.WriteLine("Наиболее удаленные точки:");
        Console.WriteLine("Точка 1: (" + point1.x + ", " + point1.y + ")");
        Console.WriteLine("Точка 2: (" + point2.x + ", " + point2.y + ")");
        Console.WriteLine("Расстояние между ними: " + maxDistance);

        Console.ReadLine();
    }

    static double Distance(SPoint point1, SPoint point2) // метод для вычисления расстояния между двумя точками
    {
        int dx = point1.x - point2.x;
        int dy = point1.y - point2.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
