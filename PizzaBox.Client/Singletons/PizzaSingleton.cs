using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private const string _path = @"pizza.xml";
    private readonly FileRepository _fr = new FileRepository();
    public List<APizza> Pizzas { get; }
    private static readonly ContextSingleton contextSingleton = ContextSingleton.Instance;
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

      Pizzas = new List<APizza>();
      Pizzas.AddRange(new List<APizza> { AddMeatPizza(), AddVeggiePizza(), new CustomPizza() });

    }

    private APizza AddMeatPizza()
    {
      var mp = new MeatPizza();
      mp.Name = "Meat Lover";
      mp.Toppings = new List<Topping>();

      mp.Toppings.AddRange(new List<Topping>
          {
              contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Chicken"),
              contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Pork"),
              contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Beef")
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
             contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Mushroom"),
             contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Pineapple"),
             contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Bell Pepper")
          });

      return vp;
    }



    /*if (contextSingleton.context.Pizzas.Count() == 0)
    {
      var mp = new MeatPizza();
      mp.Name = "Meat Lover";
      mp.Toppings = new List<Topping>();

      mp.Toppings.AddRange(new List<Topping>
        {
            contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Chicken"),
            contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Pork"),
            contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Beef")

        });

      var vp = new VeggiePizza();
      vp.Name = "Veggie Pizza";
      vp.Toppings = new List<Topping>();
      mp.Toppings.AddRange(new List<Topping>
        {
           contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Mushroom"),
           contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Pineapple"),
           contextSingleton.context.Toppings.FirstOrDefault(t => t.Name == "Bell Pepper")

        });

      contextSingleton.context.AddRange(new List<APizza> { mp, vp });
      contextSingleton.context.SaveChanges();
    }
    Pizzas = contextSingleton.context.Pizzas.ToList();*/ //if there is a pizza menu in database

  }
}