using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    public List<APizza> Pizzas { get; }
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static PizzaSingleton _instance;

    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
          _instance = new PizzaSingleton();

        return _instance;
      }
    }

    private PizzaSingleton()
    {
      if (_context.Pizzas.Count() == 0)
      {
        var mp = new MeatPizza();
        mp.Name = "Meat Lover";
        mp.Toppings = new List<Topping>();

        mp.Toppings.AddRange(new List<Topping>
          {
              _context.Toppings.FirstOrDefault(t => t.Name == "Chicken"),
              _context.Toppings.FirstOrDefault(t => t.Name == "Pork"),
              _context.Toppings.FirstOrDefault(t => t.Name == "Beef")

          });

        var vp = new VeggiePizza();
        vp.Name = "Veggie Pizza";
        vp.Toppings = new List<Topping>();
        mp.Toppings.AddRange(new List<Topping>
          {
             _context.Toppings.FirstOrDefault(t => t.Name == "Mushroom"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Pineapple"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Bell Pepper")

          });

        _context.AddRange(new List<APizza> { mp, vp });
        _context.SaveChanges();
      }
      Pizzas = _context.Pizzas.ToList();
    }
  }
}