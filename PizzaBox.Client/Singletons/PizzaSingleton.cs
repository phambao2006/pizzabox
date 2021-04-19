using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private const string _path = @"pizzas.xml";
    public List<APizza> Pizzas { get; }
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
      Pizzas = new List<APizza>
      {
        //new VeggiePizza(),
        new MeatPizza()
        //new CustomPizza()
      };
    }
  }
}