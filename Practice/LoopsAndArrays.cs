namespace Practice;

internal static class LoopsAndArrays
{
    private static readonly int[] MixedArray = [8, -5, 0, 9, 3, -5, 4];
    private static readonly int TargetElement = MixedArray[Random.Shared.Next(MixedArray.Length)];
    
    public static void Run()
    {
        // 1
        int num = 1;
        while (num < 11)
        {
            Console.WriteLine(num);
            num++;
        }

        // 2
        int from = 15;
        while (from >= 0)
        {
            Console.WriteLine(from);
            from--;
        }
        Console.WriteLine("Старт!");

        // 3
        for (int i = 2; i <= 50; i += 2)
        {
            Console.WriteLine(i);
        }

        // 4
        int n = Random.Shared.Next(1, 101);
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        Console.WriteLine($"Сумма чисел 1..{n}: {sum}");

        // 5
        int multiplicationTable = Random.Shared.Next(10);
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{multiplicationTable} * {i} = {multiplicationTable * i}");
        }

        // 6
        int positiveNumber = Random.Shared.Next(101);
        int count = 0;
        while (positiveNumber > 0)
        {
            positiveNumber /= 10;
            count++;
        }
        Console.WriteLine(count);

        // 7
        int[] positiveArray = [1, 2, 3, 4, 5, 6, 7, 8 ];
        Console.WriteLine($"Длина массива: {positiveArray.Length}");
        foreach (var (index, item) in positiveArray.Index())
        {
            Console.WriteLine($"{index}: {item}");
        }

        // 8
        int[] scores = [5, 5, 2, 5, 5];
        scores[2] = 5;
        foreach (int item in scores)
        {
            Console.WriteLine(item);
        }

        // 9
        Console.WriteLine(MixedArray.Sum());
        Console.WriteLine(MixedArray.Average());

        // 10
        if (MixedArray.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
        }
        else
        {
            int min = MixedArray[0];
            int max = MixedArray[0];
            for (int i = 1; i < MixedArray.Length; i++)
            {
                min = Math.Min(min, MixedArray[i]);
                max = Math.Max(max, MixedArray[i]);
            }
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
        }

        // 11
        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;
        foreach (int i in MixedArray)
        {
            if (i == 0)
            {
                zeroCount++;
            }
            else if (i > 0)
            {
                positiveCount++;
            }
            else
            {
                negativeCount++;
            }
        }

        Console.WriteLine($"Положительных: {positiveCount}");
        Console.WriteLine($"Отрицательных: {negativeCount}");
        Console.WriteLine($"Нулей: {zeroCount}");
        
        // 12
        foreach (var (index, item) in MixedArray.Index())
        {
            if (item != TargetElement) continue;
            Console.WriteLine($"Индекс первого элемента равному {TargetElement}: {index}");
            break;
        }
        
        // 13
        foreach (var (index, item) in MixedArray.AsEnumerable().Index().Reverse())
        {
            if (item != TargetElement) continue;
            Console.WriteLine($"Индекс последнего элемента равному {TargetElement}: {index}");
        }
        
        // 14
        Console.WriteLine(string.Join(", ", MixedArray.Reverse().ToArray()));
        // TODO: Обменять элементы
        
        // 15
        int last = positiveArray[0];
        bool sorted = true;
        foreach (var i in positiveArray)
        {
            if (i < last)
            {
                Console.WriteLine("Массив не отсортирован.");
                sorted = false;
                break;
            }
        }
        if (sorted)
        {
            Console.WriteLine("Массив отсортирован.");
        }
        
        // 16
        if (MixedArray.Length < 2)
        {
            Console.WriteLine("Второе различное максимальное значение отсутствует.");
        }
        else
        {
            List<int> mixedList = [..MixedArray];
            int lastMaxValue = mixedList.Max();
            while (true)
            {
                mixedList.Remove(lastMaxValue);
                int? maxValue = mixedList.Cast<int?>().Max();
                if (maxValue == null)
                {
                    Console.WriteLine("Второе различное максимальное значение отсутствует.");
                    break;
                }
                if (maxValue != lastMaxValue)
                {
                    Console.WriteLine($"Второе различное максимальное значение: {maxValue}");
                    break;
                }
            }
        }
        
        // 17
        
    }
}