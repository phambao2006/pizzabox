using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton pizzaSingleton = PizzaSingleton.Instance;
    private static readonly SizeSingleton sizeSingleton = SizeSingleton.Instance;
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
      PrintStoreList();
      order.Store = SelectStore();
      PrintPizzaList();
      order.Pizzas.Add(SelectPizza());
    }

    private static void PrintPizzaList()
    {
      var index = 0;
      foreach (var item in pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} {item.Name}");
      }
    }

    private static APizza SelectPizza()
    {
      Console.WriteLine("Select Your Pizza");
      int input = int.Parse(Console.ReadLine());
      var pizza = pizzaSingleton.Pizzas[input - 1];
      //pizza.Size = SelectSize();
      //   pizza.Toppings.Add(SelectTopping());
      return pizza;
    }

    /* private static Topping SelectTopping()
     {
       var topping = new List<Topping>();

     }
 */
    private static Size SelectSize()
    {
      throw new NotImplementedException();
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
      Console.WriteLine("Select Your Store");
      var input = int.Parse(Console.ReadLine());
      return storeSingleton.Stores[input - 1];
    }
  }
}