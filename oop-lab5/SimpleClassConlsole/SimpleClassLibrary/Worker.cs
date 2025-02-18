using System;

namespace SimpleClassLibrary
{
    public class Worker
    {
        public string Name;
        public int Year;
        public int Month;
        public Company WorkPlace;
        public double Bonus;

        public Worker() { }

        public Worker(string name, int year, int month, Company workPlace, double bonus)
        {
            Name = name;
            Year = year;
            Month = month;
            WorkPlace = workPlace;
            Bonus = bonus;
        }

        public Worker(Worker other)
        {
            Name = other.Name;
            Year = other.Year;
            Month = other.Month;
            WorkPlace = new Company(other.WorkPlace);
            Bonus = other.Bonus;
        }

        public string GetName() => Name;
        public void SetName(string name) => Name = name;

        public int GetYear() => Year;
        public void SetYear(int year) => Year = year;

        public int GetMonth() => Month;
        public void SetMonth(int month) => Month = month;

        public Company GetWorkPlace() => WorkPlace;
        public void SetWorkPlace(Company workPlace) => WorkPlace = workPlace;

        public double GetBonus() => Bonus;
        public void SetBonus(double bonus) => Bonus = bonus;

        public int GetWorkExperience()
        {
            DateTime now = DateTime.Now;
            int years = now.Year - Year;
            int months = now.Month - Month;
            return years * 12 + months;
        }

        public double GetTotalMoney()
        {
            return GetWorkExperience() * WorkPlace.Salary + Bonus;
        }

        public double GetBonusInUAH() => Bonus;

        public double GetBonusInUSD(double exchangeRate) => Bonus / exchangeRate;

        public double GetBonusInEUR(double exchangeRate) => Bonus / exchangeRate;
    }
}
