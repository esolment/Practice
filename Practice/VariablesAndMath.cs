namespace Practice;

internal static class VariablesAndMath
{
    public static void Run()
    {
        // 1. Сборка коробки
        int parts = 15;
        Console.WriteLine(parts);

        // 2. Запас аккумуляторов
        int energy = 20;
        energy -= 7;
        Console.WriteLine($"Энергии у робота: {energy}");

        // 3. Мини-завод
        const int detailsPerHour = 12;
        int hours = 8;
        int detailsSum = detailsPerHour * hours;
        Console.WriteLine($"Конвейер собирает {detailsSum} деталей за {hours} часов");

        // 4. Упаковка
        const int boxSize = 6;
        const int details = 29;
        Console.WriteLine($"Полных коробок: {details / boxSize}\nОстанется деталей: {details % boxSize}");

        // 5. Средний результат
        List<int> detailsPerRobot = new() { 7, 8, 9 };
        Console.WriteLine($"Средний показатель роботов: {detailsPerRobot.Average()}");

        // 6. Цена заказа
        const decimal oneDetail = 49.90m;
        Console.WriteLine($"Цена 4-х деталей: {oneDetail * 4}");

        // 7. Рост производительности
        const int totalUnits = 40;
        double growth = 1.15;
        Console.WriteLine($"Итоговое количество единиц: {totalUnits * growth}");

        // 8. Инженерная задача
        const int bolts = 137;
        const int robots = 8;

        int boltsPerRobot = bolts / robots;
        int reserve = bolts % robots;
        int boltsSum = boltsPerRobot * robots;

        Console.WriteLine($"Болтов на робота: {boltsPerRobot}\nОтправлено болтов в резерв: {reserve}\nВсего болтов роздано: {boltsSum}");
    }
}

// (C) Walter Kerrigan. All right reserved.
// Ни один ИИ не писал этот код.