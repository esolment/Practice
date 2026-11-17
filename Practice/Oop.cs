namespace Practice;

public static class Oop
{
    public class Robot(string name, int energy)
    {
        public string Name { get; } = name;
        protected int Energy
        {
            get => field;
            set
            {
                if (value is < 0 or > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Заряд должен быть от 0 до 100.");
                }
                field = value;
            }
        } = energy;

        public static int CreatedCount { get; private set; }
        private readonly int _id = ++CreatedCount;

        public Robot(string name) : this(name, 100) {}

        public void Report()
        {
            Console.WriteLine($"Робот {Name}, заряд {Energy}%");
        }

        protected string FormatName()
        {
            return $"[РОБОТ] {Name}";
        }
        
        public void Move(int distance)
        {
            if (distance < 0)
            {
                Console.WriteLine("Дистанция не может быть отрицательной");
                return;
            }
            if (Energy < distance)
            {
                Console.WriteLine("Энергии не хватает на преодоление дистанции");
                return;
            }
            Console.WriteLine($"На дистанцию {distance} метров потрачено {distance}% из {Energy}%. Новый заряд {Energy -= distance}%");
        }

        public void TryRecharge(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Значение для перезарядки должно быть больше 0");
            }

            if (Energy + amount > 100) Energy = 100;
            else Energy += amount;
        }

        public virtual string Work()
        {
            return $"{Name} преодолевает указанные дистанции.";
        }
    }

    public class MedicRobot(string name, int energy) : Robot(name, energy)
    {
        public MedicRobot(string name) : this(name, 100) {}
        
        public override string Work()
        {
            return $"{FormatName()} оказывает медецинскую помощь.";
            // FormatName можно использовать в наследнике, но нельзя извне, потому что он protected
        }
    }

    public class CargoRobot(string name, int energy, int capacity) : Robot(name, energy)
    {
        public int Capacity
        {
            get => field;
            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Вместимость должна быть от 0 до 100.");
                }
                field = value;
            }
        } = capacity;
        
        public CargoRobot(string name) : this(name, 100, 100) {}
        public CargoRobot(string name, int energy) : this(name, energy, 100) {}
        
        public override string Work()
        {
            return $"{Name} возит грузы. Его вместимость {Capacity}.";
        }

        public new void Report()
        {
            Console.WriteLine($"Робот {Name}, заряд {Energy}%, вместимость {Capacity}");
        }
    }
    
    public static void Run()
    {
        var alpha = new Robot("Alpha");
        var beta = new Robot("Beta", 83);
        alpha.Report();
        beta.Report();
        alpha.Move(99);
        beta.Move(90);
        beta.TryRecharge(10);
        beta.Move(90);
        Console.WriteLine(alpha.Work());
        Console.WriteLine(beta.Work());

        var medic = new MedicRobot("Alex M.D.");
        medic.Report();
        Console.WriteLine(medic.Work());
        
        var cargo = new CargoRobot("Bob-Sto24");
        cargo.Report();
        Console.WriteLine(cargo.Work());
        
        Robot[] robots = [alpha, beta, medic, cargo];
        foreach (var robot in robots) { robot.Report(); }
        
        // Сокрытие или override
        CargoRobot exactBot = new CargoRobot("Bob-Sto25");
        exactBot.Work();
        exactBot.Report();

        Robot baseRefRobot = exactBot;
        baseRefRobot.Work();
        baseRefRobot.Report();
        
        Console.WriteLine(Robot.CreatedCount);
        
        // TODO: задания 16+
    }
}