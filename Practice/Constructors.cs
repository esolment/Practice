namespace Practice;

public static class Constructors
{
    private static bool _debug;
    
    private static string Log(string log)
    {
        if (_debug) { Console.WriteLine(log); }
        return log;
    }
    
    public class Robot
    {
        public string RobotLog = Log("field Robot");

        public string Name { get; }

        protected Robot(string name)
        {
            Log("ctor Robot");
            
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;
        }
    }
    
    public class Drone(string serial, int energy, string role) : Robot(serial)
    {
        public string Serial { get; } = serial;
        public int Energy
        {
            get => field;
            set => field = Math.Clamp(value, 0, 100);
        } = Math.Clamp(energy, 0, 100);
        public string Role { get; } = role;

        public static int CreatedCount { get; protected set; }
        private readonly int _id = ++CreatedCount;

        static Drone() => Console.WriteLine("цех открыт");

        public Drone() : this("RB-DEFAULT") { }
        
        public Drone(string serial) : this(serial, 100) { }

        public Drone(string serial, int energy) : this(serial, energy, "Fly") { }
        
        public Drone(Drone other) : this(other.Serial, other.Energy, other.Role) { }
    }

    public class MedicDrone : Robot
    {
        public string MedicDroneLog = Log("field MedicDrone");
        
        public int Kits { get; }
        
        public MedicDrone(string name, int kits) : base(name)
        {
            Log("ctor MedicDrone");
            
            ArgumentOutOfRangeException.ThrowIfNegative(kits);

            Kits = kits;
        }
    }

    public class WorkshopSettings
    {
        public required string Name { get; init; }
        public int Energy { get; init; }
    }

    public class License
    {
        private License(string key) => Key = key;
        public string Key { get; }

        public static License? TryParse(string key) => key.Length == 8 ? new License(key) : null;
    }

    public record Report(string Serial, int Energy, DateTime CreatedUtc);

    public readonly struct Point(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        
        public override string ToString() => $"({X}, {Y})";
    }
    
    public static void Run(bool debug = false)
    {
        _debug = debug;
        
        // 1
        Drone drone = new Drone("RB-215", 100);
        
        // 2
        Drone droneWithDefaultEnergy = new Drone("RB-216");
        
        // 3
        Drone droneDefault = new Drone();
        
        // 4
        // drone.Energy = 20;                не скомпилируется
        Console.WriteLine(drone.Energy);  // скомпилируется
        
        // 5
        Drone droneTestNegative = new Drone("RB-TEST", -5);
        Drone droneTest = new Drone("RB-TEST", 40);
        Drone droneTestGreater = new Drone("RB-TEST", 200);
        
        Console.WriteLine($"Результаты после Clamp:\n{droneTestNegative.Energy}\n{droneTest.Energy}\n{droneTestGreater.Energy}");
        
        // 6
        try
        {
            Drone invalidDrone = new Drone("   ");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Исключение при создании дрона с пустым именем: {e.Message}");
        }
        
        // 9
        Console.WriteLine($"Дрон создан {Drone.CreatedCount} раз");
        
        // 10
        MedicDrone medicDrone = new MedicDrone("MEDIC-217", 10);
        
        // 11
        // Robot robot = new Robot("X")  не скомпилируется
        
        // 12
        License? license = License.TryParse("EM1L7H9K");
        Console.WriteLine(license != null ? license.Key : "Ключ неверен.");
        
        // 13
        // Когда включён debug:
        // field MedicDrone
        // field Robot
        // ctor Robot
        // ctor MedicDrone
        
        // 15
        var droneReport = new Report(drone.Serial, drone.Energy, DateTime.UtcNow);
        var droneReportChangedCopy = droneReport with { Energy = droneReport.Energy - 20 };
        var droneReportCopy = droneReport with { };
        Console.WriteLine(droneReport == droneReportChangedCopy);
        Console.WriteLine(droneReport == droneReportCopy);
        
        // 16
        WorkshopSettings settings = new WorkshopSettings
        {
            Name = "Test Workshop",
            Energy = 78
        };
        
        // 17
        Drone copiedDrone = new Drone(drone);
        copiedDrone.Energy -= 10;
        Console.WriteLine($"Energy оригинала: {drone.Energy}. Energy копии: {copiedDrone.Energy}.");
        
        // 18: я не понял эту задачу.
        
        // 19
        var p1 = new Point();
        Point p2 = default;
        var p3 = new Point(1, 2);
        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"p3: {p3}");

        // 20
        
    }
}