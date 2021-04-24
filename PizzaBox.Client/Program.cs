﻿using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton pizzaSingleton = new PizzaSingleton();
    private static readonly SizeSingleton sizeSingleton = SizeSingleton.Instance;
    private static readonly ToppingSingleton toppingSingleton = ToppingSingleton.Instance;
    private static readonly CrustSingleton crustSingleton = CrustSingleton.Instance;
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static void Main()
    {
      //RunEF();
      Run();

    }
    private static void RunEF()
    {
      var stores = _context.Stores;
      stores.Add(new ChicagoStore { Name = "12th Street" });
      _context.SaveChanges();
    }

    private static void Run()
    {
      var order = new Order();
      Console.WriteLine("Welcome To PizzaBox");
      // order.Store = SelectStore();
      order.Pizzas = SelectPizza();
    }

    private static void PrintPizzaList()
    {
      var index = 0;
      foreach (var item in pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} {item.Name}");
      }
    }

    private static List<APizza> SelectPizza()
    {
      List<APizza> pizzas = new List<APizza>();
      do
      {
        PrintPizzaList();
        Console.WriteLine("Select Your Pizza");
        int input = int.Parse(Console.ReadLine());
        var pizza = pizzaSingleton.Pizzas[input - 1];
        pizza.Size = SelectSize();
        pizza.Crust = SelectCrust();
        if (pizza.Name == "Custom Pizza")
        {
          pizza.Toppings = SelectTopping();
        }
        pizzas.Add(pizza);
        Console.WriteLine("Pizza in Cart");
        foreach (var item in pizzas)
        {
          Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Do you want to order more pizza ? [Y/N] ");
      } while (Choice().Equals('Y'));
      return pizzas;
    }

    private static Crust SelectCrust()
    {
      Console.WriteLine("Select Your Pizza Crust");
      PrintCrustList();
      var input = int.Parse(Console.ReadLine());
      return crustSingleton.Crusts[input - 1];
    }

    private static Size SelectSize()
    {

      Console.WriteLine("Select Your Pizza Size");
      PrintSizeList();
      var input = int.Parse(Console.ReadLine());
      return sizeSingleton.Sizes[input - 1];
    }
    private static void PrintSizeList()
    {
      int i = 0;
      foreach (var item in sizeSingleton.Sizes)
      {
        Console.WriteLine($"{++i} {item.Name}");
      }
    }
    private static char Choice()
    {
      char choice;
      choice = char.Parse(Console.ReadLine());
      return Char.ToUpper(choice);
    }
    private static void PrintStoreList()
    {
      int i = 0;
      foreach (var item in storeSingleton.Stores)
      {
        Console.WriteLine($"{++i} {item.Name}");
      }
    }
    private static AStore SelectStore()
    {
      PrintStoreList();
      Console.WriteLine("Select Your Store");
      var input = int.Parse(Console.ReadLine());
      return storeSingleton.Stores[input - 1];
    }

    private static void PrintCrustList()
    {
      int i = 0;
      foreach (var item in crustSingleton.Crusts)
      {
        Console.WriteLine($"{++i} {item.Name}");
      }
    }
    private static void PrintToppingList()
    {
      int i = 0;
      foreach (var item in toppingSingleton.Toppings)
      {
        Console.WriteLine($"{++i} {item.Name}");
      }
    }
    private static List<Topping> SelectTopping()
    {
      var toppings = new List<Topping>();
      while (toppings.Count < 3)
      {
        Console.WriteLine("Select Your Topping (up to 3)");

        PrintToppingList();

        int input = int.Parse(Console.ReadLine());

        toppings.Add(toppingSingleton.Toppings[input - 1]);

        if (toppings.Count < 3)
        {
          Console.WriteLine("Would You Like More Topping? [Y/N]");

          if (Choice() == 'N')
          {
            break;
          }
        }
      }
      return toppings;
    }
  }
}