using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  public class ToppingSingleton
  {
    private static ToppingSingleton _instance;

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

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

      Toppings = _context.Toppings.ToList();

    }

  }

}