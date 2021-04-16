using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    public List<APizza> Pizzas { get; }
    private static readonly PizzaSingleton _instance;

    public static PizzaSingleton Instance
    {
      get
      {
        return new PizzaSingleton();
      }
    }
    private PizzaSingleton()
    {
      Pizzas = new List<APizza>
      {
        new VeggiePizza(),
        new MeatPizza(),
        new CustomPizza()
      };
    }
  }
}