using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_05_Exception_Handling
{
    class OverSpeed : Exception
    {
        public OverSpeed(string message) : base(message) { }
    }
    internal class Car : Vehicle
    {
        const int MAX_SPEED = 120;
        public Car(int speed) 
            : base(speed)
        {
            if (speed > MAX_SPEED)
            {
                throw new OverSpeed(
                    "Speed exceeds the permitted limit."
                );
            }
        }

        public void Display()
        {
            Console.WriteLine("Speed: " + speed + " km/h");
        }
    }
}
