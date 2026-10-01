using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_OOP
{
    internal class PremiumCar
    {
        private string Make;
        private string Model;
        private int Year;
        private string FuelType;
        private double Horsepower;

        public PremiumCar(string make, string model, int year, string fuelType, double horsePower)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelType = fuelType;
            Horsepower = horsePower;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Premium Sports Car Details:");
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Fuel Type: {FuelType}");
            Console.WriteLine($"Horsepower: {Horsepower} HP");
        }
    }
}
