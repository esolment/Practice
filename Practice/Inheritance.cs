namespace Practice;

public static class Inheritance
{
    // 1
    public class Animal
    {
        public string Name;

        public virtual void MakeSound()
        {
            Console.WriteLine("Животное издаёт звук");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Гав-гав");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Мяу-мяу");
        }
    }
    
    // 2
    public class Vehicle
    {
        public int Speed;
        public int Passengers;

        public virtual void Move()
        {
            Console.WriteLine("Транспорт движется");
        }
    }

    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"Машина едет со скоростью {Speed} км/ч");
        }
    }

    public class Bicycle : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"Велосипед движется со скоростью {Speed} км/ч");
        }
    }
    
    // 3
    public class Employee(string name)
    {
        public string Name = name;

        public virtual int GetSalary()
        {
            return 0;
        }
    }

    public class Manager(string name) : Employee(name)
    {
        public override int GetSalary()
        {
            return 50000;
        }
    }

    public class Developer(string name, int hourlyRate, int hoursWorked) : Employee(name)
    {
        public int HoursWorked = hoursWorked;
        public int HourlyRate = hourlyRate;

        public override int GetSalary()
        {
            return HoursWorked * HourlyRate;
        }
    }
    
    public static void Run()
    {
        // 1
        Animal[] animals = [new Animal(),  new Dog(), new Cat()];
        foreach (var animal in animals)
        {
            animal.MakeSound();
            
        }
        
        // 2
        Vehicle[] vehicles = [new Vehicle(), new Car(), new Bicycle()];
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
        
        // 3
        Employee[] employees = [new Employee("Who are you?"), new Manager("Manager"), new Developer("Developer", 1250, 164)];
        int salarySum = 0;
        foreach (var employee in employees)
        {
            salarySum += employee.GetSalary();
        }
        Console.WriteLine($"Компания тратит на сотрудников {salarySum}");
    }
}