using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private const string _path = @"pizzas.xml";
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

      _context.Pizzas.AddRange(new List<APizza> { new MeatPizza(), new VeggiePizza() });
      Pizzas = _context.Pizzas.ToList();

      _context.SaveChanges();
    }
  }
}