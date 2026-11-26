namespace Practice;

public static class InheritLab
{
    public class Robot(string name)
    {
        public string Name = name;
        private int _energy = 100;

        protected void Spend()
        {
            _energy--;
        } 

        public virtual void Work()
        {
            Console.WriteLine("Двигаться");
        }
    }
    
    public class MedicRobot(string name, int kits = 10) : Robot(name)
    {
        public int Kits = kits;

        public override void Work()
        {
            base.Work();
            Console.WriteLine($"Лечить. Аптечек {Kits}");
            Spend();
        }
    }

    public class CargoRobot(string name, int capacity = 10) : Robot(name)
    {
        public int Capacity = capacity;

        public override void Work()
        {
            base.Work();
            Console.WriteLine($"Перемещать грузы. Вместимость {Capacity}");
            Spend();
        }
    }
    
    public static void Run()
    {
        // 1
        Robot robot = new Robot("MR. ROBOT");
        Console.WriteLine(robot.Name);
        
        // 2
        MedicRobot medicRobot = new MedicRobot("MR. ROBOT M.D.");
        Console.WriteLine(medicRobot.Name);
        
        // 3
        Console.WriteLine(robot.GetType().GetField("Kits") is not null);
        Console.WriteLine(medicRobot.GetType().GetField("Kits") is not null);
        Console.WriteLine(medicRobot.Kits);
        
        // 4: тут нужно убрать base, но у меня его итак нет.
        
        // 5
        robot.Work();
        medicRobot.Work();
        
        // 6
        CargoRobot cargoRobot = new CargoRobot("MR. ROBOT CARGY");
        
        // 7
        Robot[] robots = [robot, medicRobot, cargoRobot];
        foreach (var r in robots)
        {
            r.Work();
        }
        
        // 10: ...
    }
}