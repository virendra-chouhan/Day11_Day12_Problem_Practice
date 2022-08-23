using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InventoryManagementData
{
    class InventoryData
    {
        string jsonFile = @"C:\virendra\Backup\Projects\Bridgelabz-dev\LFP_Programm\Day11-12\-Object-Oriented-PracticeProb-Inventary\ObjectOrientedPrograms-master\InventoryManagementData\Inventory.json";
        public void GetUserDetails()
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                
                var JsonObject = JObject.Parse(json);
                if (JsonObject != null)
                {
                    JArray riceArray = (JArray)JsonObject["Rice"];


                    if (riceArray != null)
                    {
                        foreach (var item in riceArray)
                        {
                            Console.WriteLine("Rice Name:" + item["name"].ToString());
                            Console.WriteLine("Rice price:" + item["price"].ToString());
                            Console.WriteLine("Rice Weight :" + item["weight"].ToString());

                        }
                    }
                }
                if (JsonObject != null)
                {
                    JArray wheatsArray = (JArray)JsonObject["Wheats"];
                    if (wheatsArray != null)
                    {
                        foreach (var item in wheatsArray)
                        {
                            Console.WriteLine("Wheats Name :" + item["name"].ToString());
                            Console.WriteLine("Wheats Price :" + item["price"].ToString());
                            Console.WriteLine("Wheats weight :" + item["weight"].ToString());

                        }
                    }
                }
                if (JsonObject != null)
                {
                    JArray pulsesArray = (JArray)JsonObject["Pulses"];
                    foreach (var item in pulsesArray)
                    {
                        Console.WriteLine("Pulses Name :" + item["name"].ToString());
                        Console.WriteLine("Pulses price :" + item["price"].ToString());
                        Console.WriteLine("Pulses weight :" + item["weight"].ToString());

                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddItem()
        {
            Console.WriteLine("Enter the itemname ");
            var itemname = Console.ReadLine();
            Console.WriteLine("enter the Type of item name");
            var itemtypename = Console.ReadLine();
            Console.WriteLine("enter the price of item");
            var price = Console.ReadLine();
            Console.WriteLine("enter the weight");
            var weight = Console.ReadLine();

            var newItem = "{ 'name': '" + itemtypename + "','price':" + price + ",'weight':" + weight + "}";
            var json = File.ReadAllText(this.jsonFile);
            var jsonObject = JObject.Parse(json);
            var itemArray = jsonObject.GetValue(itemname) as JArray;
            var newitemObject = JObject.Parse(newItem);
            Console.WriteLine("newitemobject" + newitemObject);
            itemArray.Add(newitemObject);
            Console.WriteLine("item array :" + itemArray);
            jsonObject[itemname] = itemArray;

            string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(this.jsonFile, newJsonResult);


        }
        public void UpdateFile()
        {
            string json = File.ReadAllText(this.jsonFile);
            try
            {
                var jsonObject = JObject.Parse(json);
                Console.WriteLine("Enter Item Name ");
                string itemNameToUpdate = Console.ReadLine();
                JArray riceArrary = (JArray)jsonObject[itemNameToUpdate];
                Console.Write("Enter Item Name to Update : ");
                var itemName = Console.ReadLine();
                Console.Write("Enter new Item name : ");
                var newItemName = Convert.ToString(Console.ReadLine());

                foreach (var item in riceArrary.Where(obj => obj["name"].Value<string>().Equals(itemName)))
                {

                    item["name"] = !string.IsNullOrEmpty(newItemName) ? newItemName : string.Empty;
                }

                jsonObject["name"] = riceArrary;
                string output = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(this.jsonFile, output);
                Console.WriteLine(newItemName + " is Updated on " + itemName);
            }

            catch (Exception exception)
            {
                Console.WriteLine("Update Error : " + exception.Message.ToString());
            }
        }
        public void DeleteItem()
        {
            string json = File.ReadAllText(this.jsonFile);

            try
            {
                var jsonObject = JObject.Parse(json);
                Console.WriteLine("Enter the item Name ");
                var itemname = Console.ReadLine();
                JArray itemArray = (JArray)jsonObject[itemname];
                Console.WriteLine("Enter the item tyoe to be deleted");
                var itemtypetodelete = Console.ReadLine();
              
                var itemtoDeleted = itemArray.FirstOrDefault(obj => obj["name"].Value<string>().Equals(itemtypetodelete));
                
                itemArray.Remove(itemtypetodelete);
                string Resultoutput = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(jsonFile, Resultoutput);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
