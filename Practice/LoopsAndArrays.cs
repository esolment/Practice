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
        int last = MixedArray[0];
        bool sorted = true;
        foreach (var i in MixedArray)
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
        int r = Random.Shared.Next(3, 9);
        int c = Random.Shared.Next(3, 9);
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                Console.Write("#  ");
            }
            Console.WriteLine();
        }
        
        // 18
        // вложенные массивы к сожалению не понадобились
        int triangleSide = Random.Shared.Next(4, 31);
        string spaces = "";
        string matter = "#";
        
        for (int i = 0; i < triangleSide / 2; i++)
        {
            spaces += " ";
        }

        while (true)
        {
            Console.WriteLine($"{spaces}{matter}");
            if (spaces.Length > 0)
            {
                spaces = spaces.Remove(0, 1);
                matter += "##";
            }
            else
            {
                break;
            }
        }
        
        // 19
        Console.WriteLine($"Исходный массив: {String.Join(", ", positiveArray)}");
        int lastItem = positiveArray[^1];
        int zeroItem;
        for (int i = 0; i < positiveArray.Length; i++)
        {
            zeroItem = positiveArray[i];
            positiveArray[i] = lastItem;
            if (i != positiveArray.Length - 1)
            { 
                lastItem = zeroItem;
            }
        }
        Console.WriteLine($"Сдвинутый массив: {String.Join(", ", positiveArray)}");
        
        // 20
        List<int> uniqueList = [];
        foreach (int i in MixedArray)
        {
            if (!uniqueList.Contains(i))
            {
                uniqueList.Add(i);
            }
        }
        Console.WriteLine($"Исходный массив: {String.Join(", ", MixedArray)}");
        Console.WriteLine($"Без повторов: {String.Join(", ", uniqueList)}");
        
        // 21
        int range1 = Random.Shared.Next(MixedArray.Min(), MixedArray.Max() + 1);
        int range2 = Random.Shared.Next(MixedArray.Min(), MixedArray.Max() + 1);
        int k = range1 + range2;
        bool found = false;
        
        Console.WriteLine($"Массив для поиска: {String.Join(", ", MixedArray)}");
        Console.WriteLine($"Искомая сумма пар: {k}");
        
        for (int i = 0; i < MixedArray.Length; i++)
        {
            int lookingPair = MixedArray[i];
            for (int j = i + 1; j < MixedArray.Length; j++)
            {
                if (MixedArray[j] + lookingPair == k)
                {
                    Console.WriteLine($"Индексы пары: {i}, {j}"); 
                    Console.WriteLine($"Значения: {lookingPair}, {MixedArray[j]}");
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет пары.");
        }
        
        // 22
        int[,] matrix = new int[3, 4];
        
        // Заполнение числами
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Random.Shared.Next(0, 11);
            }
        }
        
        // Вычисление суммы по каждой строке
        List<int> rowsSum = [];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
            }
            rowsSum.Add(rowSum);
        }
        
        // Вывод сумм
        Console.WriteLine("Сумма каждой строки матрицы:");
        foreach (var (index, item) in rowsSum.Index())
        {
            Console.WriteLine($"Строка {index}: {item}");
        }
        
        // 23
        int[] sortedArray = MixedArray.ToArray(); 

        for (int i = 0; i < sortedArray.Length - 1; i++)
        {
            for (int j = 0; j < sortedArray.Length - 1 - i; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]);
                }
            }
        }

        Console.WriteLine($"Исходный массив: {string.Join(", ", MixedArray)}");
        Console.WriteLine($"Сортированный массив: {string.Join(", ", sortedArray)}");
        
        // 24
        Console.WriteLine("\nСклад экспедиции.");
        
        int[] warehouses = new int[10];

        for (int i = 0; i < warehouses.Length; i++)
        {
            warehouses[i] = Random.Shared.Next(0, 11);
        }

        // Вывод содержимого
        Console.WriteLine("Содержимое складов:");
        for (int i = 0; i < warehouses.Length; i++)
        {
            Console.WriteLine($"Склад #{i}: {warehouses[i]} ед. ресурса");
        }
        Console.WriteLine(new string('-', 35));

        // Сумма, минимум, максимум, пустые
        int totalSum = 0;
        int emptyCount = 0;
        
        int minStock = warehouses[0];
        int maxStock = warehouses[0];

        for (int i = 0; i < warehouses.Length; i++)
        {
            int current = warehouses[i];

            // Сумма
            totalSum += current;

            // Пустые
            if (current == 0)
            {
                emptyCount++;
            }

            // Минимум
            if (current < minStock)
            {
                minStock = current;
            }

            // Максимум
            if (current > maxStock)
            {
                maxStock = current;
            }
        }
        
        Console.WriteLine($"Общая сумма ресурсов: {totalSum}");
        Console.WriteLine($"Минимальный запас: {minStock}");
        Console.WriteLine($"Максимальный запас: {maxStock}");
        Console.WriteLine($"Число пустых складов: {emptyCount}");
        Console.WriteLine(new string('-', 35));

        // Поиск склада по количеству ресурса
        Console.WriteLine("Введите количество ресурсов для поиска (или 'exit' для выхода):");

        while (true)
        {
            Console.Write("\nВаш запрос: ");
            string? input = Console.ReadLine();

            if (input == null) continue;
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Программа завершена.");
                break;
            }
            
            if (int.TryParse(input, out int searchTarget))
            {
                int foundIndex = -1;
                
                for (int i = 0; i < warehouses.Length; i++)
                {
                    if (warehouses[i] == searchTarget)
                    {
                        foundIndex = i;
                        break;
                    }
                }
                
                if (foundIndex != -1)
                {
                    Console.WriteLine($"[SUCCESS] Первый склад с таким количеством — это Склад #{foundIndex}");
                }
                else
                {
                    Console.WriteLine("[ERROR] Склада с таким точным количеством ресурсов не найдено.");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Введите корректное число или 'exit' для выхода.");
            }
        }
    }
}