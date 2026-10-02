using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    public interface IInventoryManager
    {
        void AddStock(int quantity);
        void RemoveStock(int quantity);
        void Display();
    }
}
