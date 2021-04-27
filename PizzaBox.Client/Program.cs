using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton pizzaSingleton = PizzaSingleton.Instance;
    private static readonly SizeSingleton sizeSingleton = SizeSingleton.Instance;
    private static readonly ToppingSingleton toppingSingleton = ToppingSingleton.Instance;
    private static readonly CrustSingleton crustSingleton = CrustSingleton.Instance;
    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;
    private static void Main()
    {
      int choice;
      do
      {
        Console.WriteLine("Who Are You?");
        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Store Employee");
        Console.WriteLine("3. Exit");

        choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
          CustomerRun();
        }
        else if (choice == 2)
        {
          StoreRun();
        }
        else
        {
          choice = 3;
        }
      } while (choice < 3);

    }

    private static void StoreRun()
    {
      Console.WriteLine("Select Store You Want To View Orders of: ");
      PrintStoreList();
      int storeid = int.Parse(Console.ReadLine());
      var orders = contextSingleton.context.Orders
      .Where(s => s.StoreEntityID == (storeid))
      .Include(o => o.Store).Include(o => o.Customer).Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ToList();
      foreach (var order in orders)
      {
        Console.WriteLine(order.ToString());
      }

    }
    private static void CustomerRun()
    {
      var order = new Order();
      Console.WriteLine("Welcome To PizzaBox");
      Console.WriteLine("Please Enter Your Name: ");
      var tempname = Console.ReadLine();
      var tempname2 = contextSingleton.context.Customers.FirstOrDefault(c => c.Name == tempname);
      if (tempname2 != null)
      {
        order.Customer = tempname2;
      }
      else
      {
        order.Customer = new Customer { Name = tempname };
      }

      order.Store = SelectStore();
      order.Pizzas = SelectPizza();
      var total = order.Total();
      Console.WriteLine($"Your total is: ${total} + Tax = {(total * (decimal)1.0825).ToString("#.##")}");
      contextSingleton.context.Orders.Add(order);
      contextSingleton.context.SaveChanges();
      Console.WriteLine("Order will ready in 15 mins Thank You !");
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
        Console.WriteLine("Select Your Pizza");
        PrintPizzaList();
        int input = int.Parse(Console.ReadLine());
        if (pizzaSingleton.Pizzas[input - 1] is MeatPizza)
        {
          var pizza = new MeatPizza();
          pizza.Size = SelectSize();
          pizza.Crust = SelectCrust();
          pizzas.Add(pizza);
        }

        else if (pizzaSingleton.Pizzas[input - 1] is VeggiePizza)
        {
          var pizza = new VeggiePizza();
          pizza.Size = SelectSize();
          pizza.Crust = SelectCrust();
          pizzas.Add(pizza);
        }

        else if (pizzaSingleton.Pizzas[input - 1] is CustomPizza)
        {
          var pizza = new CustomPizza();
          pizza.Size = SelectSize();
          pizza.Crust = SelectCrust();
          pizza.Toppings = SelectTopping();
          pizzas.Add(pizza);
        }

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
      Console.WriteLine("Select Your Store");
      PrintStoreList();
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