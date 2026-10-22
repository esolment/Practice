namespace Practice;

internal static class ConditionalStatementsAndOperators
{
    // shared
    private static readonly double Temperature = Random.Shared.NextDouble() * 70;
    
    public static void Run() // простите что много тернарности. просто с ними интересней, хотелось изучить ещё функционала языка. 
    {
        // 1. Билет в кино
        int age = Random.Shared.Next(0, 101);
        Console.Write($"Вам {age}, поэтому вам ");
        Console.WriteLine(age >= 12 ? "можно на фильм." : "слишком рано.");
        
        // 2. Проверка пароля
        string password = "csharp2026";
        Console.WriteLine(password == "csharp2026" ? "Вход" : "Ошибка");
        
        // 3. Температура
        Console.Write($"Температура воздуха в вашем доме {(int)Temperature} по Цельсию. Вам ");
        Console.WriteLine(Temperature < 10 ? "холодно." : Temperature <= 25 ? "комфортно." : "жарко.");
        
        // 4. Три оценки
        int score = Random.Shared.Next(0, 101);
        Console.Write($"Вы набрали {score}. Ставлю вам ");
        Console.WriteLine(score >= 90 ? "5." : score >= 75 ? "4." : score >= 60 ? "3" : "2.");
        
        // 5. Чётное или нечётное
        int number = Random.Shared.Next(0, 1001);
        Console.Write($"Ваше число {number}, оно ");
        Console.WriteLine(number % 2 == 0 ? "чётное." : "нечётное.");
        
        // 6. Доступ в музей
        List<char> blackList = [ 'X', 'Y', 'Z', 'P', 'S', 'O', 'A', 'U', 'I', 'N', 'M' ];
        bool hasATicket = Random.Shared.NextDouble() < 0.5;
        char clientName = (char)Random.Shared.Next('A', 'Z' + 1);
        bool thisUserInBlacklist = blackList.Contains(clientName);
        Console.Write($"Здравствуйте {clientName}! У вас ");
        Console.Write(hasATicket ? "есть билет" : "нет билета");
        Console.Write(
            thisUserInBlacklist && hasATicket ? ", но вы в чёрном списке."
            : thisUserInBlacklist && !hasATicket ? " и вы в чёрном списке."
            : !thisUserInBlacklist && hasATicket ? " и вы не в чёрном списке."
            : ", но вы не в чёрном списке."
        );
        Console.WriteLine(!hasATicket || thisUserInBlacklist ? " Я не допускаю вас в музей." : " Я допускаю вас в музей.");
        
        // 7. Погодный помощник
        bool rain = Random.Shared.NextDouble() < 0.5;
        Console.Write($"Сейчас {(rain ? "дождь" : "ясно")}, на улице {(int)Temperature} по Цельсию. ");
        Console.Write(rain ? "Возьмите зонт, " : "Не берите зонт, ");
        Console.WriteLine(Temperature <= 10 ? "наденьте куртку!" : "куртку надевать не нужно.");
        
        // 8. Интернет магазин
        decimal productPrice = (decimal)(Random.Shared.NextDouble() * 10_000);
        Console.Write($"Цена товара {Math.Round(productPrice)}. Скидка ");
        Console.WriteLine(
            productPrice <= 999 ? "0%." 
            : productPrice <= 4999 ? "5%."
            : "10%."
        );
        
        // 9. Умный дом
        bool isHome = Random.Shared.NextDouble() < 0.5;
        double targetTemperature = Random.Shared.Next(18, 41);
        if (isHome) // Лично я считаю, что температуру дома нужно регулировать вне зависимости от присутствия в нём людей
        {
            Console.Write("Кто-то есть дома. ");
            Console.Write($"Температура дома {(int)Temperature} по Цельсию. Целевая температура {targetTemperature} по Цельсию. ");
            Console.WriteLine(Temperature >= targetTemperature ? "Отключаем отопление." : "Включаем отопление.");
        }
        else
        {
            Console.WriteLine("Никого нет дома. Не регулируем температуру.");
        }
        
        // 10. Аварийная система
        int battery = Random.Shared.Next(0, 101);
        bool hasConnection = Random.Shared.NextDouble() < 0.5;
        bool isOverheated = Random.Shared.NextDouble() < 0.5;
        Console.Write($"Заряд аккумулятора {battery}%, {(hasConnection ? "подключён" : "не подключён")}, {(isOverheated ? "перегрет" : "не перегрет")}. Итоговый статус: ");
        Console.WriteLine(
            isOverheated ? "Авария."
            : !hasConnection ? "Нет связи."
            : battery <= 5 ? "Заряд критический"
            : "Работа разрешена"
        );
    }
}

// (C) Walter Kerrigan. All right reserved.
// Ни один ИИ не писал этот код.