using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private const string _path = @"pizza.xml";
    private readonly FileRepository _fr = new FileRepository();
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
      try
      {
        Pizzas = _fr.ReadFromFile<List<APizza>>(_path);
      }
      catch
      {

        Pizzas = new List<APizza>();
        Pizzas.AddRange(new List<APizza> { AddMeatPizza(), AddVeggiePizza(), new CustomPizza() });

        _fr.WriteToFile(Pizzas, _path);
      }
    }

    private APizza AddMeatPizza()
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

      return mp;
    }

    private APizza AddVeggiePizza()
    {
      var vp = new VeggiePizza();
      vp.Name = "Veggie Pizza";
      vp.Toppings = new List<Topping>();
      vp.Toppings.AddRange(new List<Topping>
          {
             _context.Toppings.FirstOrDefault(t => t.Name == "Mushroom"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Pineapple"),
             _context.Toppings.FirstOrDefault(t => t.Name == "Bell Pepper")
          });

      return vp;
    }



    /*if (_context.Pizzas.Count() == 0)
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
    Pizzas = _context.Pizzas.ToList();*/ //if there is a pizza menu in database

  }
}