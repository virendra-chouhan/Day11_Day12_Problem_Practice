using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementData
{
    class InventoryDataManagement
    {
        public void Inventorydatamanagement()
        {
            InventoryData inventoryData = new InventoryData();
            Console.WriteLine("Press 1.GetUserDetails:");
            Console.WriteLine("Press 2.AddItem:");
            Console.WriteLine("Press 3.Update Item:");
            Console.WriteLine("Press 3.Delete Item:");
            Console.WriteLine("=======================");
            Console.WriteLine("Enter the choice :");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    inventoryData.GetUserDetails();
                    break;
                case 2:
                    inventoryData.AddItem();
                    break;
                case 3:
                    inventoryData.UpdateFile();
                    break;
                case 4:
                    inventoryData.DeleteItem();
                    break;

                default:
                    Console.WriteLine("enter the valid option");
                    break;


            }
        }
    }
}
