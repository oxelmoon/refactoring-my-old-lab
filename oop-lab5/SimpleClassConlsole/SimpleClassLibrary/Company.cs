namespace SimpleClassLibrary
{
    public class Company
    {
        public string Name;
        public string Position;
        public double Salary;

        public Company() { }

        public Company(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public Company(Company other)
        {
            Name = other.Name;
            Position = other.Position;
            Salary = other.Salary;
        }

        public string GetName() => Name;
        public void SetName(string name) => Name = name;

        public string GetPosition() => Position;
        public void SetPosition(string position) => Position = position;

        public double GetSalary() => Salary;
        public void SetSalary(double salary) => Salary = salary;
    }
}
