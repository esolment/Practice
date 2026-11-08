namespace Practice;

internal static class LoopsAndArrays
{
    private static readonly int[] MixedArray = [8, -5, 0, 9, 3, -5, 4];

    // interactive = true: данные вводит пользователь
    // interactive = false: данные выбираются случайно
    public static void Run(bool interactive)
    {
        int[] mixedArray = [..MixedArray];

        // 1
        int num = 1;
        while (num <= 20)
        {
            Console.WriteLine(num);
            num++;
        }

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(i);
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
        int n = GetInt(interactive, "Введите N для суммы 1..N: ", 1, 100);
        if (n < 1)
        {
            Console.WriteLine("N должно быть не меньше 1.");
        }
        else
        {
            long sum = 0;
            int counter = 1;
            while (counter <= n)
            {
                sum += counter;
                counter++;
            }
            Console.WriteLine($"Сумма чисел 1..{n}: {sum}");
        }

        // 5
        int multiplicationTable = GetInt(interactive, "Введите число для таблицы умножения: ", 0, 9);
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{multiplicationTable} * {i} = {multiplicationTable * i}");
        }

        // 6
        int positiveNumber = GetInt(interactive, "Введите положительное число для подсчёта цифр: ", 1, 1_000_000, 1);
        int count = 0;
        while (positiveNumber > 0)
        {
            positiveNumber /= 10;
            count++;
        }
        Console.WriteLine($"Количество цифр: {count}");

        // 7
        int[] positiveArray = [1, 2, 3, 4, 5, 6, 7, 8];
        Console.WriteLine($"Длина массива: {positiveArray.Length}");
        for (int i = 0; i < positiveArray.Length; i++)
        {
            Console.WriteLine($"{i}: {positiveArray[i]}");
        }

        // 8
        int[] scores = [5, 4, 2, 5, 3];
        scores[2] = 5;
        foreach (int item in scores)
        {
            Console.WriteLine(item);
        }

        // 9
        int arraySum = 0;
        foreach (int item in mixedArray)
        {
            arraySum += item;
        }
        Console.WriteLine($"Сумма: {arraySum}");
        Console.WriteLine($"Среднее: {(double)arraySum / mixedArray.Length}");

        // 10
        int arrayMin = 0;
        int arrayMax = 0;
        if (mixedArray.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
        }
        else
        {
            arrayMin = mixedArray[0];
            arrayMax = mixedArray[0];
            for (int i = 1; i < mixedArray.Length; i++)
            {
                if (mixedArray[i] < arrayMin) arrayMin = mixedArray[i];
                if (mixedArray[i] > arrayMax) arrayMax = mixedArray[i];
            }
            Console.WriteLine($"Min: {arrayMin}");
            Console.WriteLine($"Max: {arrayMax}");
        }

        // 11
        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;
        foreach (int i in mixedArray)
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
        Console.WriteLine($"Массив: {string.Join(", ", mixedArray)}");
        int targetElement;
        if (interactive)
        {
            targetElement = ReadInt("Введите число для поиска в массиве: ");
        }
        else
        {
            targetElement = mixedArray[Random.Shared.Next(mixedArray.Length)];
            Console.WriteLine($"Число для поиска в массиве: {targetElement} (случайно)");
        }

        int firstIndex = -1;
        for (int i = 0; i < mixedArray.Length; i++)
        {
            if (mixedArray[i] == targetElement)
            {
                firstIndex = i;
                break;
            }
        }
        Console.WriteLine($"Индекс первого элемента, равного {targetElement}: {firstIndex}");

        // 13
        int lastIndex = -1;
        for (int i = mixedArray.Length - 1; i >= 0; i--)
        {
            if (mixedArray[i] == targetElement)
            {
                lastIndex = i;
                break;
            }
        }
        Console.WriteLine($"Индекс последнего элемента, равного {targetElement}: {lastIndex}");

        // 14
        Console.Write("В обратном порядке: ");
        for (int i = mixedArray.Length - 1; i >= 0; i--)
        {
            Console.Write(i == 0 ? $"{mixedArray[i]}" : $"{mixedArray[i]}, ");
        }
        Console.WriteLine();

        int[] reversedArray = [..mixedArray];
        for (int i = 0; i < reversedArray.Length / 2; i++)
        {
            int opposite = reversedArray.Length - 1 - i;
            (reversedArray[i], reversedArray[opposite]) = (reversedArray[opposite], reversedArray[i]);
        }
        Console.WriteLine($"Обмен элементов внутри массива: {string.Join(", ", reversedArray)}");

        // 15
        int last = mixedArray[0];
        bool sorted = true;
        foreach (int i in mixedArray)
        {
            if (i < last)
            {
                sorted = false;
                break;
            }
            last = i;
        }
        Console.WriteLine(sorted ? "Массив отсортирован." : "Массив не отсортирован.");

        // 16
        bool hasFirst = false;
        bool hasSecond = false;
        int firstMax = 0;
        int secondMax = 0;
        foreach (int i in mixedArray)
        {
            if (!hasFirst || i > firstMax)
            {
                if (hasFirst)
                {
                    secondMax = firstMax;
                    hasSecond = true;
                }
                firstMax = i;
                hasFirst = true;
            }
            else if (i < firstMax && (!hasSecond || i > secondMax))
            {
                secondMax = i;
                hasSecond = true;
            }
        }

        if (hasSecond)
        {
            Console.WriteLine($"Второе различное максимальное значение: {secondMax}");
        }
        else
        {
            Console.WriteLine("Второе различное максимальное значение отсутствует.");
        }

        // 17
        int r = GetInt(interactive, "Введите число строк R: ", 3, 8, 1, 100);
        int c = GetInt(interactive, "Введите число столбцов C: ", 3, 8, 1, 100);
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                Console.Write("#  ");
            }
            Console.WriteLine();
        }

        // 18
        int triangleSide = GetInt(interactive, "Введите N для треугольника: ", 4, 30, 1, 100);
        // вложенные массивы к сожалению не понадобились
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
        Console.WriteLine($"Исходный массив: {string.Join(", ", positiveArray)}");
        int lastItem = positiveArray[^1];
        for (int i = positiveArray.Length - 1; i > 0; i--)
        {
            positiveArray[i] = positiveArray[i - 1];
        }
        positiveArray[0] = lastItem;
        Console.WriteLine($"Сдвинутый массив: {string.Join(", ", positiveArray)}");

        // 20
        Console.WriteLine($"Исходный массив: {string.Join(", ", mixedArray)}");
        Console.Write("Без повторов: ");
        for (int i = 0; i < mixedArray.Length; i++)
        {
            bool seen = false;
            for (int j = 0; j < i; j++)
            {
                if (mixedArray[j] == mixedArray[i])
                {
                    seen = true;
                    break;
                }
            }
            if (!seen)
            {
                Console.Write($"{mixedArray[i]} ");
            }
        }
        Console.WriteLine();

        // 21
        Console.WriteLine($"Массив для поиска: {string.Join(", ", mixedArray)}");
        int k;
        if (interactive)
        {
            k = ReadInt("Введите искомую сумму пары K: ");
        }
        else
        {
            k = Random.Shared.Next(arrayMin, arrayMax + 1) + Random.Shared.Next(arrayMin, arrayMax + 1);
            Console.WriteLine($"Искомая сумма пары K: {k} (случайно)");
        }

        bool found = false;
        for (int i = 0; i < mixedArray.Length && !found; i++)
        {
            for (int j = i + 1; j < mixedArray.Length; j++)
            {
                if (mixedArray[i] + mixedArray[j] == k)
                {
                    Console.WriteLine($"Индексы пары: {i}, {j}");
                    Console.WriteLine($"Значения: {mixedArray[i]}, {mixedArray[j]}");
                    found = true;
                    break;
                }
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
                Console.Write($"{matrix[i, j],3}");
            }
            Console.WriteLine();
        }

        // Вычисление и вывод суммы по каждой строке
        Console.WriteLine("Сумма каждой строки матрицы:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
            }
            Console.WriteLine($"Строка {i}: {rowSum}");
        }

        // 23
        int[] sortedArray = [..mixedArray];
        Console.WriteLine($"Исходный массив: {string.Join(", ", mixedArray)}");

        for (int i = 0; i < sortedArray.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < sortedArray.Length - 1 - i; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]);
                    swapped = true;
                }
            }
            Console.WriteLine($"После прохода {i + 1}: {string.Join(", ", sortedArray)}");

            // Досрочный выход
            if (!swapped) break;
        }

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
        if (interactive)
        {
            Console.WriteLine("Введите количество ресурсов для поиска (или 'exit' для выхода):");

            while (true)
            {
                Console.Write("\nВаш запрос: ");
                string? input = Console.ReadLine();

                if (input == null || input.ToLower() == "exit")
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                if (int.TryParse(input, out int searchTarget))
                {
                    SearchWarehouse(warehouses, searchTarget);
                }
                else
                {
                    Console.WriteLine("[ERROR] Введите корректное число или 'exit' для выхода.");
                }
            }
        }
        else
        {
            int randomTarget = Random.Shared.Next(0, 11);
            Console.WriteLine($"Случайный запрос: {randomTarget}");
            SearchWarehouse(warehouses, randomTarget);
        }
    }

    // Поиск первого склада с нужным количеством ресурса
    private static void SearchWarehouse(int[] warehouses, int searchTarget)
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
            Console.WriteLine($"[SUCCESS] Первый склад с таким количеством - это Склад #{foundIndex}");
        }
        else
        {
            Console.WriteLine("[ERROR] Склада с таким точным количеством ресурсов не найдено.");
        }
    }

    // Ввод пользователя или случайное значение, в зависимости от режима
    private static int GetInt(bool interactive, string prompt, int randomMin, int randomMax,
        int min = int.MinValue, int max = int.MaxValue)
    {
        if (interactive)
        {
            return ReadInt(prompt, min, max);
        }

        int value = Random.Shared.Next(randomMin, randomMax + 1);
        Console.WriteLine($"{prompt}{value} (случайно)");
        return value;
    }

    // Чтение целого числа с повтором при ошибке
    private static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            {
                return value;
            }
            Console.WriteLine("[ERROR] Введите корректное целое число.");
        }
    }
}