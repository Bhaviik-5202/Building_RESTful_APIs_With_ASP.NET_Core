using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Inheritance__Abstraction_and_Interface
{
    internal class GroceryStock : IInventoryManager
    {
        string ProductName;
        int Stock;

        public GroceryStock(string productName, int stock)
        {
            if (string.IsNullOrEmpty(productName))
                throw new Exception("Invalid Product Name");

            ProductName = productName;
            Stock = stock;
        }

        public void AddStock(int quantity)
        {
            Stock += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity > Stock)
                throw new Exception("Stock Shortage");

            Stock -= quantity;
        }

        public void Display()
        {
            Console.WriteLine("Grocery Product : " + ProductName);
            Console.WriteLine("Available Stock : " + Stock);
        }
    }
}
