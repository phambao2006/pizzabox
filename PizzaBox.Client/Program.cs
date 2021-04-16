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
    private static readonly PizzaSingleton pizzaSingleton = PizzaSingleton.Instance;
    private static void Main()
    {
      Run();
    }

    private static void Run()
    {
      var order = new Order();
      Console.WriteLine("Welcome To PizzaBox");
      PrintStoreList();
      order.Store = SelectStore();
      PrintPizzaList();
      order.Pizzas = new List<APizza> { };
      order.Pizzas.Add(SelectPizza());
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
      var input = int.Parse(Console.ReadLine());
      return storeSingleton.Stores[input - 1];
    }
  }
}