using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_OOP
{
    internal class Item
    {
        private int Item_Code;
        private string Item_Name;
        private int Stock_Quantity;

        public Item(int item_Code, string item_Name, int stock_Quantity)
        {
            Item_Code = item_Code;
            Item_Name = item_Name;
            Stock_Quantity = stock_Quantity;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Supermarket Inventory:");
            Console.WriteLine($"Item_Code: {Item_Code}");
            Console.WriteLine($"Item_Name: {Item_Name}");
            Console.WriteLine($"Stock_Quantity: {Stock_Quantity}");
        }
    }
}
