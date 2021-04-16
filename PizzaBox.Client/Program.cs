using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
    public class Program
    {
        private static readonly StoreSingleton storeSingleton = StoreSingleton.Instance;
        private static void Main()
        {
            Run();
            storeSingleton.WriteToFile();
        }

        private static void Run()
        {
            var order = new Order();
            Console.WriteLine("Welcome To PizzaBox");
            PrintStoreList();
            order.Store = SelectStore();
        }

        private static void PrintStoreList()
        {
            int i = 0;
            foreach (var item in storeSingleton.Stores)
            {
                Console.WriteLine($"{++i} {item.ToString()}");
            }
        }
        private static AStore SelectStore()
        {
            var input = int.Parse(Console.ReadLine());
            return storeSingleton.Stores[input - 1];
        }
    }
}