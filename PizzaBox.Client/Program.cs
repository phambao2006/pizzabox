using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton pizzaSingleton = PizzaSingleton.Instance;
    private static void Main()
    {
      //RunEF();
      Run();
    }
    private static void RunEF()
    {
      var context = new PizzaBoxContext();
      var stores = context.Stores;
      stores.Add(new ChicagoStore { Name = "12th Street" });
      context.SaveChanges();
    }

    private static void Run()
    {
      var order = new Order();
      Console.WriteLine("Welcome To PizzaBox");
      PrintStoreList();
      order.Store = SelectStore();
      PrintPizzaList();
      order.Pizzas = new List<APizza> { SelectPizza() };


    }

    private static void PrintPizzaList()
    {
      var index = 0;
      foreach (var item in pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} {item}");
      }
    }

    private static APizza SelectPizza()
    {
      Console.WriteLine("Select Your Pizza");
      int input = int.Parse(Console.ReadLine());
      return pizzaSingleton.Pizzas[input - 1];
    }

    private static void PrintStoreList()
    {
      int i = 0;
      foreach (var item in storeSingleton.Stores)
      {
        Console.WriteLine($"{++i} {item}");
      }
    }
    private static AStore SelectStore()
    {
      Console.WriteLine("Select Your Store");
      var input = int.Parse(Console.ReadLine());
      return storeSingleton.Stores[input - 1];
    }
  }
}