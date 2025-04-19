using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Static
{
    public class Product
    {
        public int ProductID { get; set; }
        public string name { get; set; }

        public int QuantityinStock { get; set; }

        private static int nextProductID = 1;
        

        static Product()
        {
            nextProductID = 1;
        }
        public Product(string name, int QuantityinStock)
        {
            this.name = name;
            this.QuantityinStock = QuantityinStock;
            ProductID = GenerateProductID();
        }
        public static int GenerateProductID()
        {
            return nextProductID++;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Product id= {ProductID},Name = {name},Quantity = {QuantityinStock}");
        }
    }
    public class Inventory
    {
        public static Product[] products { get; set; }
        public static int Count { get; set; } = 0;

        static Inventory()
        {
            products = new Product[10];
            Count = 0;
        }
        public static void AddProduct(string Name, int Quan)
        {
            Product newproduct = new Product(Name, Quan);
            products[Count++] = newproduct;
        }
        public static void RemoveProduct(int P_Id, int P_Quan)
        {
            for (int i = 0; i < Count; i++)
            {
                if (products[i].ProductID == P_Id)
                {
                    products[i].QuantityinStock -= P_Quan;
                }
            }
        }
        public static void DisplayInventory()
        {
            for (int i = 0; i < Count; i++)
            {
                products[i].DisplayInfo();
            }
        }
    }
    public static class SimpleInventoryUtilities
    {
        public static int GetTotalProducts()
        {
            return Inventory.Count;
        }
        public static int GetProductcount(int ID)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if(Inventory.products[i].ProductID == ID)
                {
                    return Inventory.products[i].QuantityinStock;
                }
            }
            return 0;
        }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory.AddProduct("Soap", 2);
            Inventory.AddProduct("Dustbin", 5);
            Inventory.AddProduct("Toys", 3);

            Inventory.DisplayInventory();
            Inventory.RemoveProduct(2,1);
            Console.WriteLine("*******************************");
            Inventory.DisplayInventory();
            Console.WriteLine("*******************************");

            var temp=SimpleInventoryUtilities.GetTotalProducts();
            Console.WriteLine($"Total Products = {temp}");
            var Product_count = SimpleInventoryUtilities.GetProductcount(3);
            Console.WriteLine($"Product Counts is {Product_count}");

            Console.ReadLine();
        }
    }
}
