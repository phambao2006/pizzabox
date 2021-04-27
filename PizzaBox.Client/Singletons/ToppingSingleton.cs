using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class ToppingSingleton
  {
    private static ToppingSingleton _instance;

    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;

    public List<Topping> Toppings { get; }
    public static ToppingSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingSingleton();
        }

        return _instance;
      }

    }
    private ToppingSingleton()
    {
      Toppings = new List<Topping>();
      Toppings.AddRange(new List<Topping>
      {
            new Topping {Name = "Chicken", Price = 2},
            new Topping {Name = "Beef", Price = 2},
            new Topping {Name = "Pork", Price = 2},
            new Topping {Name = "Mushroom" ,Price = 2},
            new Topping {Name = "Pinapple", Price = 2},
            new Topping {Name = "Bell Pepper", Price = 2}


      });
    }

  }

}