namespace Practice;

public static class AssemblyLine
{
    private static readonly List<Report> _reports = [];
    private static int _rejectedCount;
    private static bool _debug;

    private static void Log(string log)
    {
        if (_debug) { Console.WriteLine(log); }
    }

    public abstract class Drone
    {
        public string Serial { get; }
        public int Energy { get; }
        public int Id { get; private set; }

        public static int CreatedCount { get; private set; }

        public abstract string Model { get; }

        protected Drone(string serial, int energy)
        {
            Log("ctor Drone");

            ArgumentException.ThrowIfNullOrWhiteSpace(serial);
            ArgumentOutOfRangeException.ThrowIfNegative(energy);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(energy, 100);

            Serial = serial;
            Energy = energy;
        }

        // Вызывается последней строкой конструктора самого производного класса,
        // когда вся валидация пройдена: брак в счётчик не попадает.
        protected void Commit() => Id = ++CreatedCount;
    }

    public class ScoutDrone : Drone
    {
        public int Range { get; }

        public override string Model => "Scout";

        public ScoutDrone(string serial, int energy, int range) : base(serial, energy)
        {
            Log("ctor ScoutDrone");

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(range);

            Range = range;
            Commit();
        }

        public ScoutDrone(string serial, int energy) : this(serial, energy, 50) { }

        public ScoutDrone(string serial) : this(serial, 100) { }
    }

    public class CargoDrone : Drone
    {
        public int Capacity { get; }

        public override string Model => "Cargo";

        public CargoDrone(string serial, int energy, int capacity) : base(serial, energy)
        {
            Log("ctor CargoDrone");

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);

            Capacity = capacity;
            Commit();
        }

        public CargoDrone(string serial, int energy) : this(serial, energy, 100) { }

        public CargoDrone(string serial) : this(serial, 100) { }
    }

    public class MedicDrone : Drone
    {
        public int Kits { get; }

        public override string Model => "Medic";

        public MedicDrone(string serial, int energy, int kits) : base(serial, energy)
        {
            Log("ctor MedicDrone");

            ArgumentOutOfRangeException.ThrowIfNegative(kits);

            Kits = kits;
            Commit();
        }

        public MedicDrone(string serial, int energy) : this(serial, energy, 5) { }

        public MedicDrone(string serial) : this(serial, 100) { }
    }

    public class License
    {
        private License(string key) => Key = key;
        public string Key { get; }

        public static License? TryParse(string? key) =>
            key is { Length: 8 } && key.All(char.IsLetterOrDigit) ? new License(key) : null;
    }

    public record Report(string Serial, string Model, int Energy, DateTime CreatedUtc)
    {
        public static Report From(Drone drone) =>
            new(drone.Serial, drone.Model, drone.Energy, DateTime.UtcNow);
    }

    private static string ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private static int ReadInt(string prompt) => int.Parse(ReadLine(prompt));

    private static void Assemble(Func<Drone> build)
    {
        try
        {
            Drone drone = build();
            _reports.Add(Report.From(drone));
            Console.WriteLine($"Собран: {drone.Model} {drone.Serial} (№{drone.Id}).");
        }
        catch (Exception e) when (e is ArgumentException or FormatException or OverflowException)
        {
            _rejectedCount++;
            Console.WriteLine($"Брак отклонён: {e.Message}");
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Сборочная линия ===");
        Console.WriteLine("1. Создать scout");
        Console.WriteLine("2. Создать cargo");
        Console.WriteLine("3. Создать medic");
        Console.WriteLine("4. Показать CreatedCount");
        Console.WriteLine("5. Выгрузить отчёт");
        Console.WriteLine("0. Выход");
    }

    private static void ShowCount() =>
        Console.WriteLine($"Собрано: {Drone.CreatedCount}. Брака отклонено: {_rejectedCount}.");

    private static void ExportReport()
    {
        if (_reports.Count == 0)
        {
            Console.WriteLine("Отчётов пока нет.");
            return;
        }

        foreach (Report report in _reports)
        {
            Console.WriteLine(report);
        }
    }

    // Сценарий без ввода: все данные заданы в коде.
    private static void RunDemo()
    {
        License? license = License.TryParse("DEMO1234");
        Console.WriteLine($"Лицензия принята: {license?.Key}");

        Assemble(() => new ScoutDrone("SC-001", 100, 80));
        Assemble(() => new CargoDrone("CG-001", 60));
        Assemble(() => new MedicDrone("MD-001"));

        // Брак
        Assemble(() => new ScoutDrone("   "));
        Assemble(() => new CargoDrone("CG-002", 150));

        ShowCount();
        ExportReport();
    }

    public static void Run(bool debug = false, bool interactive = true)
    {
        _debug = debug;

        if (!interactive)
        {
            RunDemo();
            return;
        }

        License? license = License.TryParse(ReadLine("Ключ лицензии (8 символов): "));
        if (license is null)
        {
            Console.WriteLine("Лицензия неверна. Линия не запущена.");
            return;
        }
        Console.WriteLine($"Лицензия принята: {license.Key}");

        bool running = true;
        while (running)
        {
            PrintMenu();

            switch (ReadLine("Выбор: ").Trim())
            {
                case "1":
                    Assemble(() => new ScoutDrone(
                        ReadLine("Серийный номер: "),
                        ReadInt("Энергия (0-100): "),
                        ReadInt("Дальность, км: ")));
                    break;

                case "2":
                    Assemble(() => new CargoDrone(
                        ReadLine("Серийный номер: "),
                        ReadInt("Энергия (0-100): "),
                        ReadInt("Грузоподъёмность, кг: ")));
                    break;

                case "3":
                    Assemble(() => new MedicDrone(
                        ReadLine("Серийный номер: "),
                        ReadInt("Энергия (0-100): "),
                        ReadInt("Аптечек: ")));
                    break;

                case "4":
                    ShowCount();
                    break;

                case "5":
                    ExportReport();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Неизвестный пункт меню.");
                    break;
            }
        }
    }
}