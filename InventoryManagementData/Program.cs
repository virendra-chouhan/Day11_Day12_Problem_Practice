using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 : Inventory Data");
            Console.WriteLine("Press 2 : Inventory Management");
            Console.WriteLine("Enetr the choice ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InventoryDataManagement inventoryDataManagement = new InventoryDataManagement();
                    inventoryDataManagement.Inventorydatamanagement();
                    break;
                case 2:
                    InventoryManagement.Inventorymanagement();
                    break;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
        }
    }
}
